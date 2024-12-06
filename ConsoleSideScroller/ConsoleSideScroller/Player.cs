﻿namespace ConsoleSideScroller
{
    public class Player
    {
        private const char PlayerChar = '▣';

        public int CurrentPosX;
        public int CurrentPosY;

        private int MaxJumpPower = 10;
        private int YOffset = 0;
        private bool IsGround = true;
        private bool IsJumpUp = false;



        public Player(int x, int floorY)
        {
            CurrentPosX = x;
            CurrentPosY = floorY - 1;
        }



        public void Run(ConsoleKey key)
        {
            if (!IsGround)
            {
                if (IsJumpUp)
                {
                    if (YOffset == MaxJumpPower)
                    {
                        IsJumpUp = false;
                        YOffset--;
                    }
                    else
                    {
                        YOffset++;
                    }
                }
                else
                {
                    if (YOffset == 0)
                    {
                        IsGround = true;
                        YOffset = 0;
                    }
                    else
                    {
                        YOffset--;
                    }
                }
            }

            switch (key)
            {
                case ConsoleKey.Spacebar:
                    if (IsGround)
                    {
                        IsGround = false;
                        IsJumpUp = true;
                        YOffset = 1;
                    }
                    break;
                default:
                    break;
            }
        }

        public void RenderPlayer(int x, int floorY)
        {
            CurrentPosY = floorY - 1 - YOffset;

            Console.SetCursorPosition(x, CurrentPosY);
            Console.WriteLine(PlayerChar);
        }

        public bool IsHit(Obstacle obstacle)
        {
            return obstacle.IsHit(CurrentPosX, CurrentPosY);
        }
    }
}
