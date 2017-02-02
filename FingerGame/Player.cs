using System;

namespace FingerGame
{
    public class Player
    {
        public Player(string name,int right, int left)
        {
            Left = left%5;
            Right = right%5;
            Name = name;
        }
        public int Left { get; set; }
        public int Right { get; set; }
        public string Name { get; set; }
        public int CheckSum
        {
            get { return (int)(Math.Pow((float)2, (float)Right) + Math.Pow((float)2, (float)Left)); }
        }
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
            if ((System.Object)obj == null)
            {
                return false;
            }
            // If parameter cannot be cast to Point return false.
            Player p = obj as Player;
            

            // Return true if the fields match:
            return (CheckSum == p.CheckSum);
        }

        public bool Equals(Player p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (CheckSum == p.CheckSum);
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
