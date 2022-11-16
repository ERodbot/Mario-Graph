using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Programming.WeightedUndirected
{
    public class Edge : MonoBehaviour
    {
        private  int origin;
        private  int destiny;
        private Tile Torigin;
        private Tile Tdestiny;
        private  double destinyeight;

        public Edge(int v, int w, double weight)
        {
            this.origin = v;
            this.destiny = w;
            this.destinyeight = weight;
        }

        public double Weight()
        {
            return destinyeight;
        }

        public int CompareTo(Edge that)
        {
            if (this.Weight() < that.Weight())
                return -1;
            else if (this.Weight() > that.Weight())
                return +1;
            else
                return 0;
        }

        public int Source()
        {
            return origin;
        }

        public int Target(int vertexID)
        {
            if (vertexID == origin) return destiny;
            else if (vertexID == destiny) return origin;
            else{
                return -1;
            }
        }

    }
}






    




