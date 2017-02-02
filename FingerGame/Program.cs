using System;
using System.Collections.Generic;

namespace FingerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Turn> allT = new List<Turn>();
            List<Turn> ToProcess = new List<Turn>();

            Player P1 = new Player("P1",1, 1);
            Player P2 = new Player("P2",1, 1);
            Turn initT = new Turn(P1, P2);
            int count = 0;
            allT = initT.Do();
            ToProcess.AddRange(allT);

            bool AllProcessed = false;

            while (!AllProcessed)
            {
                List<Turn> inter = new List<Turn>();
                foreach (Turn t in ToProcess)
                {
                    var returnedList = t.Do();

                    foreach (Turn item in returnedList)
                    {
                        if (!allT.Contains(item))
                        {
                            allT.Add(item);
                            inter.Add(item);
                        }
                    }
                }
                ToProcess = inter;
                AllProcessed = ToProcess.Count == 0;
                Console.WriteLine("tour: " + count);
                count++;
            }
            Console.ReadLine();
        }
    }
}
