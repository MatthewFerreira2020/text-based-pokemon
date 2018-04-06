using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game101_Lab5_Kashi
{
    class Groudon : Pokemon
    {
        int damage;
        Random rnd = new Random();


        public Groudon(string gName, int gHP, int gLevel, string gDescription)  // default constructor
        {
            setName(gName);
            setHP(gHP);
            setLevel(gLevel);
            setDescription(gDescription);
        }

        public Groudon()
        {
            setName("Groudon");
            setHP(100);
            setDescription("Through Primal Reversion and with nature’s full power, it will take back its true form. It can cause magma to erupt and expand the landmass of the world.");
        }

        override public int Attack(int pokemonOwner)    // over ride method for attack
        {
            if (pokemonOwner == 0)  // player attack
            {
                string pMove = "0";
                do
                {           // allows player to pick a move based on pokemon level
                    if (getLevel() >= 1 && getLevel() < 15)
                    {
                        Console.WriteLine("What move would you like to use?\n1. Mud Shot");
                        pMove = Console.ReadLine();
                        switch (pMove)
                        {
                            case "1":
                                mudShot();
                                break;
                            default:
                                break;
                        }
                    }
                    if (getLevel() >= 15 && getLevel() < 35)
                    {
                        Console.WriteLine("What move would you like to use?\n1. Mud Shot\n2. Earth Power");
                        pMove = Console.ReadLine();
                        switch (pMove)
                        {
                            case "1":
                                mudShot();
                                break;
                            case "2":
                                earthPower();
                                break;

                            default:
                                break;
                        }
                    }
                    if (getLevel() >= 35)
                    {
                        Console.WriteLine("What move would you like to use?\n1. Mud Shot\n2. Earth Power\n3. Earthquake");
                        pMove = Console.ReadLine();
                        switch (pMove)
                        {
                            case "1":
                                mudShot();
                                break;
                            case "2":
                                earthPower();
                                break;
                            case "3":
                                Earthquake();
                                break;
                            default:
                                break;
                        }
                    }
                } while (pMove != "1" && pMove != "2" && pMove != "3");
            }
            else // enemy attack
            {                   // enemy attacks are random and moves are based on pokemon level
                if (getLevel() >= 1 && getLevel() < 15)
                {
                    int rndMove = 1;
                    if (rndMove == 1)
                    {
                        mudShot();
                    }

                }
                if (getLevel() >= 15 && getLevel() < 35)
                {
                    int rndMove = rnd.Next(1, 2);
                    switch (rndMove)
                    {
                        case 1:
                            mudShot();
                            break;
                        case 2:
                            earthPower();
                            break;
                        default:
                            break;
                    }

                }
                if (getLevel() >= 35)
                {
                    int rndMove = rnd.Next(1, 3);
                    switch (rndMove)
                    {
                        case 1:
                            mudShot();
                            break;
                        case 2:
                            earthPower();
                            break;
                        case 3:
                            Earthquake();
                            break;
                        default:
                            break;
                    }
                }
            }
            return damage;      // damage is returned after attack
        }
        override public void Speak() // over ride method for speak
        {

        }
        override public void getHit(int damageTaken)    // over ride method for get hit
        {
            int currentHP = getHP();
            currentHP = currentHP - damageTaken;        // subtracts damage from HP
            setHP(currentHP);
            if (getHP() > 0)
            {
                Console.WriteLine("{0} currently has {1} HP remaining!", getName(), getHP());       // remaining HP is displayed if pokemon has HP left
            }
            else
            {
                Console.WriteLine("{0} currently has 0 HP remaining!", getName());                  // message for if pokemon has no HP remaining
            }
        }

        // pokemon moves
        public void mudShot()
        {
            if (getLevel() >= 1)
            {
                damage = 20;
                Console.WriteLine("Groudon used Mud Shot!");
            }

            else
            {
                Console.WriteLine("Groudon's level is too low to use this ability!");
            }
        }

        public void earthPower()
        {
            if (getLevel() >= 15)
            {
                damage = 25;
                Console.WriteLine("Groudon used Earth Power!");
            }

            else
            {
                Console.WriteLine("Groudon's level is too low to use this ability!");
            }
        }

        public void Earthquake()
        {
            if (getLevel() >= 35)
            {
                damage = 35;
                Console.WriteLine("Groudon used Earthquake!");
            }

            else
            {
                Console.WriteLine("Groudon's level is too low to use this ability!");
            }
        }
    }
}
