using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testrispt2
{
    class Program
    {
        static void Main(string[] args)
        {
            Display.Init();
            Display.Refresh();

            string pInput = "open";

            var gameStep = Stopwatch.StartNew(); //When this gets to a certain point - it will drop the blocks
            var pTimer = Stopwatch.StartNew(); //This will be used to add a delay on input
            ActiveBlock AB = new ActiveBlock();

            Boolean gameOver = false;
            Boolean collision = false;

            Console.CursorVisible = false;

            while (gameOver == false)
            {
                while(Console.KeyAvailable == false)
                {
                    if (gameStep.ElapsedMilliseconds >= 200)
                    {
                        if (AB.active == false)
                        {
                            AB.Init();
                            Display.Refresh();
                        }

                        if (AB.x > 0 && Display.Rows[AB.x - 1][AB.y] == "[ ]") //if the space below active block is empty, move it down
                        {
                            Display.Rows[AB.x][AB.y] = "[ ]";
                            AB.x = AB.x - 1;
                            Display.Rows[AB.x][AB.y] = "[O]";
                            Display.Refresh();
                        }
                        if (AB.x == 0 || Display.Rows[AB.x - 1][AB.y] == "[0]") //if the space below active block is not empty, or if it is at 0, then make block solid and make active block false and make collision true
                        {
                            Display.Rows[AB.x][AB.y] = "[0]";
                            AB.active = false;
                            Display.Refresh();
                            collision = true;
                        }
                        if(collision == true) //this will check for complete rows - only after a collision has occured
                        {
                            for(int i=0; i < Display.Rows.Count; i++) //this checks to see if a row is full, then if it is, removes all solid blocks
                            {
                                Boolean rowFull = true;
                                for(int j=0; j < Display.Rows[i].Count; j++)
                                {
                                    if (Display.Rows[i][j]=="[ ]")
                                    {
                                        rowFull = false;
                                    }
                                }
                                if(rowFull == true)
                                {
                                   for(int k=0; k < Display.Rows[i].Count; k++)
                                    {
                                        Display.Rows[i][k] = "[ ]";
                                    }
                                }
                            }
                            Boolean drop = true;
                            while(drop == true)
                            {
                                drop = false;
                                for (int i=1; i< Display.Rows.Count;i++)
                                {
                                    for (int j=0; j<Display.Rows[i].Count;j++)
                                    {
                                        if(Display.Rows[i][j] == "[0]" && Display.Rows[i-1][j] == "[ ]") //this moves down and solid blocks that have a blank area below (create state with rows that aren't destroyed?)
                                        {
                                            Display.Rows[i][j] = "[ ]";
                                            Display.Rows[i-1][j] = "[0]";
                                            drop = true;
                                        }
                                    }
                                }
                            }
                            collision = false;
                        }
                        gameStep.Restart();
                        
                    }
                }
                

                if (pTimer.ElapsedMilliseconds >= 500 && pInput == "delay") //.5 second delay on player input
                {
                    pInput = "open";
                }

                if (pInput == "open")
                {
                    pInput = Console.ReadKey().Key.ToString();
                }


                if (AB.y > 0 && pInput == ConsoleKey.LeftArrow.ToString() && Display.Rows[AB.x][AB.y-1] == "[ ]" && AB.active == true )
                {
                    pInput = "delay";

                    Display.Rows[AB.x][AB.y] = "[ ]";
                    AB.y = AB.y - 1;
                    Display.Rows[AB.x][AB.y] = "[O]";
                    
                    Display.Refresh();
                    
                }
                else if (AB.y < 9 && pInput == ConsoleKey.RightArrow.ToString() && Display.Rows[AB.x][AB.y+1] == "[ ]" && AB.active == true)
                {
                    pInput = "delay";

                    Display.Rows[AB.x][AB.y] = "[ ]";
                    AB.y = AB.y + 1;
                    Display.Rows[AB.x][AB.y] = "[O]";
                    
                    Display.Refresh();
                    
                }
                else if(AB.x > 0 && pInput == ConsoleKey.DownArrow.ToString() && Display.Rows[AB.x-1][AB.y] == "[ ]" && AB.active == true)
                {
                    pInput = "delay";

                    Display.Rows[AB.x][AB.y] = "[ ]";
                    AB.x = AB.x - 1;
                    Display.Rows[AB.x][AB.y] = "[O]";
                    
                    Display.Refresh();
                    
                }
                else
                {
                    pInput = "delay";
                }
                    
            }

        }
    }
}
