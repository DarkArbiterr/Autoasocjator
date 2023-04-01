using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

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
            double[] array1 = LoadImage(@"D:\Autoasocjator\Assets\1.png");
            data.Add(new Data(array1));
            double[] array2 = LoadImage(@"D:\Autoasocjator\Assets\2.png");
            data.Add(new Data(array2));
            double[] array3 = LoadImage(@"D:\Autoasocjator\Assets\3.png");
            data.Add(new Data(array3));
            double[] array4 = LoadImage(@"D:\Autoasocjator\Assets\4.png");
            data.Add(new Data(array4));
            double[] array5 = LoadImage(@"D:\Autoasocjator\Assets\5.png");
            data.Add(new Data(array5));
            double[] array6 = LoadImage(@"D:\Autoasocjator\Assets\6.png");
            data.Add(new Data(array6));
            double[] array7 = LoadImage(@"D:\Autoasocjator\Assets\7.png");
            data.Add(new Data(array7));

            return data;
        }

        public double[] LoadImage(string path)
        {
            double[] array = new double[2500];
            int k = 0;
            Bitmap img = new Bitmap(path);
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
            return array;
        }
    }
}
