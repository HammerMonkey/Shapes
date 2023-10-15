using ShapesLibrary.Models.XmlModels;
using ShapesLibrary.Services;

namespace ShapesConsole
{
    class Program
    {
        static void Main()
        {
            var fileDirectory = Directory.GetCurrentDirectory() + @"\Ex1_cSharp_example.xml";
            Console.WriteLine(@$"Default xml file will be loaded from: {fileDirectory}");
            Console.WriteLine("press ENTER, or type in wanted file with full directory");
            var response = Console.ReadLine();

            if (response != "")
            {
                fileDirectory = response;
            }
            try
            {
                Shapes shapes = XmlLoader.LoadShapesFromXml(fileDirectory!);

                var figureList = FigureBuilder.BuildFigures(shapes);

                Console.WriteLine($"Saving figures to: {Directory.GetCurrentDirectory()}");
                FigureExporter.SaveFigures(figureList, Directory.GetCurrentDirectory());
                Console.WriteLine("Files saved");
                Console.ReadLine();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
}