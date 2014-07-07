using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeeksForGeeks;

namespace StacksAndQueue
{
    class Program
    {
        private Stack1<int> s;
        private Stack1<int> s2;

        public Program()
        { 
            s = new Stack1<int>();
            s2 = new Stack1<int>();
        }

        public int Peek()
        {
            return s.peek();
        }

        public int Pop()
        {
            int data = s.pop();
            if (data == s2.peek()) s2.pop();
            return data;
        }

        public void Push(int data)
        {
            if (s.Size == 0)
            {
                s.push(data);
                s2.push(data);
                return;
            }
            s.push(data);
            if (data <= s2.peek()) s2.push(data);
        }

        override
        public String ToString()
        {
            return s.toString();
        }

        public int min()
        {
            return s2.peek();
        }

        public void sortStack(Stack<int> s)
        {
            if (s.Count <= 1) return;
            
            Stack<int> s1 = new Stack<int>();
            while (s.Count > 0)
            {
                if (s1.Count == 0) s1.Push(s.Pop());
                else
                {
                    if (s.Peek() <= s1.Peek()) s1.Push(s.Pop());
                    else
                    {
                        int temp = s.Pop();
                        while (s1.Count > 0 && s1.Peek() < temp) s.Push(s1.Pop());
                        s1.Push(temp);
                    }
                }
            }
            while (s1.Count > 0) s.Push(s1.Pop());
        }
    }
}
