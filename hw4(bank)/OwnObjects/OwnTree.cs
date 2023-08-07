using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnObjects
{
    class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int _data;

        public TreeNode(int data)
        {
            left = null!;
            right = null!;
            _data = data;
        }


    }

    class OwnTree
    {
        private TreeNode _root;
        public int Root { get { return _root._data; } }
        private int _count;
        public int Count { get { return _count; } }

        public OwnTree()
        {
            _root = null!;
            _count = 0;
        }

        public void Add(int item)
        {
            if (_count == 0)
            {
                _root = new TreeNode(item);
                _count++;

                return;
            }

            TreeNode tmp = _root;

            while (true)
            {
                if (item < tmp._data)
                {
                    if (tmp.left != null)
                    {
                        tmp = tmp.left;
                        continue;
                    }

                    tmp.left = new TreeNode(item);
                    _count++;

                    break;
                }
                else
                {
                    if (tmp.right != null)
                    {
                        tmp = tmp.right;
                        continue;
                    }

                    tmp.right = new TreeNode(item);
                    _count++;

                    break;
                }
            }

            Console.WriteLine($"Add Item: {item}");

        }

        public void ShowTree()
        {
            if(Count!=0)
            {
                Console.WriteLine("---- TREE SHOW ----");
                TryGetNextOrBack(_root);
            }
        }

        private bool TryGetNextOrBack(TreeNode current)
        {
            Console.Write(" - "+current._data);

            if (current.left != null)
            {
                TryGetNextOrBack(current.left);
            }

            if (current.right != null)
            {
                TryGetNextOrBack(current.right);
            }

            return true;
        }

        public int[] ToArray()
        {
            int[] tmp = new int[_count];
            int index = 0;
            ToArrayNext(_root, ref index, tmp);

            return tmp;
        }
        private bool ToArrayNext(TreeNode current, ref int index, int[] array)
        {
            array[index] = current._data;
            index++;
            if (current.left != null)
            {
                ToArrayNext(current.left, ref index, array);
            }

            if (current.right != null)
            {
                ToArrayNext(current.right, ref index, array);
            }

            return true;
        }

        public bool Contains(int item)
        {
            if(IfContainsOrNext(_root, item))
            {
                Console.WriteLine("Find element");
                return true;
            }
            return false;
        }

        private bool IfContainsOrNext(TreeNode current, in int item)
        {
            if (item.Equals(current._data)) return true;


            if (current.left != null)
            {
                IfContainsOrNext(current.left, in item);
            }

            if (current.right != null)
            {
                IfContainsOrNext(current.right, in item);
            }

            return true;
        }

        public void Clear()
        {
            _count = 0;
            _root = null!;
        }

        public void ReBalanceTree()
        {
            int[] array = ToArray();
            Sort(array);

            int[] balanced = new int[array.Length];
            int index = 0;
            MakeNewBranch(array, ref index, balanced);

            Console.WriteLine(" ------- BALANCED ARRAY -----");
            foreach (int item in balanced)
            {
                Console.Write(item + " - ");
            }

            Clear();

            foreach (int item in balanced)
            {
                Add(item);
            }
        }


        // switch(i) in for(i<4) in while(end) ; end = false if(middle == currentIndex)
        public void Sort(int[] array)
        {
            int tmp;
            int min;
            int index = 0;
            for (int i = 0; i < _count; i++)
            {
                min = array[i];
                index = i;
                for (int j = i; j < _count; j++)
                {
                    if (array[j] < min)
                    {
                        min = array[j];
                        index = j;
                    }
                }
                tmp = array[i];
                array[i] = min;
                array[index] = tmp;
            }
        }

        //public void test1(ref int[] array)
        //{
        //    array[array.Length-1] = 1;

        //    if (array.Length <= 2) return;
        //    test1(ref array[0..(array.Length-2)]);
        //}
        private bool MakeNewBranch(int[] array, ref int index, int[] balanced)
        {
            int length = array.Length;//% 2 == 0 ? array.Length : array.Length - 1;

            int middle = length / 2;
            int left = middle / 2;
            int right = middle + left;

            if (array.Length == 1)
            {
                if (array[0] != 0)
                {
                    balanced[index++] = array[0];
                    array[0] = 0;
                    return true;
                }
                else
                    return true;
            }

            if (array.Length == 0) return true;

            

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        if (array[middle] != 0)
                        {
                            balanced[index++] = array[middle];
                            array[middle] = 0;
                        }
                        break;

                    case 1:
                        if (array[left] != 0)
                        {
                            balanced[index++] = array[left];
                            array[left] = 0;
                        }
                        break;
                    case 2:
                        if (array[right] != 0)
                        {
                            balanced[index++] = array[right];
                            array[right] = 0;
                        }
                        break;
                }
            }


            MakeNewBranch(array[0..left], ref index, balanced);
            MakeNewBranch(array[left..middle], ref index, balanced);
            MakeNewBranch(array[middle..right], ref index, balanced);
            MakeNewBranch(array[right..array.Length], ref index, balanced);
            return true;
        }
        private int[] MakeRebalance(int[] array)
        {
            int middle = array.Length / 2;
            int left = middle / 2;
            int right = middle + left + 1;

            bool end = true;
            int[] balanced = new int[array.Length];
            balanced[0] = array[middle];
            balanced[1] = array[right];
            balanced[2] = array[left];
            int bIndex = 3;

            int innerIndex = 0;
            int counter = 0;

            if (array.Length <= 3) return balanced;

            while (end)
            {
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            innerIndex = middle + counter + 1;
                            break;
                        case 1:
                            innerIndex = middle - counter - 1;
                            break;
                        case 2:
                            innerIndex = array.Length - 1 - counter;
                            break;
                        case 3:
                            innerIndex = counter;
                            break;
                    }

                    if (IsEnd(innerIndex, middle, right, left))
                        end = false;
                    else
                    {
                        balanced[bIndex] = array[innerIndex];
                        bIndex++;
                    }
                }
                counter++;
            }

            return balanced;
        }

        private bool IsEnd(int index, params int[] array)
        {
            foreach (var item in array)
            {
                if (index == item) return true;
            }
            return false;
        }

        private int GetAverage(int[] array)
        {
            int sum = 0;
            int count = array.Length;
            foreach (int item in array)
            {
                sum += item;
            }

            int averageInArray = sum / count;

            int mayAvarage = array[0];
            int difference = mayAvarage - array[0];
            if (difference < 0) difference *= -1;

            foreach (int item in array)
            {
                int diff = averageInArray - item;
                if (diff < 0) diff *= -1;

                if (diff < difference)
                {
                    difference = diff;
                    mayAvarage = item;
                }
            }

            return mayAvarage;
        }
    }
}

/*
 Дерево
Потрібно реалізувати бінарне дерево пошуку: де кожен вузол може містити ліві та праві вузли – зліва найменші 
елементи, а праворуч – найбільші.
Обхід по дереву має бути рекурсивним. +
Свойства: Root  и Count +
Методы:
Add(int) +
bool Contains(int) +
Clear() +
ToArray(). +
Додатково, на свій страх і ризик: створення дерева, що самобалансується, або методу балансування. 
(Див. AVL-дерево, червоно-чорне дерево).
 */
