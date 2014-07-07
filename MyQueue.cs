using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueue
{
    class MyQueue
    {
        private Stack<int> s1, s2;
        public int Count { get; private set; }

        public MyQueue()
        {
            s1 = new Stack<int>();
            s2 = new Stack<int>();
            Count = 0;
        }

        public void EnQueue(int data)
        {
            s1.Push(data);
            Count++;
        }

        public int DeQueue()
        {
            if (s2.Count == 0)
            {
                //throw an exception when s1 is empty
                if(s1.Count == 0) throw new System.InvalidOperationException();
                //Pop elements from s1 and push into s2
                while(s1.Count>0) s2.Push(s1.Pop());
            }
            Count--;
            return s2.Pop();
        }

        public new String ToString()
        {
            if (s1.Count == 0 && s2.Count == 0) throw new System.InvalidOperationException();
            StringBuilder sb = new StringBuilder();
            foreach (int temp in s1) sb.Append(temp + " ");
            Stack<int> s3 = new Stack<int>(s2);
            foreach (int temp in s3) sb.Append(temp + " ");
            return sb.ToString();
        }

    }
}
