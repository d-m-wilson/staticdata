using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using StaticGeneratorCommon;

namespace StaticGenerator
{
    public partial class frmGenerate : Form
    {
        private const string schemaNameExpression = @"^\[.*\]\.";

        public frmGenerate()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            fbdDropFolder.ShowDialog();
            if (string.IsNullOrEmpty(fbdDropFolder.SelectedPath) == false)
            {
                txtFolder.Text = fbdDropFolder.SelectedPath;
            }
        }

        private void frmGenerate_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} v{1}", this.Text, Application.ProductVersion);

            // Load previous settings
            if (!string.IsNullOrEmpty(Properties.Settings.Default.LastDropFolder))
            {
                this.txtFolder.Text = Properties.Settings.Default.LastDropFolder;
            }

            this.chkCreateIndex.Checked = Properties.Settings.Default.LastIndexChoice;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.ScriptFilenameSuffix))
            {
                this.txtScriptFilenameSuffix.Text = Properties.Settings.Default.ScriptFilenameSuffix;
            }

            this.chkOmitSchemaFromFileNames.Checked = Properties.Settings.Default.OmitSchemaFromFileNames;

            // Populate the table list
            LoadTableList();
        }

        private void frmGenerate_Closing(Object sender, FormClosingEventArgs e)
        {
            // Save settings
            Properties.Settings.Default.LastDropFolder = this.txtFolder.Text;
            Properties.Settings.Default.LastIndexChoice = this.chkCreateIndex.Checked;
            Properties.Settings.Default.ScriptFilenameSuffix = this.txtScriptFilenameSuffix.Text;
            Properties.Settings.Default.OmitSchemaFromFileNames = this.chkOmitSchemaFromFileNames.Checked;
            Properties.Settings.Default.Save();
        }

        private void LoadTableList()
        {
            try
            {
                string strConnectionString = ConfigurationManager.ConnectionStrings["default"].ToString();
                Globals.ConnectionString = strConnectionString;

                SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(strConnectionString);
                lblServer.Text = connectionStringBuilder.DataSource;
                lblDatabase.Text = connectionStringBuilder.InitialCatalog;

                DataTable dtTableList = new DataTable("Tables");
                SqlCommand cdTableList = Globals.Connection.CreateCommand();
                cdTableList.CommandText = "SELECT TABLE_NAME, TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
                dtTableList.Load(cdTableList.ExecuteReader(CommandBehavior.CloseConnection));

                foreach (DataRow drTableName in dtTableList.Rows)
                {
                    clbTables.Items.Add(string.Format("[{0}].[{1}]", drTableName[1].ToString(), drTableName[0].ToString()));
                }

                clbTables.Sorted = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occured while attempting to open the table list. Have you specified a connection string in the settings file?" +
                    Environment.NewLine + Environment.NewLine + "Error text: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while attempting to open the table list." +
                    Environment.NewLine + Environment.NewLine + "Error text: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool HasInvalidFileNameChars(string input)
        {
            return Path.GetInvalidFileNameChars()
                .ToList()
                .Where(ch => input.Contains(ch))
                .Any();
        }

        private void btnGenerateScripts_Click(object sender, EventArgs e)
        {
            // Make sure they have selected a folder
            if (string.IsNullOrEmpty(txtFolder.Text) == true)
            {
                MessageBox.Show("Please select a folder to drop the generated script(s) into", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Make sure the folder exists
            if (!System.IO.Directory.Exists(this.txtFolder.Text))
            {
                MessageBox.Show("The selected folder does not exist. Pleas select a valid directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtScriptFilenameSuffix.Text))
            {
                MessageBox.Show("The Script Filename Suffix is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (HasInvalidFileNameChars(txtScriptFilenameSuffix.Text))
            {
                MessageBox.Show("The Script File Name Suffix contains one or more characters which cannot be used in a file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Make sure they have selected at least one table
            if (clbTables.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one table to generate scripts for", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Make sure the template exists
            if (File.Exists("DefaultTemplate.sql") == false)
            {
                MessageBox.Show("Template file DefaultTemplate.sql not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Load the template
            StreamReader srTemplate = new StreamReader("DefaultTemplate.sql");
            string strTemplate = srTemplate.ReadToEnd();
            srTemplate.Close();

            Regex schemaNameRegex = null;

            if (chkOmitSchemaFromFileNames.Checked)
            {
                schemaNameRegex = new Regex(schemaNameExpression, RegexOptions.Compiled);
            }

            foreach (string strTableName in clbTables.CheckedItems)
            {
                string scriptFileName;

                if (chkOmitSchemaFromFileNames.Checked)
                {
                    scriptFileName = schemaNameRegex.Replace(strTableName, string.Empty, 1);
                }
                else
                {
                    scriptFileName = strTableName;
                }

                // Replace the tablename placeholder in the template
                string strNewTemplate = strTemplate.Replace("<TABLENAME>", strTableName);

                // Create the file
                scriptFileName = Path.Combine(txtFolder.Text, StripBrackets(scriptFileName)) + txtScriptFilenameSuffix.Text;
                StreamWriter swOutFile = new StreamWriter(scriptFileName, false);
                swOutFile.Write(Globals.CreateStaticDataManager(strTableName, strNewTemplate));
                swOutFile.Close();
            }

            if (chkCreateIndex.Checked == true)
            {
                // Create index file
                StreamWriter swIndex = new StreamWriter(Path.Combine(txtFolder.Text, "index.txt"), false);
                foreach (string strTableName in clbTables.CheckedItems)
                {
                    string scriptFileName;

                    if (chkOmitSchemaFromFileNames.Checked)
                    {
                        scriptFileName = schemaNameRegex.Replace(strTableName, string.Empty, 1);
                    }
                    else
                    {
                        scriptFileName = strTableName;
                    }

                    scriptFileName = StripBrackets(scriptFileName) + txtScriptFilenameSuffix.Text;
                    swIndex.WriteLine(":r .\\StaticData\\" + scriptFileName);
                }
                swIndex.Close();
            }

            MessageBox.Show("Done!!", "Static Data Script Generator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Quick hack function to remove the square brackets
        /// from the table name for use with filenames
        /// </summary>
        /// <param name="pText">The text to strip square brackets from</param>
        /// <returns></returns>
        private string StripBrackets(string pText)
        {
            return pText.Replace("[", "").Replace("]", "");
        }

        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckState state = selectAllCheckBox.CheckState;

            for(int i=0; i < clbTables.Items.Count; i++)
                clbTables.SetItemCheckState(i, state);
        }
    }
}