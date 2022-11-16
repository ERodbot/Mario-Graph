using Programming.WeightedUndirected;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



namespace Programming.WeightedUndirected
{
    public class GrafoPonderado : MonoBehaviour
    {
        private readonly int _vertices;
        private int _aristas;
        private LinkedList<Edge>[] _adj;

        public GrafoPonderado(int Vertices)
        {
            if (Vertices < 0)
                throw new Exception("El numero de vertices no puede ser negativo");

            this._vertices = Vertices;

            this._aristas = 0;

            _adj = new LinkedList<Edge>[Vertices];

            for (int v = 0; v < Vertices; v++)
            {
                _adj[v] = new LinkedList<Edge>();
            }
        }

        public int V()
        {
            return _vertices;
        }

        public int E()
        {
            return _aristas;
        }

        public void AddEdge(Edge e)
        {
            int v = e.Source();
            int w = e.Target(v);
            _adj[v].AddFirst(e);
            _adj[w].AddFirst(e);
            _aristas++;
        }

        public IEnumerable<Edge> Adj(int v)
        {
            return _adj[v];
        }

        public IEnumerable<Edge> Edges()
        {
            LinkedList<Edge> list = new LinkedList<Edge>();

            for (int v = 0; v < _vertices; v++)
            {
                int selfLoops = 0;

                foreach (Edge e in Adj(v))
                {
                    if (e.Target(v) > v)
                    {
                        list.AddFirst(e);
                    }
                    else if (e.Target(v) == v)
                    {
                        if (selfLoops % 2 == 0)
                            list.AddFirst(e);
                        selfLoops++;
                    }
                }
            }

            return list;
        }

    
    }
}

