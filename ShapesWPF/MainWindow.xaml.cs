using Microsoft.Win32;
using ShapesLibrary.Models.XmlModels;
using ShapesLibrary.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace ShapesWPF
{
    public partial class MainWindow : Window
    {
        private string FilePath = "";
        private List<(string name, string description)> FigureDescription = new();
        private bool XmlLoaded = false;
        private bool XmlConverted = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileDropStackPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                FilePath = Path.GetFullPath(files[0]);

                if (Path.GetExtension(FilePath).Equals(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    LoadFiguresIntoRichTextBox(File.ReadAllText(FilePath));
                    XmlLoaded = true;
                    XmlConverted = false;
                }
                else
                {
                    MessageBox.Show("Please Drop .xml file");
                }
            }
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => DragMove();

        private void BtnMinimize_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void BtnMaximize_Click(object sender, RoutedEventArgs e) => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = ".xml files | *.xml";
            fileDialog.Multiselect = false;
            bool? success = fileDialog.ShowDialog();
            if (success == true)
            {
                FilePath = fileDialog.FileName;
                LoadFiguresIntoRichTextBox(File.ReadAllText(FilePath));
                XmlLoaded = true;
                XmlConverted = false;
            }
        }

        private void LoadFiguresIntoRichTextBox(string text)
        {
            RichTextBox.Document = new FlowDocument();
            FlowDocument flowDocument = new FlowDocument();
            Paragraph paragraph = new Paragraph();

            Run run = new Run(text);
            paragraph.Inlines.Add(run);
            flowDocument.Blocks.Add(paragraph);
            RichTextBox.Document = flowDocument;
            FileDropStackPanel.Visibility = Visibility.Hidden;
        }

        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (XmlLoaded)
            {
                XmlConverted = GetFiguresFromXml();
            }
        }
        private bool GetFiguresFromXml()
        {
            try
            {
                Shapes shapes = XmlLoader.LoadShapesFromXml(FilePath);

                var figureList = FigureBuilder.BuildFigures(shapes);
                FigureDescription = FigureExporter.CreateFigureDescription(figureList);
                var fullDescription = new StringBuilder();
                foreach (var figure in FigureDescription)
                {
                    fullDescription = fullDescription.Append(figure.description).AppendLine();
                }
                LoadFiguresIntoRichTextBox(fullDescription.ToString());
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!XmlConverted)
                return;
            using var dialog = new System.Windows.Forms.FolderBrowserDialog
            {
                Description = "Time to select a folder",
                UseDescriptionForTitle = true,
                SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + Path.DirectorySeparatorChar,
                ShowNewFolderButton = true
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FigureExporter.SaveFigureDescription(dialog.SelectedPath, FigureDescription);

                    var result = MessageBox.Show("Files saved! Open them?", "Success", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        OpenFigureDescription(dialog.SelectedPath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OpenFigureDescription(string selectedPath)
        {
            foreach (var figure in FigureDescription)
            {
                System.Diagnostics.Process.Start("notepad.exe", selectedPath + $"\\{figure.name}.txt");
            }
        }
    }
}
