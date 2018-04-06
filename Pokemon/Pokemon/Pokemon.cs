using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game101_Lab5_Kashi
{
    abstract class Pokemon
    {
        string name = "";
        int HP = 0;
        int level = 0;
        string description;
        int exp = 0;
        
        public enum Type
        {
            type,
            weakness,
            resistance,
        }

        abstract public int Attack(int pokemonOwner);           // abstract methods
        abstract public void Speak();
        abstract public void getHit(int damageTaken);

        public string getName()                                 // getters and setters
        {
            return name;
        }

        public void setName(string pName)
        {
            name = pName;
        }

        public int getHP()
        {
            return HP;
        }

        public void setHP(int pHP)
        {
            HP = pHP;
        }

        public int getEXP()
        {
            return exp;
        }

        public void setEXP(int experience)
        {
            exp = experience;
            setLevel(experience);
        }

        public int getLevel()
        {
            return level;
        }

        public void setLevel(int currentExp)
        {
            if (currentExp == 1 || currentExp < 8)
            {
                level = 1;
            }
            else if (currentExp > 8 && currentExp < 27)
            {
                level = 2;
            }
            else if (currentExp > 27 && currentExp < 64)
            {
                level = 3;
            }
            else if (currentExp > 64 && currentExp < 125)
            {
                level = 4;
            }
            else if (currentExp > 125 && currentExp < 216)
            {
                level = 5;
            }
            else if (currentExp > 216 && currentExp < 343)
            {
                level = 6;
            }
            else if (currentExp > 343 && currentExp < 512)
            {
                level = 7;
            }
            else if (currentExp > 512 && currentExp < 729)
            {
                level = 8;
            }
            else if (currentExp > 729 && currentExp < 1000)
            {
                level = 9;
            }
            else if (currentExp > 1000 && currentExp < 1331)
            {
                level = 10;
            }
            else if (currentExp > 1331 && currentExp < 1728)
            {
                level = 11;
            }
            else if (currentExp > 1728 && currentExp < 2197)
            {
                level = 12;
            }
            else if (currentExp > 2197 && currentExp < 2744)
            {
                level = 13;
            }
            else if (currentExp > 2744 && currentExp < 3375)
            {
                level = 14;
            }
            else if (currentExp > 3375 && currentExp < 4096)
            {
                level = 15;
            }
            else if (currentExp > 4096 && currentExp < 4913)
            {
                level = 16;
            }
            else if (currentExp > 4913 && currentExp < 5832)
            {
                level = 17;
            }
            else if (currentExp > 5832 && currentExp < 6859)
            {
                level = 18;
            }
            else if (currentExp > 6859 && currentExp < 8000)
            {
                level = 19;
            }
            else if (currentExp > 8000)
            {
                level = 20;
            }
        }

        public string getDescription()
        {
            return description;
        }

        public void setDescription(string pDescription)
        {
            description = pDescription;
        }
    }
}
