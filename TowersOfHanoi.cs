using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueue
{
    public class TowersOfHanoi
    {
        public int size { get; private set; }
        Stack<int> s1,s2,s3;

        public TowersOfHanoi(int size) 
        { 
            this.size = size;
            s1 = new Stack<int>();
            s2 = new Stack<int>();
            s3 = new Stack<int>();
            for (int i = size; i > 0; i--) s1.Push(i);
        }
        public TowersOfHanoi() 
        { 
            size = 5;
            s1 = new Stack<int>();
            s2 = new Stack<int>();
            s3 = new Stack<int>();
            for (int i = size; i > 0; i--) s1.Push(i);
        }

        public new String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Elements in Tower 1: ");
            foreach (int temp in s1) sb.Append(temp + " ");
            sb.Append("\n");
            sb.Append("Elements in Tower 2: ");
            foreach (int temp in s2) sb.Append(temp + " ");
            sb.Append("\n");
            sb.Append("Elements in Tower 3: ");
            foreach (int temp in s3) sb.Append(temp + " ");
            sb.Append("\n");
            return sb.ToString();
        }

        public void move()
        {
            move(s1, s3, s2, size);
        }

        private void move(Stack<int> source, Stack<int> destination, Stack<int> temp, int numOfElem)
        {
            if (numOfElem == 0) return;
            move(source, temp, destination, numOfElem-1);     //Move n-1 elements to temp buffer
            destination.Push(source.Pop());                   //Move the bottom element to destination  
            move(temp, destination, source, numOfElem-1);     //Move the n-1 elemetns from temp buffer to destination  
        }


    }
}
