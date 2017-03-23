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
            // create a list for dice
            List<Die> dieList = new List<Die>();

            // adds five dice objects and defines their corresponding positions (1-5)
            for (int i = 1; i <= 5; i++)
            {
                dieList.Add(new Die(i));
            }

            // Random object, seeded by the current millisecond
            Random intRand = new Random(DateTime.Now.Millisecond);

            // randomizes an integer from 1-6 for each die in the list
            // assigns the value of the roll ("Face" property) to each corresponding die
            foreach(Die d in dieList)
            {
                d.Face = intRand.Next(1, 7);
                Console.WriteLine("Die {0} value: {1}", d.Position, d.Face);
            }

            // creates another list that holds the values of the rolls only
            List<int> dieFaceList = new List<int>();

            // adds each value of each die rolled to the new list
            foreach(Die d in dieList)
            {
                dieFaceList.Add(d.Face);
            }

            // creates a dictionary that holds the number rolled for each die (key)
            // and how many times that number was rolled amongst the five dice (value)
            var dict = new Dictionary<int, int>();

            // assigns a value (number of time the number rolled showed up in the group
            // to the key (number rolled)
            foreach(int value in dieFaceList)
            {
                if (dict.ContainsKey(value))
                    dict[value]++;
                else
                    dict[value] = 1; 
            }

            // determines and displays any duplicated numbers in the 5-dice roll
            // switch statement confirms if there is eligibility for 3 & 4-of-a-kinds
            // and Yahtzees (5-of-a-kind)
            foreach(var pair in dict)
            {
                Console.WriteLine("Value {0} occured {1} times.", pair.Key, pair.Value);
                
                switch(pair.Value)
                {
                    case 3:
                        Console.WriteLine("Value {0} Eligible for 3-of-a-kind scoring", pair.Key);
                        break; 
                    case 4:
                        Console.WriteLine("Value {0} Eligible for 4-of-a-kind scoring", pair.Key);
                        break;
                    case 5:
                        Console.WriteLine("Value {0} eligible for Yahtzee!", pair.Key);
                        break;
                    default:
                        continue;
                }

            }
        }
    }
}
