using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OwnObjects
{
    class Node
    {
        public Node _next;
        public object _data;
        public Node(object data)
        {
            _data = data;
            _next = null;
        }

        public void Add(object data)
        {
            _next = new Node(data);
        }
    }
    class SingleList
    {
        private Node _head;
        public object First { get { return _head._data; } }


        private Node _tail;
        public object Last { get { return _tail._data; } }


        private int count;
        public int Count { get { return count; }}

        public SingleList()
        {
            count = 0;
            _head = null;
            _tail = null;
        }
        
        public SingleList(object item) 
        {
            count = 1;
            _head = new Node(item);
            _tail = _head;
        }

        public void Add(object item)
        {
            if(item == null) throw new NullReferenceException();

            if(_head == null)
            {
                _head = new Node(item);
                _tail = _head;
                count = 1;
                return;
            }

            _tail.Add(item);
            _tail = _tail._next;

            count++;

        }

        public void ShowItems()
        {
            Console.WriteLine("----------------");
            Node tmp = _head;
            int index = 0;
            while (tmp != null)
            {
                Console.WriteLine($"Item {index}: {tmp._data}");
                index++;
                tmp = tmp._next;
            }

        }

        public void AddFirst(object item)
        {
            if(item == null) throw new NullReferenceException();

            Node tmp = new Node(item);
            tmp._next = _head;
            _head = tmp;

            count++;
        }

        public bool Insert(int index, object item)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine("index out of range.");

                return false;
            }

            if (index == 0)
            {
                Console.WriteLine("You have an method to insert item at First 'AddFirst'");
                return false;
            }

            Node tmp = _head;
            for (int i = 0; i < count; i++)
            {
                if (i == index - 1)
                {
                    Node tmpNext = new Node(item);
                    tmpNext._next = tmp._next;
                    tmp._next = tmpNext;
                    break;
                }

                tmp = tmp._next;
            }

            return true;
        }

        public void Clear()
        {
            count = 0;
            _head = null;
            _tail = null;
        }



        public bool Contains(object item)
        {
            if (item == null) return false;

            int index = 0;
            Node tmp = _head;

            while(tmp != null)
            {
                if (tmp._data.Equals(item))
                {
                    return true;
                }
                index++;
                tmp = tmp._next;
            }
            return false;
        }

        public object[] ToArray()
        {
            object[] array = new object[count];

            Node tmp = _head;
            
            for (int i = 0; i < count; i++)
            {
                array[i] = tmp._data;
                tmp = tmp._next;
            }
            return array;
        }
    }
}

