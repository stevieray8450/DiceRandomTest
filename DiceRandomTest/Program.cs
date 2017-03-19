using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRandomTest
{
    class Die
    {
        private int position;
        private int face;

        public int Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public int Face
        {
            get
            {
                return this.face;
            }
            set
            {
                this.face = value;
            }
        }

        public Die(int pos)
        {
            this.position = pos;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Die> dieList = new List<Die>();

            for (int i = 1; i <= 5; i++)
            {
                dieList.Add(new Die(i));
            }

            Random intRand = new Random(DateTime.Now.Millisecond);

            foreach(Die d in dieList)
            {
                d.Face = intRand.Next(1, 7);
                Console.WriteLine("Die {0} value: {1}", d.Position, d.Face);
            }

            List<int> dieFaceList = new List<int>();

            foreach(Die d in dieList)
            {
                dieFaceList.Add(d.Face);
            }

            var dict = new Dictionary<int, int>();

            foreach(var value in dieFaceList)
            {
                if (dict.ContainsKey(value))
                    dict[value]++;
                else
                    dict[value] = 1; 
            }

            foreach(var pair in dict)
            {
                Console.WriteLine("Value {0} occured {1} times.", pair.Key, pair.Value);
            }
        }
    }
}
