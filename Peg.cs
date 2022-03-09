using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thats_the_Towers_of_Hanoi
{
    class Peg
    {
        
        private int[] rings;
        private int height;

        int y = 5;

        public Peg(int height)
        {
            this.height = height;
            rings = new int[0];
        }

        public int Height
        {
            get { return height; }
        }

        public int[] Rings
        {
            get { return rings; }
            set { rings = value; }
        }
        //public int Size
        //{

        //    get { return rings[rings.Length - 1]; }

        //}

        // draws the pegs( the base, stool and the rings), taking the positions and the number of rings
        public void drawpeg(int x)
        {
            Console.SetCursorPosition(x, height + y);

            for (int i = 0; i < 15; i++)
            {
                Console.Write("-");
            }

            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x + 7, y+i);

                Console.WriteLine("|");
            }


            for (int i = 0; i < rings.Length; i++)
            {
                Console.SetCursorPosition(x + 8, y + height - 1 - i);
                Console.Write(makeBlocks(rings[i]));
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }

            for (int i = 0; i < rings.Length; i++)
            {
                
                Console.SetCursorPosition(x + 7 - rings[i], y + height - 1 - i);
                Console.Write(makeBlocks(rings[i]));
                Console.BackgroundColor = ConsoleColor.DarkBlue;

            }

        }
        // adds a ring according to the size
        public void addRing(int size)
        {
            Array.Resize<int>(ref rings, rings.Length + 1);
            rings[rings.Length - 1] = size;
            
        }

        // removes a ring and returns the size
        public int removeRing()
        {
            int temp = rings[rings.Length - 1];
            Array.Resize<int>(ref rings, rings.Length - 1);
            return temp;
        }

        // creates blocks that makes the rings
        public string makeBlocks(int ringamount)
        {
            if(ringamount > 4)
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
            }
            if ( ringamount == 4)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            if (ringamount == 3)
            {
                Console.BackgroundColor = ConsoleColor.Green;
            }
            if(ringamount == 2)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            if (ringamount == 1)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            string blocks = "▒";

            for (int i = 0; i < ringamount - 1; i++)
            {
                
                Console.Write(blocks);
            }
            
            return blocks;
        }
        //returns the size of the rings array 
        public int size()
        {
            return rings[rings.Length-1];
        }
        //returns the size of the lenth of the rings array 
        public int length()
        {
            return rings.Length;
        }
        

    }
}


