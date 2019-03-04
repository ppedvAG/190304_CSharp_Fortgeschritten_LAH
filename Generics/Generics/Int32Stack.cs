using System;

namespace Generics
{
    class Int32Stack
    {
        public Int32Stack() : this(4) { }
        public Int32Stack(int capacity)
        {
            data = new int[capacity];
        }

        private int[] data;
        private int position;

        // LIFO -> Push() und Pop()

        public void Push(int item)
        {
            if (position == data.Length)
            {
                int[] newData = new int[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
            }
            data[position++] = item;
        }

        public int Pop()
        {
            if (position == 0)
                throw new InvalidOperationException("Stack ist leer");
            return data[--position];
        }
    }
}
