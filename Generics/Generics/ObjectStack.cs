using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class ObjectStack
    {
        public ObjectStack() : this(4) { }
        public ObjectStack(int capacity)
        {
            data = new object[capacity];
        }

        private object[] data;
        private int position;

        // LIFO -> Push() und Pop()

        public void Push(object item)
        {
            if(position == data.Length)
            {
                object[] newData = new object[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
            }
            data[position++] = item;
        }

        public object Pop()
        {
            if (position == 0)
                throw new InvalidOperationException("Stack ist leer");
            return data[--position];
        }
    }
}
