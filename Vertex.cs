using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    class Vertex
    {
        public int Number { get; private set; }
        public decimal Value { get; set; }//значение вершины(наименьший путь)
        public bool IsChecked { get; set; }
        public string Path { get; set; }// минимальная последовательность вершин
        public static readonly decimal INFINITY = decimal.MaxValue;
        public Vertex(int i)
        {
            Number = i;
            Value = INFINITY;
            IsChecked = false;
            Path = i.ToString();
        }

    }
}
