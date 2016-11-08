using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class GenericStack<T>
    {
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        protected Node _head;
        protected int _size;

        public bool IsEmpty
        {
            get
            {
                return _head == null;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public void AddToFront(T GenericData)
        {
            Node oldHead = _head;

            _head = new Node();

            _head.Data = GenericData;

            _head.Next = oldHead;

            _size++;
        }

        public T RemoveFromFront()
        {
            T returnData = _head.Data;

            _head = _head.Next;

            _size--;

            return returnData;
        }

        //Constructor
        public GenericStack()
        {
            _head = null;
            _size = 0;
        }
    }
}
