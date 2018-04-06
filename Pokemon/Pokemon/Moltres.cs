using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game101_Lab5_Kashi
{
    class Moltres : Pokemon
    {
        int damage;
        Random rnd = new Random();




        public Moltres(string mName, int mHP, int mLevel, string mDescription)  // default constructor
        {   
            setName(mName);
            setHP(mHP);
            setLevel(mLevel);
            setDescription(mDescription);
        }

        public Moltres()
        {
            setName("Moltres");
            setHP(90);
            setDescription("Moltres is a legendary bird Pokémon that has the ability to control fire. If this Pokémon is injured, it is said to dip its body in the molten magma of a volcano to burn and heal itself.");
        }


        override public int Attack(int pokemonOwner)    // over ride method for attack
        {
            if (pokemonOwner == 0)  // player attack
            {
                string pMove = "0";
                do
                {           // allows player to pick a move based on pokemon level
                    if (getLevel() >= 1 && getLevel() < 29)
                    {
                        Console.WriteLine("What move would you like to use?\n1. Heat Wave");
                        pMove = Console.ReadLine();
                        switch (pMove)
                        {
                            case "1":
                                heatWave();
                                break;
                            default:
                                break;
                        }
                    }
                    if (getLevel() >= 29 && getLevel() < 36)
                    {
                        Console.WriteLine("What move would you like to use?\n1. Heat Wave\n2. Ancient Power");
                        pMove = Console.ReadLine();
                        switch (pMove)
                        {
                            case "1":
                                heatWave();
                                break;
                            case "2":
                                ancientPower();
                                break;

                            default:
                                break;
                        }
                    }
                    if (getLevel() >= 36)
                    {
                        Console.WriteLine("What move would you like to use?\n1. Heat Wave\n2. Ancient Power\n3. Flamethrower");
                        pMove = Console.ReadLine();
                        switch (pMove)
                        {
                            case "1":
                                heatWave();
                                break;
                            case "2":
                                ancientPower();
                                break;
                            case "3":
                                Flamethrower();
                                break;
                            default:
                                break;
                        }
                    }
                } while (pMove != "1" && pMove != "2" && pMove != "3");
            }
            else // enemy attack
            {                   // enemy attacks are random and moves are based on pokemon level
                if (getLevel() >= 1 && getLevel() < 29)
                {
                    int rndMove = 1;
                    if (rndMove == 1)
                    { 
                    heatWave();
                    }

                }
                    if (getLevel() >= 29 && getLevel() < 36)
                {
                    int rndMove = rnd.Next(1, 2);
                    switch (rndMove)
                    {
                        case 1:
                            heatWave();
                            break;
                        case 2:
                            ancientPower();
                            break;
                        default:
                            break;
                    }

                }
                if (getLevel() >= 36)
                {
                    int rndMove = rnd.Next(1, 3);
                    switch (rndMove)
                    {
                        case 1:
                            heatWave();
                            break;
                        case 2:
                            ancientPower();
                            break;
                        case 3:
                            Flamethrower();
                            break;
                        default:
                            break;
                    }
                }
            }
            return damage;              // damage is returned after attack
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
        public void heatWave()
        {
            if (getLevel() >= 1)
            {
                damage = 20;
                Console.WriteLine("Moltres used Heat Wave!");
            }

            else
            {
                Console.WriteLine("Moltres's level is too low to use this ability!");
            }
        }

        public void ancientPower()
        {
            if (getLevel() >= 29)
            {
                damage = 35;
                Console.WriteLine("Moltres used Ancient Power!");
            }

            else
            {
                Console.WriteLine("Moltres's level is too low to use this ability!");
            }
        }

        public void Flamethrower()
        {
            if (getLevel() >= 36)
            {
                damage = 40;
                Console.WriteLine("Moltres used Flamethrower!");
            }

            else
            {
                Console.WriteLine("Moltres's level is too low to use this ability!");
            }
        }              
    }
}
