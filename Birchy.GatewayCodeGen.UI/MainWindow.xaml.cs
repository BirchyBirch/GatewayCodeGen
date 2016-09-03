using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using Birchy.GatewayCodeGen.Composition;
using Birchy.GatewayCodeGen.Core;
using Birchy.GatewayCodeGen.Engine;
using WinForms = System.Windows.Forms;

namespace Birchy.GatewayCodeGen.UI
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GenerationFacade _facade;

        public MainWindow()
        {
            var masterContainer = new MasterContainer();
            _facade = masterContainer.Facade;
            InitializeComponent();
        }

        private CodeGenerationConfiguration GetConfigurationFromFormInput()
        {
            var includeTables = IncludeTablesBox.Text.Split(',').Select(s => s.Trim()).ToArray();
            if (IncludeTablesBox.Text.Trim().Length == 0)
                includeTables = new string[0];
            var excludeSchemas = ExcludeSchemasBox?.Text?.Split(',')?.Select(s => s.Trim())?.ToArray() ?? new string[0];
            if (ExcludeSchemasBox?.Text?.Trim().Length == 0)
                excludeSchemas = new string[0];
            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = ServerNameBox.Text,
                InitialCatalog = DatabaseNameBox.Text,
                IntegratedSecurity = true
            }.ToString();
            var codeGenerationConfiguration = new CodeGenerationConfiguration
            {
                DatabaseName = DatabaseNameBox.Text,
                ConnectionString = connectionString,
                CoreNamespace = DtosNamespaceBox.Text.Replace(" ", string.Empty),
                DataNamespace = GatewaysNamespaceBox.Text.Replace(" ", string.Empty),
                IncludeTables = includeTables,
                ExcludeSchemas = excludeSchemas
            };
            return codeGenerationConfiguration;
        }

        private void GenerateCode()
        {
            var codeGenerationConfiguration = GetConfigurationFromFormInput();
            var di = new DirectoryInfo(WhereToSaveBox.Text);
            if (!di.Exists)
            {
                MessageBox.Show(@"Your directory doesnt exist. Create it");
                return;
            }

            try
            {
                var generatedDataAccessLayer = _facade.GenerateDataAccessLayer(codeGenerationConfiguration);
                _facade.ExportCode(generatedDataAccessLayer, di);
                Process.Start(di.FullName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void InvokeFileDialog()
        {
            using (var folderBrowserDialog = new WinForms.FolderBrowserDialog {ShowNewFolderButton = true})
            {
                var dialogResult = folderBrowserDialog.ShowDialog();
                if (dialogResult == WinForms.DialogResult.OK)
                    WhereToSaveBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            InvokeFileDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GenerateCodeButton.IsEnabled = false;
            try
            {
                GenerateCode();
            }
            finally
            {
                GenerateCodeButton.IsEnabled = true;
            }
        }
    }
}