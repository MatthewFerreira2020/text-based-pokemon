using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game101_Lab5_Kashi
{
    class Kyogre : Pokemon
    {
        int damage;
        Random rnd = new Random();

        public Kyogre(string kName, int kHP, int kLevel, string kDescription)   // default constructor
        {
            setName(kName);
            setHP(kHP);
            setLevel(kLevel);
            setDescription(kDescription);
        }

        public Kyogre()
        {
            setName("Kyogre");
            setHP(100);
            setDescription("Kyogre is said to be the personification of the sea itself. Legends tell of its many clashes against Groudon, as each sought to gain the power of nature.");
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
                        Console.WriteLine("What move would you like to use?\n1. Water Pulse");
                        pMove = Console.ReadLine();
                        switch (pMove)
                        {
                            case "1":
                                waterPulse();
                                break;
                            default:
                                break;
                        }
                    }
                    if (getLevel() >= 15 && getLevel() < 35)
                    {
                        Console.WriteLine("What move would you like to use?\n1. Water Pulse\n2. Aqua Tail");
                        pMove = Console.ReadLine();
                        switch (pMove)
                        {
                            case "1":
                                waterPulse();
                                break;
                            case "2":
                                aquaTail();
                                break;

                            default:
                                break;
                        }
                    }
                    if (getLevel() >= 35)
                    {
                        Console.WriteLine("What move would you like to use?\n1. Water Pulse\n2. Aqua Tail\n3. Ice Beam");
                        pMove = Console.ReadLine();
                        switch (pMove)
                        {
                            case "1":
                                waterPulse();
                                break;
                            case "2":
                                aquaTail();
                                break;
                            case "3":
                                iceBeam();
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
                        waterPulse();
                    }

                }
                if (getLevel() >= 15 && getLevel() < 35)
                {
                    int rndMove = rnd.Next(1, 2);
                    switch (rndMove)
                    {
                        case 1:
                            waterPulse();
                            break;
                        case 2:
                            aquaTail();
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
                            waterPulse();
                            break;
                        case 2:
                            aquaTail();
                            break;
                        case 3:
                            iceBeam();
                            break;
                        default:
                            break;
                    }
                }
            }
            return damage;          // damage is returned after attack
        }
        override public void Speak() // over ride method for speak
        {

        }
        override public void getHit(int damageTaken) // over ride method for get hit
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
        public void waterPulse()
        {
            if (getLevel() >= 1)
            {
                damage = 20;
                Console.WriteLine("Kyogre used Water Pulse!");
            }

            else
            {
                Console.WriteLine("Kyogre's level is too low to use this ability!");
            }
        }

        public void aquaTail()
        {
            if (getLevel() >= 15)
            {
                damage = 25;
                Console.WriteLine("Kyogre used Aqua Tail!");
            }

            else
            {
                Console.WriteLine("Kyogre's level is too low to use this ability!");
            }
        }

        public void iceBeam()
        {
            if (getLevel() >= 35)
            {
                damage = 35;
                Console.WriteLine("Kyogre used Ice Beam!");
            }

            else
            {
                Console.WriteLine("Kyogre's level is too low to use this ability!");
            }
        }
    }
}
