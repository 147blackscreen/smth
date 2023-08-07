using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnObjects
{
    class OwnStack
    {
        private int capacity;
        private int _count;
        public int Count { get { return _count; } }

        private object[] _dataStack;
        public OwnStack() {
            capacity = 10;
            _dataStack = new object[capacity];
            _count = 0;
        }
        public OwnStack(int size)
        {
            capacity = size;
            _dataStack = new object[capacity];
            _count = 0;
        }

        public void ShowStack()
        {
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine($"Item {i}: {_dataStack[i]}");
            }
        }
        public bool Push(object item)
        {
            if(item == null) return false;

            if (_count == capacity) return false;

            Console.WriteLine($"Push: {item}");
            _count++;

            _dataStack[_count-1] = item;

            return true;
        }

        public object Pop()
        {
            if (_count == 0) return false;

            object tmp = _dataStack[_count - 1];

            Console.WriteLine($"Push: {tmp}");

            _dataStack[_count - 1] = null;
            _count--;

            return tmp;
        }

        public bool Contains(object item)
        {
            if (item == null) return false;

            for (int i = 0; i < _count; i++)
            {
                if (_dataStack[i].Equals(item)) return true;
            }

            return false;
        }

        public object Peek()
        {
            return _dataStack[_count - 1];
        }

        public void Clear()
        {
            _dataStack = new object[capacity];
            _count = 0;

        }
        public object[] ToArray()
        {
            object[] tmp = new object[_count];
            for (int i = 0; i < _count; i++)
            {
                tmp[i] = _dataStack[i];
            }
            return tmp;
        }
    }
}

/*
     Стек
        Принцип LIFO.
        методи:
            Clear() +
            bool Contains(object) +
            object Peek() +
            ToArray() +
            Push(object) +
            object Pop(). +
        Свойство Count. 
 */
