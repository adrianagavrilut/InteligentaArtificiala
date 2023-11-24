using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06C_11_17_AOP
{
    public abstract class GenericList<T>
    {
        protected T[] values;
        protected int bufferSize = 5;
        protected int count;

        public GenericList()
        {
            values = new T[bufferSize];
            count = 0;
        }

        public virtual void Push(T value)
        {
            if (count < values.Length)
            {
                values[count] = value;
                count++;
            }
            else
            {
                T[] tmp = new T[values.Length + bufferSize];
                for (int i = 0; i < count; i++)
                    tmp[i] = values[i];
                tmp[count] = value;
                count++;
                values = tmp;
            }
        }

        public abstract T Pop();

        protected bool CheckForMemory()
        {
            if ((values.Length - count) >= bufferSize)
                return true;
            return false;
        }

        public override string ToString()
        {
            string toR = "";
            for (int i = 0; i < count; i++)
                toR += values[i].ToString() + " ";
            return toR.Trim();
        }

        public virtual string Debug()
        {
            string toR = "";
            foreach (T value in values)
                toR += value.ToString() + " ";
            return toR.Trim();

        }


        public virtual bool IsEmpty()
        {
            return values.Length == 0;
        }
    }

    public class MyStack<T> : GenericList<T>
    {
        public override T Pop()
        {
            T toR = values[count - 1];
            count--;
            if (CheckForMemory())
            {
                T[] tmp = new T[values.Length - bufferSize];
                for (int i = 0; i < tmp.Length; i++)
                {
                    tmp[i] = values[i];
                }
                values = tmp;
            }
            return toR;
        }

        public void ReleaseMemory()
        {
            T[] tmp = new T[values.Length - bufferSize];

        }
    }

    public class MyQueue<T> : GenericList<T>
    {
        public override T Pop()
        {
            T tor = values[0];
            for (int i = 1; i < count; i++)
                values[i - 1] = values[i];
            count--;

            if (CheckForMemory())
            {
                T[] tmp = new T[values.Length - bufferSize];
                for (int i = 0; i < count; i++)
                {
                    tmp[i] = values[i];
                }
                values = tmp;
            }
            return tor;


        }
    }
}
