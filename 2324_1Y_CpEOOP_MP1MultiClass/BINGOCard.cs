using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2324_1Y_CpEOOP_MP1MultiClass
{
    internal class BINGOCard
    {
        private Random _rnd = new Random();
        private string[][] _theCard = new string[][] { };

        public BINGOCard()
        {
            _theCard = ConvertIntArrToStringArr(GenerateCard());
        }

        public void CardDisplay()
        {
            for (int y = 0; y < 21; y++)
                Console.Write("=");
            Console.WriteLine();
            Console.WriteLine("| B | I | N | G | O |");
            for (int y = 0; y < 21; y++)
                Console.Write("=");
            Console.WriteLine();
            for (int x = 0; x < _theCard.Length; x++)
            {
                Console.Write("|");
                for (int y = 0; y < _theCard[x].Length; y++)
                    Console.Write(_theCard[y][x] + "|");
                Console.WriteLine();
                for (int y = 0; y < 21; y++)
                    Console.Write("=");
                Console.WriteLine();
            }
        }

        private int[][] GenerateCard()
        {
            // initialize the card
            int[][] tempCard = new int[5][];
            int temp = -1;

            // initialize internal lengths
            for (int x = 0; x < tempCard.Length; x++)
            {
                tempCard[x] = new int[5];
                for (int y = 0; y < tempCard[x].Length; y++)
                    tempCard[x][y] = -1;
            }

            // placing the numbers to the card
            // remember the outer array is the column and not the row
            //for (int x = 0; x < tempCard.Length; x++)
            //    for (int y = 0; y < tempCard[x].Length; y++)
            //    {
            //        temp = GenerateNumber(x);
            //        if (RemoveDuplicates(tempCard[x], temp))
            //            y--;
            //        else
            //            tempCard[x][y] = temp;
            //    }

            for (int x = 0; x < tempCard.Length; x++)
            {
                tempCard[x] = GenerateNumbersWithoutDuplicate(x);
            }

            //TestDisplay(tempCard);
            //Console.WriteLine();

            return tempCard;
        }

        private int[] GenerateNumbersWithoutDuplicate(int column)
        {
            List<int> nums = new List<int>();
            int[] bNums = new int[5];

            for (int x = 1; x < 16; x++)
                nums.Add(x + (column * 15));

            nums = ShuffleList(nums);

            for (int x = 0; x < bNums.Count(); x++)
            {
                bNums[x] = nums[_rnd.Next(nums.Count())];
                nums.Remove(bNums[x]);
            }

            return bNums;
        }

        private List<int> ShuffleList(List<int> nums)
        {
            List<int> tempArr = new List<int>();
            int temp = 0;

            while (nums.Count > 0)
            {
                temp = _rnd.Next(nums.Count);
                tempArr.Add(nums[temp]);
                nums.RemoveAt(temp);
            }

            return tempArr;
        }
        
        private string[][] ConvertIntArrToStringArr(int[][] tempCard)
        {
            string[][] theCard = new string[tempCard.Length][];

            for (int x = 0; x < tempCard.Length; x++)
            {
                theCard[x] = new string[tempCard[x].Length];
                for (int y = 0; y < tempCard[x].Length; y++)
                {
                    theCard[x][y] = tempCard[x][y] + "";
                    while (theCard[x][y].Length < 3)
                        theCard[x][y] = " " + theCard[x][y];
                }
            }

            theCard[2][2] = "FRE";

            return theCard;
        }
    }
}
