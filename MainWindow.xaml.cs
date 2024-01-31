using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Autoasocjator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double[] thetaArray = new double[2500];
        public double[] inputImage = new double[2500];
        public double[] outputImage = new double[2500];
        public static Data data = new Data();
        public List<Data> examples = data.LoadData();
        public List<double[]> perceptrons = new List<double[]>();

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 2500; i++)
            {
                perceptrons.Add(Simple_Perceptron_Learning(i));
                Console.WriteLine("Perceptron:" + i);
            }
        }

        public double[] Simple_Perceptron_Learning(int nrPerceptron)
        {
            int O;
            int lifeTime = 0;
            int bestLifeTime = 0;
            double learningEta = 0.1;
            double bestTheta = 0;
            double[] weights = new double[2500];
            double[] bestWeights = new double[2500];
            double max = 0.01;
            double min = -0.01;
            bool h = true;
            Random random = new Random();

            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = (max - min) * random.NextDouble() + min;
            }

            double theta = (max - min) * random.NextDouble() + min;

            for (int i = 0; i < 1000; i++)
            {
                //Console.WriteLine(nrPerceptron);
                int rndNumber = random.Next(7);
                var example = examples[rndNumber];

                if (example.Input[nrPerceptron] == 1)
                    O = 1;
                else
                    O = -1;

                double sum = 0.0;
                int result;
                for (int j = 0; j < example.Input.Length; j++)
                {
                    sum += example.Input[j] * weights[j];
                }
                if (sum < theta)
                    result = -1;
                else
                    result = 1;

                double ERR = O - result;
                if (ERR != 0)
                {
                    for (int j = 0; j < weights.Length; j++)
                    {
                        weights[j] = weights[j] + (learningEta * ERR * example.Input[j]);
                    }
                    theta = theta - (learningEta * ERR);
                    lifeTime = 0;
                    h = true;
                }
                else
                {
                    lifeTime++;

                    if (lifeTime > bestLifeTime)
                    {
                        bestLifeTime = lifeTime;
                        bestTheta = theta;
                        if (h == true)
                        {
                            weights.CopyTo(bestWeights, 0);
                            h = false;
                        }
                    }
                }
            }
            thetaArray[nrPerceptron] = bestTheta;
            return bestWeights;
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string projectFolderPath = data.LoadProjectPath();
            string s = (combobox.SelectedIndex + 1).ToString() + ".png";
            string imagePath = System.IO.Path.Combine(projectFolderPath, "Assets", s);
            DisplayInputImage(imagePath);
            inputImage = data.LoadImage(imagePath);
        }

        public void DisplayInputImage(string s)
        {
            input.Source = new BitmapImage(new Uri(s));
        }

        public void DisplayOutputImage()
        {
            int k = 0;
            Bitmap img = new Bitmap(50,50);
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    if (outputImage[k] == 1)
                        img.SetPixel(i, j, System.Drawing.Color.Black);
                    else
                        img.SetPixel(i, j, System.Drawing.Color.White);
                    k++;
                }
            }
            BitmapImage bitmap = new BitmapImage();
            using (MemoryStream memory = new MemoryStream())
            {
                img.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                bitmap.BeginInit();
                bitmap.StreamSource = memory;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
            }
            output.Source = bitmap;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            outputImage = new double[2500];
            for (int i = 0; i < 2500; i++)
            {
                double sum = 0.0;

                for (int j = 0; j < inputImage.Length; j++)
                {
                    sum += inputImage[j] * perceptrons[i][j];
                }

                if (sum >= thetaArray[i])
                    outputImage[i] = 1;
            }
            DisplayOutputImage();
        }

        public void DisplayNoisedImage()
        {
            int k = 0;
            Bitmap img = new Bitmap(50, 50);
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    if (inputImage[k] == 1)
                        img.SetPixel(i, j, System.Drawing.Color.Black);
                    else
                        img.SetPixel(i, j, System.Drawing.Color.White);
                    k++;
                }
            }
            BitmapImage bitmap = new BitmapImage();
            using (MemoryStream memory = new MemoryStream())
            {
                img.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                bitmap.BeginInit();
                bitmap.StreamSource = memory;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
            }
            input.Source = bitmap;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int noise;
            for (int i = 0; i < 50; i++)
            {
                noise = r.Next(0, 2500);
                if (inputImage[noise] == 1)
                    inputImage[noise] = 0;
                else
                    inputImage[noise] = 1;
            }
            DisplayNoisedImage();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            inputImage = outputImage;
            DisplayNoisedImage();
        }


    }
}
