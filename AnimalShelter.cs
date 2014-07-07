using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueue
{
    class AnimalShelter
    {
        LinkedList<int> Dogs;
        LinkedList<int> Cats;
        public int Count { get; private set; }
        public AnimalShelter()
        {
            Dogs = new LinkedList<int>();
            Cats = new LinkedList<int>();
            Count = 0;
        }

        public void Enqueue(bool isDog)
        {
            if (isDog) Dogs.AddLast(++Count);
            else Cats.AddLast(++Count);
        }

        public String DeQueue()
        {
            if (Cats.Count == 0 && Dogs.Count == 0) throw new System.InvalidOperationException();
            if (Cats.Count == 0) return DeQueue(true);
            if (Dogs.Count == 0) return DeQueue(false);

            if (Dogs.First() <= Cats.First()) return DeQueue(true);
            else return DeQueue(false);
        }
    
        public String DeQueue(bool isDog)
        {
            if (isDog)
            {
                if (Dogs.Count == 0) throw new System.InvalidOperationException();
                int ret = Dogs.First();
                Dogs.RemoveFirst();
                Count--;
                return "DOG: " + ret;
            }
            else
            {
                if (Cats.Count == 0) throw new System.InvalidOperationException();
                int ret = Cats.First();
                Cats.RemoveFirst();
                Count--;
                return "CAT: " + ret;
            }

        }

        public new String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Dogs: ");
            foreach (int temp in Dogs) sb.Append(temp + " ");
            sb.Append("\n");
            sb.Append("Cats: ");
            foreach (int temp in Cats) sb.Append(temp + " ");
            sb.Append("\n");
            return sb.ToString();
        }
    }
}
