using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/****************************
 * 
 * Name: Kenny Han           Date: 4.5.2021
 * 
 * Make the towers of hanoi game 
 * and make it good
 * 
 *
 *********************/
namespace Thats_the_Towers_of_Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.SetWindowSize(60, 3);
            // asking user for number of rings then puts into int varible, also sets the int turns variable
            Console.WriteLine("How many rings do you want to start with?");
            int ringnum = Convert.ToInt32(Console.ReadLine());
            int height = 2 + ringnum;
            int turns = 0;
            Console.Clear();
            Console.SetWindowSize(100, 30);
            //creating 3 peg objects
            Peg peg1 = new Peg(height);
            Peg peg2 = new Peg(height);
            Peg peg3 = new Peg(height);
            setPeg(peg1, ringnum);
            drawBoard(peg1, peg2, peg3);
            // main while loop that plays the game, reapeating until the user completes the game by moving all rings in order to peg3
            while(peg3.Rings.Length != ringnum)
            {
                // asks user where to move
                Console.WriteLine("From what peg do you want to move a ring? (1, 2, 3)");
                int startpeg = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(" On what peg do you want to put it? (1, 2, 3)");
                int endpeg = Convert.ToInt32(Console.ReadLine());
                if( startpeg == endpeg)
                {
                    Console.WriteLine("Don't move to the same place!");
                }
                // checks the start and end pegs to see if the user followed the rules of the game, then swaps the rings then prints it out.
                if( startpeg == 1 && endpeg == 2)
                {
                    if ((peg2.length() == 0 || peg1.size()< peg2.size()) && peg1.length() != 0)
                    {
                        peg2.addRing(peg1.removeRing());
                    }
                    else
                    {
                        Console.WriteLine("Follow the rules!!!\nYou can't put bigger ring on smaller one\nDon't move a ring that doesnt exist (from an empty peg)");
                        Console.ReadKey();
                    }

                }

                if ( startpeg == 1 && endpeg ==3)
                {
                    if ((peg3.length() == 0 || peg1.size() < peg3.size()) && peg1.length() != 0)
                    {
                        peg3.addRing(peg1.removeRing());
                    }
                    else
                    {
                        Console.WriteLine("Follow the rules!!!\nYou can't put bigger ring on smaller one\nDon't move a ring that doesnt exist (from an empty peg)"); Console.ReadKey();
                    }

                    
                }

                if (startpeg == 2 && endpeg == 3)
                {
                    if ( peg2.length() != 0 && (peg3.length() == 0 || peg2.size() < peg3.size())  )
                    {
                        peg3.addRing(peg2.removeRing());
                    }
                    else
                    {
                        Console.WriteLine("Follow the rules!!!\nYou can't put bigger ring on smaller one\nDon't move a ring that doesnt exist (from an empty peg)"); Console.ReadKey();
                    }

                    
                }

                if (startpeg == 2 && endpeg == 1)
                {
                    if ( peg2.length() != 0 && (peg1.length() == 0 || peg2.size() < peg1.size()) )
                    {
                        peg1.addRing(peg2.removeRing());
                    }
                    else
                    {
                        Console.WriteLine("Follow the rules!!!\nYou can't put bigger ring on smaller one\nDon't move a ring that doesnt exist (from an empty peg)"); Console.ReadKey();
                    }

                   
                }

                if (startpeg == 3 && endpeg == 2)
                {
                    if ((peg2.length() == 0 || peg3.size() < peg2.size()) && peg3.length() != 0)
                    {
                        peg2.addRing(peg3.removeRing());
                    }
                    else
                    {
                        Console.WriteLine("Follow the rules!!!\nYou can't put bigger ring on smaller one\nDon't move a ring that doesnt exist (from an empty peg)"); Console.ReadKey();
                    }

                    
                }

                if (startpeg == 3 && endpeg == 1)
                {
                    if ((peg3.length() == 0 || peg3.size() < peg1.size()) && peg3.length() != 0)
                    {
                        peg1.addRing(peg3.removeRing());
                    }
                    else
                    {
                        Console.WriteLine("Follow the rules!!!\nYou can't put bigger ring on smaller one\nDon't move a ring that doesnt exist (from an empty peg)"); Console.ReadKey();
                    }

                    
                }
                Console.Clear();
                drawBoard(peg1, peg2, peg3);
                turns += 1;
               
            }
            // tells you you won and the number of turns.
            int min = calcMinMove(ringnum);
            Console.WriteLine("YOU FINISHED THE GAME");
            Console.WriteLine("It took you " + turns + " turns" );
            Console.WriteLine("The least amount of turns is " + min + " turns");
            if(turns != min)
            {
                Console.WriteLine("You didn't complete the game perfectly, do you want the soluiton? (Yes, No)");
                string awnser = Console.ReadLine();
                if(awnser == "Yes")
                {
                    printsolution(ringnum, "peg1", "peg3", "peg2");
                }
               
            }
            else
            {
                Console.WriteLine("You have completed the game in the minumun amout of moves!!! WOW");
            }
            Console.WriteLine("Have a great day!");
            Console.ReadLine();

            

            drawBoard(peg1, peg2, peg3);

            Console.ReadLine();
        }
        // draws the three pegs
        static void drawBoard(Peg p1, Peg p2, Peg p3)
        {
            p1.drawpeg(20);
            p2.drawpeg(40);
            p3.drawpeg(60);
            int x = 25;
            int y = 12;
            for( int i = 1; i <4; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("Peg " + i);
                 x += 20;
                
            }
            Console.SetCursorPosition(0, 14);
        }
        // sets the starting board
        static void setPeg(Peg peg, int rings)
        {
            for (int i = 0; i < rings; i++)
            {
                peg.addRing(rings - i);
            }

        }
        static int calcMinMove(int rings)
        {
            int min = 2;
            for(int i = 1; i < rings; i++)
            {
                min *= 2;
            }
            min = min - 1;
            return min;
        }
        static public void printsolution(int ringnum, string start, string end, string temp)
        {
          
            if (ringnum > 0)
            {
                printsolution(ringnum - 1, start, temp, end);
                Console.WriteLine("Move ring from " + start + " to " + end);
                printsolution(ringnum - 1, temp, end, start);

            }
        }
        static public void solve(int ringnum, Peg peg1, Peg peg3, Peg peg2)
        {
            if(ringnum > 0)
            {
                Peg temp = peg3;
                peg3 = peg2;
                peg2 = peg3;
                peg3.addRing(peg2.removeRing());
                
            
            }
        }
    }
}
