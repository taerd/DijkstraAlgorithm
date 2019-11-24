using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    class Edge
    {
        public int From { get; private set; }
        public int To { get; private set; }
        public decimal Value { get; private set; }
        public Edge(int from , int to, decimal val)
        {
            From = from;
            To = to;
            Value = val;
        }
    }
}
