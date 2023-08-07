using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnObjects
{
    class TwoNode
    {
        public TwoNode _next;
        public TwoNode _prev;

        public object _data;
        public TwoNode(object data)
        {
            _data = data;
            _next = null;
            _prev = null;
        }

        public void Add(object data)
        {
            _next = new TwoNode(data);
            _next._prev = this;
        }
    }
    class TwoList
    {
        private TwoNode _head;
        public object First { get { return _head._data; } }


        private TwoNode _tail;
        public object Last { get { return _tail._data; } }


        private int count;
        public int Count { get { return count; } }

        public TwoList()
        {
            count = 0;
            _head = null;
            _tail = null;
        }

        public TwoList(object item)
        {
            count = 1;
            _head = new TwoNode(item);
            _tail = _head;
        }

        public void Add(object item)
        {
            if (item == null) throw new NullReferenceException();

            if (_head == null)
            {
                _head = new TwoNode(item);
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
            TwoNode tmp = _head;
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
            if (item == null) throw new NullReferenceException();

            TwoNode tmp = new TwoNode(item);
            tmp._next = _head;
            _head._prev = tmp;
            _head = tmp;

            count++;
        }

        public bool Remove(object item)
        {
            if(item == null) throw new NullReferenceException();

            TwoNode tmp = _head;

            for (int i = 0; i < count; i++)
            {
                if (tmp._data.Equals(item))
                {
                    tmp._prev._next = tmp._next;
                    tmp._next._prev = tmp._prev;
                    count--;
                    return true;
                }
                tmp = tmp._next;
            }

            return false;
        }

        public void RemoveFirst()
        {
            if (count == 0) return;

            if(count == 1)
            {
                _head._data = null;
                _head = null;
                _tail = null;
                count = 0;
                return;
            }

            _head = _head._next;
            _head._prev = null;
            count--;
        }

        public void RemoveLast()
        {
            if (count == 0) return;

            if (count == 1)
            {
                _head._data = null;
                _head = null;
                _tail = null;
                count = 0;
                return;
            }

            _tail = _tail._prev;
            _tail._next = null;

            count--;
        }

        
        public bool Contains(object item)
        {
            if (item == null) return false;

            int index = 0;
            TwoNode tmp = _head;

            while (tmp != null)
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

            TwoNode tmp = _head;

            for (int i = 0; tmp!=null; i++)
            {
                array[i] = tmp._data;
                tmp = tmp._next;
            }
            return array;
        }
        public void Clear()
        {
            count = 0;
            _head = null;
            _tail = null;
        }
    }
}

/*
     Двозв'язковий список.
    Являє собою елементи, пов'язані один з одним через посилання на наступний і попередній елементи.
    Сам список зберігає перший та останній елементи.
    Методи
    Add(object), +
    AddFirst(object), +
    Remove(object), +
    RemoveFirst(), +
    RemoveLast(), + 
    bool Contains(object), +
    ToArray(), +
    Clear() +
    Властивості – Count, First, Last – тільки для читання.
 */
