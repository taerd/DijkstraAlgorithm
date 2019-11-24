using System;

namespace DijkstraAlgorithm
{
    class Dijkstra//можно было не создавать класс ребер а использовать только матрицу смежности
    {

        private Vertex[] Vertex { get; set; }
        private Edge [,] Edges { get; set; }
        private int _size;
        public Dijkstra(decimal [,] mtr,int size)
        {
            _size = size;
            Vertex = new Vertex[_size];//создали массив вершин размера матрицы
            Edges = new Edge[_size,_size];
            for (int i = 0; i < _size; i++)
            {
                Vertex[i] = new Vertex(i);
            }
            CreateEdges(mtr);//создание ребер в графе
        }
        private void CreateEdges(decimal [,]mtr)
        {
            for(int i = 0; i < _size; i++)
            {
                for(int j = 0; j < _size; j++)
                {
                    if(mtr[i,j] > 0)
                    {
                        Edges[i, j] = new Edge(i, j, mtr[i, j]);//создали ребро
                    }
                }
            }
        }
        private Vertex GetMinVertex()
        {
            int i = 0;
            while (i <_size && Vertex[i].IsChecked) i++;//находим первую попавщуюся непомеченную вершину среди всех вершин
            if (i == _size) return null;//если все вершины помеченны
            int min = i;
            while (i < _size)//до i все вершины помечены
            {
                if (Vertex[i].Value < Vertex[min].Value && !Vertex[i].IsChecked)
                {
                    min = i;
                }
                i++;
            }
            if (Vertex[min].Value == decimal.MaxValue) return null;//если вершина недостижима
            return Vertex[min];
        }
        public string CalcShortesWay(int from,int to)//нумерация с 0 вершины
        {
            if (from < 0 || from > _size-1 || to < 0 || to > _size-1 || from==to)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                VertexReset();//очищаем старые значения у вершин
                Vertex[from].Value = 0;
                Step(from);
                if (Vertex[to].Value == decimal.MaxValue) throw new IndexOutOfRangeException();//если вершина оказалась недостижима
                string str = Vertex[to].Path.ToString() + " " + Vertex[to].Value.ToString();
                return str;
            }
        }
        private void VertexReset()
        {
            for(int i=0; i < _size; i++)
            {
                Vertex[i].Value = decimal.MaxValue;
                Vertex[i].Path = i.ToString();
                Vertex[i].IsChecked = false;
            }
        }
        private void Step(int from)
        {
            CheckVertex(from);//изменили значения смежных вершин с from
            Vertex[from].IsChecked = true;
            Vertex NextVertex = GetMinVertex();
            if (NextVertex != null)
            {
                Step(NextVertex.Number);
            }
        }
        private void CheckVertex(int curr)
        {
            for(int j = 0; j < _size; j++)
            {
                if(Edges[curr,j]!=null && Vertex[j].IsChecked == false && Vertex[j].Value > Vertex[curr].Value + Edges[curr,j].Value)
                {
                    Vertex[j].Value = Vertex[curr].Value + Edges[curr, j].Value;
                    Vertex[j].Path = Vertex[curr].Path + Vertex[j].Number.ToString();
                }
            }
        }
    }
}
