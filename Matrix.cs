using System;
using System.IO;

namespace DijkstraAlgorithm
{
    class Matrix
    {
        public decimal[,] Data { get; private set; }
        public int Size { get; private set; }


        private void GetSize(StreamReader f)
        {
            Size = 0;
            while (f.ReadLine() != null)
            {
                Size++;
            }
            f.Close();
        }
        public Matrix(string filename)
        {
            StreamReader f = new StreamReader(filename);

            GetSize(f);
            Data = new decimal[Size, Size];
            string s;
            string[] buf;
            int i = 0;

            f = new StreamReader("data.txt");

            while ((s = f.ReadLine()) != null)
            {
                buf = s.Split(' ');
                for (int j = 0; j < Size; j++)
                {
                    Data[i,j] = Convert.ToDecimal(buf[j]);
                    //Console.Write(" {0}", Data[i, j]);
                }
                //Console.WriteLine();
                i++;
            }

            f.Close();
        }


    }
}
