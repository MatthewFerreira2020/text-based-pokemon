using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game101_Lab5_Kashi
{
    class Articuno : Pokemon
    {
        int damage;
        Random rnd = new Random();


        public Articuno(string aName, int aHP, int aLevel, string aDescription) // default constructor
        {
            setName(aName);
            setHP(aHP);
            setLevel(aLevel);
            setDescription(aDescription);          
        }

        public Articuno()
        {
            setName("Articuno");
            setHP(90);
            setDescription("Articuno is a legendary bird Pokémon that can control ice. The flapping of its wings chills the air. As a result, it is said that when this Pokémon flies, snow will fall.");
        }


        override public int Attack(int pokemonOwner)    // over ride method for attack
        {
            if (pokemonOwner == 0)  // player attack
            {
                string pMove = "0";
                do 
                {               // allows player to pick a move based on pokemon level
                    if (getLevel() >= 1 && getLevel() < 8)
                    {
                        Console.WriteLine("What move would you like to use?\n1. Sheer Cold");
                        pMove = Console.ReadLine();
                        switch (pMove)
                        {
                            case "1":
                                sheerCold();
                                break;
                            default:
                                break;
                        }
                    }
                    if (getLevel() >= 8 && getLevel() < 15)
                    {
                        Console.WriteLine("What move would you like to use?\n1. Sheer Cold\n2. Mist");
                        pMove = Console.ReadLine();
                        switch (pMove)
                        {
                            case "1":
                                sheerCold();
                                break;
                            case "2":
                                Mist();
                                break;

                            default:
                                break;
                        }
                    }
                    if (getLevel() >= 15)
                    {
                        Console.WriteLine("What move would you like to use?\n1. Sheer Cold\n2. Mist\n3. Ice Shard");
                        pMove = Console.ReadLine();
                        switch (pMove)
                        {
                            case "1":
                                sheerCold();
                                break;
                            case "2":
                                Mist();
                                break;
                            case "3":
                                iceShard();
                                break;
                            default:
                                break;
                        }
                    }
                } while (pMove != "1" && pMove != "2" && pMove != "3");
            }
            else // enemy attack
            {                   // enemy attacks are random and moves are based on pokemon level
                if (getLevel() >= 1 && getLevel() < 8)
                {
                    int rndMove = 1;
                    if (rndMove == 1)
                    {
                        sheerCold();
                    }

                }
                if (getLevel() >= 8 && getLevel() < 15)
                {
                    int rndMove = rnd.Next(1, 2);
                    switch (rndMove)
                    {
                        case 1:
                            sheerCold();
                            break;
                        case 2:
                            Mist();
                            break;
                        default:
                            break;
                    }

                }
                if (getLevel() >= 15)
                {
                    int rndMove = rnd.Next(1, 3);
                    switch (rndMove)
                    {
                        case 1:
                            sheerCold();
                            break;
                        case 2:
                            Mist();
                            break;
                        case 3:
                            iceShard();
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
        public void sheerCold()
        {

            if (getLevel() >= 1)
            {
                damage = 30;
                Console.WriteLine("Articuno used Sheer Cold!");
            }

            else
            {
                Console.WriteLine("Articuno's level is too low to use this ability!");
            }
        }


        public void Mist()
        {

            if (getLevel() >= 8)
            {
                damage = 20;
                Console.WriteLine("Articuno used Mist!");
            }

            else
            {
                Console.WriteLine("Articuno's level is too low to use this ability!");
            }
        }

        public void iceShard()
        {

            if (getLevel() >= 15)
            {
                damage = 35;
                Console.WriteLine("Articuno used Ice Shard!");
            }

            else
            {
                Console.WriteLine("Articuno's level is too low to use this ability!");
            }
        }
    }
}
