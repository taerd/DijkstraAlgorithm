using System;

namespace DijkstraAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix mtr = new Matrix("data.txt");//заполнение массива элементами из filename

            /*
             * Console.WriteLine("Write the start and end vertex from 1");
            string input;
            string [] buf;
            int start;
            int end;

            input = Console.ReadLine();
            buf = input.Split(' ');
            start = Convert.ToInt32(buf[0]);
            end = Convert.ToInt32(buf[1]);
            */

            Dijkstra dijkstra = new Dijkstra(mtr.Data,mtr.Size);
            try 
            {
                Console.WriteLine(dijkstra.CalcShortesWay(3, 0));
            }
            catch(IndexOutOfRangeException e)
            {
                Console.Write($"{e.GetType().Name} : {3} or {0} is out of graph or equals");
            }

            try
            {
                Console.WriteLine(dijkstra.CalcShortesWay(0, 2));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.Write($"{e.GetType().Name} : {0} or {2} is out of graph or equals");
            }
            Console.ReadKey();

        }

    }
}
