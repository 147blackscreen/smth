using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnObjects
{
    class MyQueue
    {
        private object[] _dataQueue;
        private int _count;
        public int Count { get { return _count; } }
        private int capacity;
        private int frontIndex;
        private int backIndex;

        public MyQueue()
        {
            capacity = 10;
            _dataQueue = new object[capacity];
            _count = 0;
            frontIndex = 0;
            backIndex = -1;
        }
        public MyQueue(int size)
        {
            capacity = size;
            _dataQueue = new object[capacity];
            _count = 0;
            frontIndex = 0;
            backIndex = -1;
        }


        public void ShowQueue()
        {

            Console.WriteLine("----------------");
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine($"Item {i}: {_dataQueue[backIndex+i]}");
            }
        }
        public bool Enqueue(object item)
        {
            if (item == null) throw new NullReferenceException();

            if(_count == capacity) return false;

            if (_count == 0)
            {
                backIndex = 0;
                _dataQueue[frontIndex] = item;
            }
            else
            {
                frontIndex = (frontIndex + 1) % capacity;

                _dataQueue[frontIndex] = item;
            }

            _count++;

            Console.WriteLine($"Enqueue - {item}");
            return true;
        }

        public object Dequeue()
        {
            if (_count == 0) return null;

            object tmp = _dataQueue[backIndex];
            _dataQueue[backIndex] = null;
            backIndex = (backIndex + 1) % capacity;
            _count--;

            Console.WriteLine($"Dequeue: {tmp}");
            return tmp;
        }

        public void Clear()
        {
            for (int i = 0; i < _count; i++)
            {
                _dataQueue[backIndex + i] = null;
            }
            _count = 0;
            backIndex = 0;
            frontIndex = 0;
        }

        public bool Contains(object item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_dataQueue[backIndex + i].Equals(item))
                    return true;
            }

            return false;
        }

        public object Peek()
        {
            return _dataQueue[backIndex];
        }

        public object[] ToArray()
        {
            if (_count == 0) return null;
            

            object[] array = new object[_count];

            for (int i = 0; i < _count; i++)
            {
                array[i] = _dataQueue[backIndex + i];
            }

            return array;
        }
    }
    /*
          Черга
     Принцип FIFO.
     Методи
     Enqueue(object) +
     object Dequeue() +
     Clear() +
     bool Contains(object) +
     object Peek() +
     ToArray(). +
     Свойство Count. +
      */
}
