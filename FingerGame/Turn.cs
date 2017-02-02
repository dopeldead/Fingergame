using System.Collections.Generic;
using System.Linq;

namespace FingerGame
{
    public class Turn
    {
        public Turn(Player active, Player passive)
        {
            Active = active;
            Passive = passive;
            IsFinal = Active.CheckSum == 2 || Passive.CheckSum == 2;
            Processed = false;
        }
        public Player Active { get; set; }
        public Player Passive { get; set; }
        public bool IsFinal { get; set; }
        public bool Processed { get; set; }
        public List<Turn> Childs{get;set;}

        public List<Turn> Do()
        {
            //Right=> right
            if(Active.Right+Passive.Right <= 5 && Active.Right!=0 && Passive.Right != 0)
            {
                Turn t = new Turn(new Player(Passive.Name,Passive.Right + Active.Right, Passive.Left), new Player(Active.Name, Active.Right, Active.Left));
                Childs.Add(t);
            }
            //right => left
            if (Active.Right + Passive.Left < 5 && Active.Right != 0 && Passive.Left != 0)
            {
                Turn t = new Turn(new Player(Passive.Name, Passive.Right , Passive.Left + Active.Right), new Player(Active.Name,Active.Right, Active.Left));
                Childs.Add(t);
            }
            //left => right
            if (Active.Left + Passive.Right <= 5 && Active.Left != 0 && Passive.Right != 0)
            {
                Turn t = new Turn(new Player(Passive.Name, Passive.Right + Active.Left, Passive.Left ), new Player(Active.Name, Active.Right, Active.Left));
                Childs.Add(t);
            }
            //left=> left
            if (Active.Left + Passive.Left <= 5 && Active.Left != 0 && Passive.Left != 0)
            {
                Turn t = new Turn(new Player(Passive.Name, Passive.Right, Passive.Left + Active.Left), new Player(Active.Name,Active.Right, Active.Left));
                Childs.Add(t);
            }
            //share
            if(((Active.Left+Active.Right) % 5 == 2) || ((Active.Left + Active.Right) % 5 == 3))
            {
                Childs.Add(new Turn(new Player(Passive.Name, Passive.Right, Passive.Left), new Player(Active.Name, Active.Right + Active.Left, 0)));
            }
            if ((Active.Left + Active.Right) % 5 == 4)
            {
                for(int i =0; i < 3; i++)
                {
                    Turn t = new Turn(new Player(Passive.Name, Passive.Right, Passive.Left), new Player(Active.Name, 0 +i, 4-i));
                    if (t.Passive.CheckSum != Active.CheckSum) Childs.Add(t);
                }
            }
            if ((Active.Left + Active.Right) % 5 == 5)
            {
                for (int i = 0; i < 3; i++)
                {
                    Turn t = new Turn(new Player(Passive.Name, Passive.Right, Passive.Left), new Player(Active.Name, 0 + i, (5 - i)%5));
                    if (t.Passive.CheckSum != Active.CheckSum) Childs.Add(t);
                }
            }
            if ((Active.Left + Active.Right) % 5 == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    Turn t = new Turn(new Player(Passive.Name, Passive.Right, Passive.Left), new Player(Active.Name, 1 + i, (5 - i) % 5));
                    if (t.Passive.CheckSum != Active.CheckSum) Childs.Add(t);
                }
            }
            return this.Childs;
        }
       
        #region Equality
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
            // If parameter cannot be cast to Turn return false.
            Turn t = obj as Turn;
            
            // Return true if the fields match:
            return (Active.Equals(t.Active)) && (Passive.Equals(t.Passive));
        }

        public bool Equals(Turn t)
        {
            // If parameter is null return false:
            if ((object)t == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Active.Equals(t.Active)) && (Passive.Equals(t.Passive));
        }
        public override int GetHashCode()
        {
            return Active.Right ^ Active.Left;
        }
        #endregion
    }
}
