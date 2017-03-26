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
        // create a list for dice
        public List<Die> dieList = new List<Die>();
        public List<int> dieFaceList = new List<int>();
        public Random intRand = new Random(DateTime.Now.Millisecond);
        public Dictionary<int, int> dict = new Dictionary<int, int>();

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

        public Die()
        {
            for (int i = 1; i <= 5; i++)
            {
                dieList.Add(new Die(i));
            }
        }

        public Die(int pos)
        {
            this.position = pos;
            this.face = rollDie(pos);

        }

        public void rollDice()
        {
            foreach (Die d in dieList)
            {
                d.Face = intRand.Next(1, 7);
                Console.WriteLine("Die {0} value: {1}", d.Position, d.Face);
            }

            foreach (Die d in dieList)
            {
                dieFaceList.Add(d.Face);
            }
        }

        public int rollDie(int position)
        {
            return intRand.Next(1, 7);
        }

        public void checkScoreEligibility()
        {
            foreach (var pair in dict)
            {
                Console.WriteLine("Value {0} occured {1} times.", pair.Key, pair.Value);

                switch (pair.Value)
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

            if (dict.Keys.Contains(1) && dict.Keys.Contains(2) && dict.Keys.Contains(3) && dict.Keys.Contains(4))
            {
                Console.WriteLine("Eligible for large straight scoring.");
                Console.WriteLine("Eligible for small straight scoring.");
            }
            else if (dict.Keys.Contains(2) && dict.Keys.Contains(3) && dict.Keys.Contains(4) && dict.Keys.Contains(5))
            {
                Console.WriteLine("Eligible for large straight scoring.");
                Console.WriteLine("Eligible for small straight scoring.");
            }
            else if (dict.Keys.Contains(3) && dict.Keys.Contains(4) && dict.Keys.Contains(5) && dict.Keys.Contains(6))
            {
                Console.WriteLine("Eligible for large straight scoring.");
                Console.WriteLine("Eligible for small straight scoring.");
            }
        }
    }

    class Scoreboard
    {
        public bool oneComplete { get; set; }
        public bool twoComplete { get; set; }
        public bool threeComplete { get; set; }
        public bool fourComplete { get; set; }
        public bool fiveComplete { get; set; }
        public bool sixComplete { get; set; }

        public bool threeKindComplete { get; set; }
        public bool fourKindComplete { get; set; }
        public bool yahtzeeComplete { get; set; }
        public bool smallStraightComplete { get; set; }
        public bool largeStraightComplete { get; set; }
        public bool fullHouseComplete { get; set; }
        public bool chanceComplete { get; set; }

        public void buildScoreBoard()
        {
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}\n", "Ones", "Twos", "Threes", "Fours", "Fives", "Sixes");
            Console.WriteLine("{0, -10} {1,-10}", "3", "6");
            Console.WriteLine("*----------------------------------------------------------------*");
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20}\n", "3 of a kind", "4 of a kind", "Full house", "Sm.Straight",
                "Lg.Straight", "Yahtzee", "Chance");
            Console.WriteLine();
        }
    }

    class TurnScore
    {
        public bool isLargeStraight { get; set; }
        public bool isSmallStraight { get; set; }
        public bool is3kind { get; set; }
        public bool is4kind { get; set; }
        public bool isYahtzee { get; set; }

        public int oneScore { get; set; }
        public int twoScore { get; set; }
        public int threeScore { get; set; }
        public int fourScore { get; set; }
        public int fiveScore { get; set; }
        public int sixScore { get; set; }

        public void calcTopScore(int dieFace, int timesRolled)
        {
            switch(dieFace)
            {
                case 1:
                    oneScore = 1 * timesRolled;
                    break;
                case 2:
                    twoScore = 2 * timesRolled;
                    break;
                case 3:
                    threeScore = 3 * timesRolled;
                    break;
                case 4:
                    fourScore = 4 * timesRolled;
                    break;
                case 5:
                    fiveScore = 5 * timesRolled;
                    break;
                case 6:
                    sixScore = 6 * timesRolled;
                    break;
                default:
                    break;
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            //// create a list for dice
            //List<Die> dieList = new List<Die>();

            //// adds five dice objects and defines their corresponding positions (1-5)
            //for (int i = 1; i <= 5; i++)
            //{
            //    dieList.Add(new Die(i));
            //}

            // Random object, seeded by the current millisecond
            //Random intRand = new Random(DateTime.Now.Millisecond);

            // randomizes an integer from 1-6 for each die in the list
            // assigns the value of the roll ("Face" property) to each corresponding die
           
            //foreach (Die d in dieList)
            //{
            //    d.Face = intRand.Next(1, 7);
            //    Console.WriteLine("Die {0} value: {1}", d.Position, d.Face);
            //}

            // creates another list that holds the values of the rolls only
            //List<int> dieFaceList = new List<int>();

            // adds each value of each die rolled to the new list
            //foreach(Die d in dieList)
            //{
            //    dieFaceList.Add(d.Face);
            //}

            //// creates a dictionary that holds the number rolled for each die (key)
            //// and how many times that number was rolled amongst the five dice (value)
            //var dict = new Dictionary<int, int>();

            //// assigns a value (number of time the number rolled showed up in the group
            //// to the key (number rolled)
            //foreach(int value in dieFaceList)
            //{
            //    if (dict.ContainsKey(value))
            //        dict[value]++;
            //    else
            //        dict[value] = 1; 
            //}

            // determines and displays any duplicated numbers in the 5-dice roll
            // switch statement confirms if there is eligibility for 3 & 4-of-a-kinds
            // and Yahtzees (5-of-a-kind)
            //foreach(var pair in dict)
            //{
            //    Console.WriteLine("Value {0} occured {1} times.", pair.Key, pair.Value);
                
            //    switch(pair.Value)
            //    {
            //        case 3:
            //            Console.WriteLine("Value {0} Eligible for 3-of-a-kind scoring", pair.Key);
            //            break; 
            //        case 4:
            //            Console.WriteLine("Value {0} Eligible for 4-of-a-kind scoring", pair.Key);
            //            break;
            //        case 5:
            //            Console.WriteLine("Value {0} eligible for Yahtzee!", pair.Key);
            //            break;
            //        default:
            //            continue;
            //    }
            //}

            //if (dict.Keys.Contains(1) && dict.Keys.Contains(2) && dict.Keys.Contains(3) && dict.Keys.Contains(4))
            //{
            //    Console.WriteLine("Eligible for large straight scoring.");
            //    Console.WriteLine("Eligible for small straight scoring.");
            //}
            //else if (dict.Keys.Contains(2) && dict.Keys.Contains(3) && dict.Keys.Contains(4) && dict.Keys.Contains(5))
            //{
            //    Console.WriteLine("Eligible for large straight scoring.");
            //    Console.WriteLine("Eligible for small straight scoring.");
            //}
            //else if (dict.Keys.Contains(3) && dict.Keys.Contains(4) && dict.Keys.Contains(5) && dict.Keys.Contains(6))
            //{
            //    Console.WriteLine("Eligible for large straight scoring.");
            //    Console.WriteLine("Eligible for small straight scoring.");
            //}

            Scoreboard scoreBoard = new Scoreboard();
            scoreBoard.buildScoreBoard();

            Die dice = new Die();
        }
    }
}
