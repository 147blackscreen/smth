using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnObjects
{
    class List
    {
        private object[] _data;
        public object this[int index] { 
            get
            {
                if(index < 0 || index >= count) throw new IndexOutOfRangeException();

                return _data[index];
            }
            set
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();

                _data[index] = value;
            }
        }
        private int capacity;
        private int count;
        public int Count { get { return count; } }
        private int savedCapacity;

        public List()
        {
            capacity = 10;
            _data = new object[capacity];
            savedCapacity = capacity;
        }

        public List(int count)
        {
            capacity = count;
            _data = new object[capacity];
            savedCapacity = capacity;
        }


        private void ReWrite()
        {
            capacity *= 2;
            object[] tmp = new object[capacity];

            for (int i = 0; i < count; i++)
            {
                tmp[i] = _data[i];
            }

            _data = tmp;
        }

        public void ShowItems()
        {
            Console.WriteLine("------");
            int i = 0;
            foreach (object item in _data)
            {
                if (item == null)
                    break;
                Console.WriteLine($"Item {i}: {item}");
                i++;
            }
        }


        public void Add(object item)
        {
            if(count == capacity)
            {
                ReWrite();
            }
            _data[count++] = item;
        }

        public bool Insert(int index, object item)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine("index out of range.");

                return false;
            }

            if (count == capacity)
            {
                ReWrite();
            }

            object[] tmp = new object[capacity];
            count++;

            for (int i = 0; i < index; i++)
            {
                tmp[i] = _data[i];
            }
            tmp[index] = item;
            index++;
            for (int i = index; i < count; i++)
            {
                tmp[i] = _data[i - 1];
            }

            _data = tmp;

            return true;
        }

        public bool Remove(object item)
        {
            
            bool res = false;
            int index = 0;

            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i] != null)
                {
                    if (_data[i].Equals(item))
                    {
                        index = i;
                        res = true;
                        break;
                    }
                }
                
            }

            if (!res)
                return false;

            object[] tmp = new object[capacity];

            for (int i = 0, j = 0; i < count; i++)
            {
                if (i != index)
                {
                    tmp[j] = _data[i];
                    j++;
                }
            }

            _data = tmp;

            return res;
        }

        public bool RemoveAt(int index)
        {
            if(index < 0 || index >= count)
                return false;

            object[] tmp = new object[capacity];

            for (int i = 0, j = 0; i < count; i++)
            {
                if(i!=index)
                {
                    tmp[j] = _data[i];
                    j++;
                }
            }

            _data = tmp;

            return true;
        }

        public void Clear()
        {
            capacity = savedCapacity;
            _data = new object[capacity];
            count = 0;
        }

        public bool Contains(object item)
        {
            if(item == null) return false;
            foreach(object itemIn in _data)
            {
                if(itemIn != null)
                {
                    if (itemIn.Equals(item)) return true;
                }
            }
            return false;
        }

        public int IndexOf(object item)
        {
            if (item == null) throw new NullReferenceException();


            for (int i = 0; i < count; i++)
            {
                if (_data[i] != null)
                {
                    if (_data[i].Equals(item))
                    {
                        return i;
                    }
                }
            }

            return -1;

        }

        public object[] ToArray()
        {
            object[] array = new object[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = _data[i];
            }
            return array;
        }

        public void Reverse()
        {
            object tmp;

            for (int i = 0; i < count/2; i++)
            {
                tmp = _data[i];
                _data[i] = _data[count - (i + 1)];
                _data[count - (i + 1)] = tmp;
            }
        }
    }
}
