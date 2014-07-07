using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeeksForGeeks;

namespace StacksAndQueue
{
    class SetofStacks
    {
        private int current;
        public int Count { get; private set; }
        private int StackSize;
        StacksUsingArrays<int>[] set;

        public SetofStacks() 
        {
            current = -1;
            Count = 0;
            StackSize = 5;

            set = new StacksUsingArrays<int>[5];
            for (int i = 0; i < 5; i++)
            {
                set[i] = new StacksUsingArrays<int>(5);
            }
        }

        public int Peek()
        {
            if (Count == 0) throw new System.NullReferenceException();
            return set[current].peek();
        }

        public void Push(int data)
        {
            if (Count == 0 || set[current].Count == StackSize) current++;   //Completely empty or current stack is full
            if (current == StackSize) throw new System.OverflowException(); //We filled all the stacks, throw exception
            set[current].push(data);
            Count++;

        }

        public int Pop()
        {
            if (Count == 0) throw new System.NullReferenceException();
            int data = set[current].pop();
            if (set[current].Count == 0) current--;
            Count--;
            return data;
        }

        public int ElementAt(int k)
        {
            if(Count == 0) throw new System.NullReferenceException();
            if(k < 0 || k > (Count)) throw new System.ArgumentOutOfRangeException();
            int fStack =  (k-1) / StackSize;
            int felem = k - fStack * StackSize;
            return set[fStack].ElementAt(felem);
        }

        public new String ToString()
        {
            if(Count == 0) throw new System.NullReferenceException();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= current; i++)
            {
                sb.Append("Elements in Stack " + i + ": " + set[i].ToString() + "\n");
            }
            return sb.ToString();
        }
    }
}
