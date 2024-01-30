using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dispersie_graf
{ 
    public static class Engine
    {
        public static Graphics grp;
        public static Bitmap bmp;
        public static PictureBox pctBx;
        public static Color color = Color.Ivory;

        public static Random rnd = new Random();
        public static int n;
        public static double[,] matrix;

        public static int zoom = 20;

        public static int N = 1000; // populatii
        public static int K = 100; // cele mai bune populatii 
        public static double mutationRate = 0.01;
        public static List<Sol> population;

        internal static void Run(ListBox listBox1, Label labelGeneration, Label labelPenalty, Label labelBestPenalty)
        {
            Task.Run(async () =>
            {
                LoadFromFile(@"..\..\TextFile1.txt");
                ViewGraph(listBox1);

                GeneratePopulation();
                SortPopulation();

                labelGeneration.Text = "0";
                labelPenalty.Text = population[0].CalculateFitness().ToString();
                labelBestPenalty.Text = population[0].CalculateFitness().ToString();

                int generationCount = 0;
                while (true)
                {
                    Clear();

                    population[0].View();
                    labelGeneration.Text = generationCount.ToString();
                    labelPenalty.Text = population[0].CalculateFitness().ToString();

                    if (population[0].CalculateFitness() < double.Parse(labelBestPenalty.Text))
                        labelBestPenalty.Text = population[0].CalculateFitness().ToString();

                    Refresh();

                    List<Sol> temp = new List<Sol>();

                    for (int i = 0; i < N; i++)
                    {
                        Sol parent = population[rnd.Next(K)];
                        Sol child = population[i].Crossover(parent);

                        if (rnd.NextDouble() <= mutationRate)
                            child.Mutate();

                        temp.Add(child);
                    }

                    for (int i = 0; i < N; i++)
                        population[i] = temp[i];

                    SortPopulation();

                    generationCount++;

                    await Task.Delay(70);
                }
            });
        }

        public static void InitGraphics(PictureBox pictureBox)
        {
            pctBx = pictureBox;
            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(color);
        }

        public static void LoadFromFile(string fileName)
        {
            TextReader load = new StreamReader(fileName);
            n = int.Parse(load.ReadLine());
            matrix = new double[n, n];
            string buffer;
            while ((buffer = load.ReadLine()) != null)
            {
                int x = int.Parse(buffer.Split(' ')[0]);
                int y = int.Parse(buffer.Split(' ')[1]);
                double distance = double.Parse(buffer.Split(' ')[2]);
                matrix[x, y] = distance;
                matrix[y, x] = distance;
            }
        }
        public static void GeneratePopulation()
        {
            population = new List<Sol>();

            for (int i = 0; i < N; i++)
                population.Add(new Sol());
        }

        public static void SortPopulation()
        {
            population.Sort((Sol A, Sol B) => A.CalculateFitness().CompareTo(B.CalculateFitness()));
        }

        public static double GetDistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        public static void ViewGraph(ListBox listBox)
        {
            for (int i = 0; i < n; i++)
            {
                string line = "";
                for (int j = 0; j < n; j++)
                    line += $" {matrix[i, j]}  ";
                listBox.Items.Add(line);
            }
            listBox.Items.Add("");
        }

        public static void Refresh()
        {
            pctBx.Image = bmp;
        }

        public static void Clear()
        {
            grp.Clear(color);
        }
    }
}
