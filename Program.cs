using System.Collections;

namespace ConsoleApp1
{

    internal class ArrayListCustom<T>
    {
        private T[] items;
        private int iterator;
        private const int defaultCapacity = 10;


        public ArrayListCustom()
        {
            items = new T[defaultCapacity];
            iterator = 0;
        }

        public void Add(T value)
        {
            if (iterator == items.Length)
                ResizeArray();

            items[iterator] = value;
            iterator++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= iterator)
                throw new IndexOutOfRangeException("Index is out of range");

            for (int i = index; i < iterator - 1; i++)
                items[i] = items[i + 1];

            iterator--;
        }

        public int Count { get { return iterator; } }

        public void Clear()
        {
            items = new T[defaultCapacity];
            iterator = 0;
        }

        public T GetElement(int index)
        {
            if (index < 0 || index >= iterator)
                throw new IndexOutOfRangeException("Index is out of range");

            return items[index];
        }

        private void ResizeArray()
        {
            int newCapacity = items.Length * 2;
            T[] newArray = new T[newCapacity];
            Array.Copy(items, newArray, items.Length);
            items = newArray;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayListCustom<string> fruits = new ArrayListCustom<string>();
            fruits.Add("Banana");
            fruits.Add("Strawberry");
            fruits.Add("Mangos");


            // Cannot use foreach because the custom list implementation does not implement the Iterator to iterate trough : 
            //foreach (var fruit in fruits)
            //{

            //}


            // Instead we go for a basic for loop : 
            for (int i = 0; i < fruits.Count; i++)
                Console.WriteLine(fruits.GetElement(i));

            Console.WriteLine($"Total items : {fruits.Count}");

            fruits.Clear();
            Console.WriteLine("Clear elements fruits");

            Console.WriteLine($"Total items : {fruits.Count}");
        }
    }
}
