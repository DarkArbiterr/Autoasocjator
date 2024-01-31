using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Autoasocjator
{
    public class Data
    {
        public double[] Input { get; set; }

        public Data(double[] input)
        {
            Input = input;
        }

        public Data()
        {

        }

        public List<Data> LoadData()
        {
            List<Data> data = new List<Data>();

            // Pobieranie ścieżki do katalogu projektu
            string projectDirectory = LoadProjectPath();

            // Łączenie ścieżki do katalogu projektu z nazwami plików
            string[] fileNames = { "1.png", "2.png", "3.png", "4.png", "5.png", "6.png", "7.png" };
            foreach (string fileName in fileNames)
            {
                string filePath = Path.Combine(projectDirectory, "Assets", fileName);
                double[] imageData = LoadImage(filePath);
                data.Add(new Data(imageData));
            }

            return data;
        }

        public string LoadProjectPath()
        {
            string path = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", ".."));

            return path;
        }

        public double[] LoadImage(string path)
        {
            double[] array = new double[2500];

            try
            {
                if (File.Exists(path))
                {
                    using (Bitmap img = new Bitmap(path))
                    {
                        int k = 0;
                        for (int i = 0; i < img.Width; i++)
                        {
                            for (int j = 0; j < img.Height; j++)
                            {
                                Color pixel = img.GetPixel(i, j);
                                if (pixel.R < 128 && pixel.G < 128 && pixel.B < 128)
                                {
                                    array[k] = 1;
                                    k++;
                                }
                                else
                                {
                                    array[k] = 0;
                                    k++;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Plik obrazu o ścieżce '{path}' nie istnieje.");
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu, np. wypisanie komunikatu lub zalogowanie go
                Console.WriteLine($"Błąd podczas wczytywania obrazu: {ex.Message}");
            }

            return array;
        }
    }
}
