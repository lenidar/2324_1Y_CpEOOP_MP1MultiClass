using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2324_1Y_CpEOOP_MP1MultiClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BINGOCard> bingoCards = new List<BINGOCard>();
            int displayedCard = 0;
            char uInput = ' ';

            bingoCards.Add(new BINGOCard());
            while (true)
            {
                bingoCards[displayedCard].CardDisplay();
                Console.Write("\nWhat do you want to do? <L or R>: ");
                uInput = Console.ReadKey().KeyChar;

                switch (uInput)
                {
                    case 'l':
                        displayedCard--;
                        break;
                    case 'r':
                        displayedCard++;
                        break;
                }

                if (displayedCard == -1
                    || displayedCard == bingoCards.Count())
                {
                    bingoCards.Add(new BINGOCard());
                    displayedCard = bingoCards.Count() - 1;
                }
                Console.Clear();
            }
        }
    }
}
