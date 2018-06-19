using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy
{
    class Edge<T>
    {
        public enum EdgeDirection
        {
            In,
            Bidirectional,
            Out
        };
        private Vertex<T> _source;
        private Vertex<T> _destination;
        private int _weight;
        private EdgeDirection _direction;

        internal Vertex<T> Destination
        {
            get
            {
                return _destination;
            }

            set
            {
                _destination = value;
            }
        }

        internal Vertex<T> Source
        {
            get
            {
                return _source;
            }

            set
            {
                _source = value;
            }
        }

        public int Weight
        {
            get
            {
                return _weight;
            }

            set
            {
                _weight = value;
            }
        }

        private EdgeDirection Direction
        {
            get
            {
                return _direction;
            }

            set
            {
                _direction = value;
            }
        }

        public Edge()
        {
            _source = null;
            _destination = null;
            _weight = -1;
            _direction = EdgeDirection.Bidirectional;
        }

        public Edge(Vertex<T> source, Vertex<T> destination, int weight = 0,
            EdgeDirection direction = EdgeDirection.Bidirectional)
        {
            _source = source;
            _destination = destination;
            _weight = weight;
            _direction = direction;
        }
    }
}
