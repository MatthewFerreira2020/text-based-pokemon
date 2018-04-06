using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game101_Lab5_Kashi
{
    class Zapdos : Pokemon
    {
        int damage;
        Random rnd = new Random();


        public Zapdos(string zName, int zHP, int zLevel, string zDescription)   // default constructor
        {
            setName(zName);
            setHP(zHP);
            setLevel(zLevel);
            setDescription(zDescription);
        }

        public Zapdos()
        {
            setName("Zapdos");
            setHP(90);
            setDescription("Zapdos is a legendary bird Pokémon that has the ability to control electricity. It usually lives in thunderclouds. The Pokémon gains power if it is stricken by lightning bolts.");
        }


        override public int Attack(int pokemonOwner)    // over ride method for attack
        {
                if (pokemonOwner == 0) // player attack
                {
                    string pMove = "0";
                    do
                    {           // allows player to pick a move based on pokemon level
                    if (getLevel() >= 1 && getLevel() < 8)
                        {
                            Console.WriteLine("What move would you like to use?\n1. Thunder Shock");
                            pMove = Console.ReadLine();
                            switch (pMove)
                            {
                                case "1":
                                    thunderShock();
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (getLevel() >= 8 && getLevel() < 29)
                        {
                            Console.WriteLine("What move would you like to use?\n1. Thunder Shock\n2. Thunder Wave");
                            pMove = Console.ReadLine();
                            switch (pMove)
                            {
                                case "1":
                                    thunderShock();
                                    break;
                                case "2":
                                    thunderWave();
                                    break;

                                default:
                                    break;
                            }
                        }
                        if (getLevel() >= 29)
                        {
                            Console.WriteLine("What move would you like to use?\n1. Thunder Shock\n2. Thunder Wave\n3. Ancient Power");
                            pMove = Console.ReadLine();
                            switch (pMove)
                            {
                                case "1":
                                    thunderShock();
                                    break;
                                case "2":
                                    thunderWave();
                                    break;
                                case "3":
                                    ancientPower();
                                    break;
                                default:
                                    break;
                            }
                        }
                    } while (pMove != "1" && pMove != "2" && pMove != "3");
                }
                else // enemy attack
                {                       // enemy attacks are random and moves are based on pokemon level
                    if (getLevel() >= 1 && getLevel() < 8)
                    {
                        int rndMove = 1;
                        if (rndMove == 1)
                        {
                            thunderShock();
                        }

                    }
                    if (getLevel() >= 8 && getLevel() < 29)
                    {
                        int rndMove = rnd.Next(1, 2);
                        switch (rndMove)
                        {
                            case 1:
                                thunderShock();
                                break;
                            case 2:
                                thunderWave();
                                break;
                            default:
                                break;
                        }

                    }
                    if (getLevel() >= 29)
                    {
                        int rndMove = rnd.Next(1, 3);
                        switch (rndMove)
                        {
                            case 1:
                                thunderShock();
                                break;
                            case 2:
                                thunderWave();
                                break;
                            case 3:
                                ancientPower();
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
        public void thunderShock()
        {
            if (getLevel() >= 1)
            {
                damage = 15;
                Console.WriteLine("Zapdos used Thunder Shock!");
            }

            else
            {
                Console.WriteLine("Zapdos's level is too low to use this ability!");
            }
        }

        public void thunderWave()
        {
            if (getLevel() >= 8)
            {
                damage = 25;
                Console.WriteLine("Zapdos used Thunder Wave!");
            }

            else
            {
                Console.WriteLine("Zapdos's level is too low to use this ability!");
            }
        }

        public void ancientPower()
        {
            if (getLevel() >= 29)
            {
                damage = 35;
                Console.WriteLine("Zapdos used Ancient Power!");
            }

            else
            {
                Console.WriteLine("Zapdos's level is too low to use this ability!");
            }
        }
    }
}
