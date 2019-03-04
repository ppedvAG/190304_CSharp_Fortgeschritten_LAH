using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class GenericStack<T>
    {
        public GenericStack() : this(4) { }
        public GenericStack(int capacity)
        {
            data = new T[capacity];
        }

        private T[] data;
        private int position;

        // LIFO -> Push() und Pop()

        public void Push(T item)
        {
            if (position == data.Length)
            {
                T[] newData = new T[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
            }
            data[position++] = item;
        }
        public T Pop()
        {
            if (position == 0)
                throw new InvalidOperationException("Stack ist leer");
            return data[--position];
        }

        //// indexer + TAB + TAB
        public T this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        // Indexer mit Tupel
        //public (bool,int) this[(string text,int wert) index]
        //{
        //    get { return data[index.wert]; }
        //    set { data[index.wert] = value; }
        //}
    }
}
