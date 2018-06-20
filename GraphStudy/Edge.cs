using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy
{
    class Edge
    {
        public enum EdgeDirection
        {
            In,
            Bidirectional,
            Out
        };
        private int _source;//hash code
        private int _destination;//hash code
        private int _weight;
        private EdgeDirection _direction;

        internal int Destination
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

        internal int Source
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
            _source = -1;
            _destination = -1;
            _weight = -1;
            _direction = EdgeDirection.Bidirectional;
        }

        public Edge(int source, int destination, int weight = 0,
            EdgeDirection direction = EdgeDirection.Bidirectional)
        {
            _source = source;
            _destination = destination;
            _weight = weight;
            _direction = direction;
        }
    }
}
