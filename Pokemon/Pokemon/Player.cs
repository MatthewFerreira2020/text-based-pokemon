using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game101_Lab5_Kashi
{
    class Player
    {
        string name = "";
        string age = "";
        string city = "";
        bool bike = false;
        Pokemon[] pokemonList = new Pokemon[150];
        int numberOfPokeballs = 10;
        int money = 200;
        int numberOfPokemon = 0;
        bool trainerDefeated = false;

        public Player() // default constructor
        {

        }

        public Player(string pName, string pAge, string pCity)   // constructor
        {
            name = pName;
            age = pAge;
            city = pCity;
        }

        public void setNumberOfPokemon(int numPokemon)      // getters and setters
        {
            numberOfPokemon = numPokemon;
        }

        public int getNumberOfPokemon()
        {
            return numberOfPokemon;
        }

        public void setTrainerDefeated(bool status)
        {
            trainerDefeated = status;
        }

        public bool getTrainerDefeated()
        {
            return trainerDefeated;
        }

        public void setPokemonList(Pokemon[] newPokeList)
        {
            pokemonList = newPokeList;
        }

        public Pokemon[] getPokemonList()
        {
            return pokemonList;
        }

        public void setPokemon(Pokemon[] trainerPokemon, int pokeAssign)
        {
            pokemonList[numberOfPokemon] = trainerPokemon[pokeAssign];
        }

        public void setName(string playerName)
        {
            name = playerName;
        }
        public string getName()
        {
            return name;
        }

        public void setAge(string playerAge)
        {
            age = playerAge;
        }
        public string getAge()
        {
            return age;
        }

        public void setCity(string playerCity)
        {
            city = playerCity;
        }
        public string getCity()
        {
            return city;
        }

        public void setBike(bool ride)
        {
            bike = ride;
        }
        public bool getBike()
        {
            return bike;
        }

        public void setMoney(int playerMoney)
        {
            money = playerMoney;
        }
        public int getMoney()
        {
            return money;
        }

        public void setNumberOfPokeballs(int pokeballs)
        {
            numberOfPokeballs = pokeballs;
        }

        public int getNumberOfPokeballs()
        {
            return numberOfPokeballs;
        }

        public void battle(Pokemon[] pokemonArray, int pokeAssign)  //battle method
        {
            Random rnd = new Random();
            Console.WriteLine("You have encountered a {0}! Its level is {1} and its HP is {2}!", pokemonArray[pokeAssign].getName(), pokemonArray[pokeAssign].getLevel(), pokemonArray[pokeAssign].getHP());
            Console.WriteLine();
            int currentPokemon = 0;
            int currentNumPokemon = numberOfPokemon;
            string flee = "";
            
                if (numberOfPokemon != 0) //ensures player needs a pokemon to battle
                {
                if (pokemonList[currentPokemon].getHP() > 0) // ensures players pokemon has HP
                {
                    Console.WriteLine("{0}, your {1} is level {2} and has {3} HP!", name, pokemonList[currentPokemon].getName(), pokemonList[currentPokemon].getLevel(), pokemonList[currentPokemon].getHP());
                    Console.WriteLine();
                    do // ensures the wild pokemon has HP remaining
                    {

                        do // ensures player has pokemon remaining
                        {
                            if (pokemonList[numberOfPokemon - 1].getHP() <= 0)  // player loses if their last pokemon has no HP left
                            {
                                Console.WriteLine("You lost the battle!\n");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            }
                            if (pokemonArray[pokeAssign].getHP() <= 0)          // player wins if the wild pokemon has no HP left
                            {
                                Console.WriteLine("You won the battle!\n");
                                int currentexp = pokemonList[currentPokemon].getEXP();
                                int gainedexp = 0;
                                if (pokemonList[currentPokemon].getLevel() > pokemonArray[pokeAssign].getLevel())
                                {
                                    gainedexp = 10;
                                    currentexp = currentexp + gainedexp;
                                    pokemonList[currentPokemon].setEXP(currentexp);
                                }
                                else if(pokemonList[currentPokemon].getLevel() == pokemonArray[pokeAssign].getLevel())
                                {
                                    gainedexp = 20;
                                    currentexp = currentexp + gainedexp;
                                    pokemonList[currentPokemon].setEXP(currentexp);
                                }
                                else if (pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() <= 5)
                                {
                                    gainedexp = 40;
                                    currentexp = currentexp + gainedexp;
                                    pokemonList[currentPokemon].setEXP(currentexp);
                                }
                                else if (pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() <= 10 && pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() > 5)
                                {
                                    gainedexp = 80;
                                    currentexp = currentexp + gainedexp;
                                    pokemonList[currentPokemon].setEXP(currentexp);
                                }
                                else if (pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() <= 15 && pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() > 10)
                                {
                                    gainedexp = 160;
                                    currentexp = currentexp + gainedexp;
                                    pokemonList[currentPokemon].setEXP(currentexp);
                                }
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Would you like to flee?\n");  // allows player to run from battle
                            flee = Console.ReadLine().ToLower();
                            if (flee == "yes")
                            {
                                Console.WriteLine("You safely fled from the battle!\n");
                                break;
                            }

                            else if (flee == "no") // if player doesn't want to flee the battle continues
                            {
                                int turn = 0;                                               //keeps track of who is attacking
                                Console.ForegroundColor = ConsoleColor.Red;
                                int yourAttack = pokemonList[currentPokemon].Attack(turn);  // player attacks
                                Console.ForegroundColor = ConsoleColor.Green;
                                pokemonArray[pokeAssign].getHit(yourAttack);                // wild pokemon loses HP
                                turn++;

                                if (pokemonArray[pokeAssign].getHP() <= 0)                  // player wins if the wild pokemon has no HP left
                                {
                                    Console.WriteLine("You won the battle!\n");
                                    int currentexp = pokemonList[currentPokemon].getEXP();
                                    int gainedexp = 0;
                                    if (pokemonList[currentPokemon].getLevel() > pokemonArray[pokeAssign].getLevel())
                                    {
                                        gainedexp = 10;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() == pokemonArray[pokeAssign].getLevel())
                                    {
                                        gainedexp = 20;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() <= 5)
                                    {
                                        gainedexp = 40;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() <= 10 && pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() > 5)
                                    {
                                        gainedexp = 80;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() <= 15 && pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() > 10)
                                    {
                                        gainedexp = 160;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                int enemyAttack = pokemonArray[pokeAssign].Attack(turn);                                // wild pokemon attacks
                                Console.ForegroundColor = ConsoleColor.Red;
                                pokemonList[currentPokemon].getHit(enemyAttack);                                        //  player's pokemon loses HP

                                if (pokemonList[numberOfPokemon - 1].getHP() <= 0)      // player loses if their last pokemon has no HP left
                                {
                                    Console.WriteLine("You lost the battle!\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                }

                                if (pokemonArray[pokeAssign].getHP() <= 15 && pokemonArray[pokeAssign].getHP() > 0)      // gives option to catch wild pokemon if its HP is below 15
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Would you like to catch the {0}?\n", pokemonArray[pokeAssign].getName());
                                    string throwpokeball = Console.ReadLine().ToLower();
                                    if (throwpokeball == "yes")
                                    {
                                        catchPokemon(pokemonArray, pokeAssign);
                                    }
                                }
                                if (currentNumPokemon != numberOfPokemon)
                                {
                                    Console.WriteLine("You won the battle!\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                }
                                if (pokemonArray[pokeAssign].getHP() <= 0)              // player wins if the wild pokemon has no HP left
                                {
                                    Console.WriteLine("You won the battle!\n");
                                    int currentexp = pokemonList[currentPokemon].getEXP();
                                    int gainedexp = 0;
                                    if (pokemonList[currentPokemon].getLevel() > pokemonArray[pokeAssign].getLevel())
                                    {
                                        gainedexp = 10;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() == pokemonArray[pokeAssign].getLevel())
                                    {
                                        gainedexp = 20;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() <= 5)
                                    {
                                        gainedexp = 40;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() <= 10 && pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() > 5)
                                    {
                                        gainedexp = 80;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() <= 15 && pokemonList[currentPokemon].getLevel() - pokemonArray[pokeAssign].getLevel() > 10)
                                    {
                                        gainedexp = 160;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                }
                                if (pokemonList[currentPokemon].getHP() <= 0)           // switches players pokemon when current pokemon runs out of HP
                                {
                                    currentPokemon++;
                                    if (currentPokemon < numberOfPokemon)               // ensures player has another pokemon to switch to
                                    {
                                        Console.WriteLine("You switched your Pokemon to {0}. Its level is {1} and its HP is {2}!\n", pokemonList[currentPokemon].getName(), pokemonList[currentPokemon].getLevel(), pokemonList[currentPokemon].getHP());
                                    }
                                }
                                if (pokemonList[numberOfPokemon - 1].getHP() <= 0)      // player loses if their last pokemon has no HP left
                                {
                                    Console.WriteLine("You lost the battle!\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                }
                            }

                            else
                            {
                                Console.WriteLine("Please answer with yes or no.\n");
                            }
                        } while (currentPokemon < numberOfPokemon);
                        if (pokemonList[numberOfPokemon - 1].getHP() < 1)
                        {
                            break;
                        }
                        if (flee == "yes")
                        {
                            break;
                        }
                        if (currentNumPokemon != numberOfPokemon)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        }
                    } while (pokemonArray[pokeAssign].getHP() > 0);
                } else
                {
                    Console.WriteLine("You don't have any Pokemon able to fight left!\n");      // if all of the players pokemon have no HP left
                }
            }
            if (numberOfPokemon == 0) // if player has no pokemon try to catch the pokemon
            {
                Console.WriteLine("You don't have any Pokemon to battle with!\n");              
                catchPokemon(pokemonArray, pokeAssign);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void battle(Player trainer)   // trainer battle method
        {
            bool trainerStatus = trainer.getTrainerDefeated();
            if (trainerStatus == false)
            {
            int currentTrainerPokemon = 0;
            int currentPokemon = 0;
            Console.WriteLine("Trainer {0} challenges you to a battle!", trainer.getName());
            Console.WriteLine();
            Pokemon[] trainerPokemon = trainer.getPokemonList();
            Console.WriteLine("Trainer {0} uses their {1}! Its level is {2}! Its HP is {3}!", trainer.getName(), trainerPokemon[0].getName(), trainerPokemon[0].getLevel(), trainerPokemon[0].getHP());
            Console.WriteLine();
            
                if (numberOfPokemon != 0)                           // ensures player has a pokemon to battle
                {
                    if (pokemonList[currentPokemon].getHP() > 0)    // ensures player has pokemon with HP left
                    {
                        do
                        {
                            do
                            {
                                if (pokemonList[numberOfPokemon - 1].getHP() <= 0)  // player loses if their last pokemon has no HP left
                                {
                                    Console.WriteLine("You lost the battle!\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                }
                                if (trainerPokemon[trainer.getNumberOfPokemon() - 1].getHP() <= 0)     // trainer loses if their pokemon has no HP left
                                {
                                    Console.WriteLine("You defeated trainer {0}!\n", trainer.getName());
                                    int currentexp = pokemonList[currentPokemon].getEXP();
                                    int gainedexp = 0;
                                    if (pokemonList[currentPokemon].getLevel() > trainerPokemon[currentTrainerPokemon].getLevel())
                                    {
                                        gainedexp = 10;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() == trainerPokemon[currentTrainerPokemon].getLevel())
                                    {
                                        gainedexp = 20;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() <= 5)
                                    {
                                        gainedexp = 40;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() <= 10 && pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() > 5)
                                    {
                                        gainedexp = 80;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() <= 15 && pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() > 10)
                                    {
                                        gainedexp = 160;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    trainer.setTrainerDefeated(true);
                                    money = money + 1000;
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                }
                                int turn = 0;                                               //keeps track of who is attacking
                                Console.ForegroundColor = ConsoleColor.Red;
                                int yourAttack = pokemonList[currentPokemon].Attack(turn);      // player attacks
                                Console.ForegroundColor = ConsoleColor.Green;
                                trainerPokemon[currentTrainerPokemon].getHit(yourAttack);                           // trainer's pokemon loses HP
                                turn++;

                                if (trainerPokemon[currentTrainerPokemon].getHP() <= 0)           // switches players pokemon when current pokemon runs out of HP
                                {
                                    int currentexp = pokemonList[currentPokemon].getEXP();
                                    int gainedexp = 0;
                                    if (pokemonList[currentPokemon].getLevel() > trainerPokemon[currentTrainerPokemon].getLevel())
                                    {
                                        gainedexp = 10;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() == trainerPokemon[currentTrainerPokemon].getLevel())
                                    {
                                        gainedexp = 20;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() <= 5)
                                    {
                                        gainedexp = 40;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() <= 10 && pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() > 5)
                                    {
                                        gainedexp = 80;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() <= 15 && pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() > 10)
                                    {
                                        gainedexp = 160;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    currentTrainerPokemon++;
                                    if (currentTrainerPokemon < trainer.getNumberOfPokemon())               // ensures player has another pokemon to switch to
                                    {
                                        Console.WriteLine("Trainer {0} sent out  {1}. Its level is {2} and its HP is {3}!\n", trainer.getName(), trainerPokemon[currentTrainerPokemon].getName(), trainerPokemon[currentTrainerPokemon].getLevel(), trainerPokemon[currentTrainerPokemon].getHP());
                                    }
                                }

                                if (trainerPokemon[trainer.getNumberOfPokemon() - 1].getHP() <= 0)         // trainer loses if their pokemon has no HP left
                                {
                                    Console.WriteLine("You defeated trainer {0}!\n", trainer.getName());
                                    int currentexp = pokemonList[currentPokemon].getEXP();
                                    int gainedexp = 0;
                                    if (pokemonList[currentPokemon].getLevel() > trainerPokemon[currentTrainerPokemon].getLevel())
                                    {
                                        gainedexp = 10;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() == trainerPokemon[currentTrainerPokemon].getLevel())
                                    {
                                        gainedexp = 20;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() <= 5)
                                    {
                                        gainedexp = 40;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() <= 10 && pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() > 5)
                                    {
                                        gainedexp = 80;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() <= 15 && pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() > 10)
                                    {
                                        gainedexp = 160;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    trainer.setTrainerDefeated(true);
                                    money = money + 1000;
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                int enemyAttack = trainerPokemon[currentTrainerPokemon].Attack(turn);           // trainer attacks
                                Console.ForegroundColor = ConsoleColor.Red;
                                pokemonList[currentPokemon].getHit(enemyAttack);            // player's pokemon loses HP

                                if (trainerPokemon[trainer.getNumberOfPokemon() - 1].getHP() <= 0)     // trainer loses if their pokemon has no HP left
                                {
                                    Console.WriteLine("You defeated trainer {0}!\n", trainer.getName());
                                    int currentexp = pokemonList[currentPokemon].getEXP();
                                    int gainedexp = 0;
                                    if (pokemonList[currentPokemon].getLevel() > trainerPokemon[currentTrainerPokemon].getLevel())
                                    {
                                        gainedexp = 10;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() == trainerPokemon[currentTrainerPokemon].getLevel())
                                    {
                                        gainedexp = 20;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() <= 5)
                                    {
                                        gainedexp = 40;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() <= 10 && pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() > 5)
                                    {
                                        gainedexp = 80;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    else if (pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() <= 15 && pokemonList[currentPokemon].getLevel() - trainerPokemon[currentTrainerPokemon].getLevel() > 10)
                                    {
                                        gainedexp = 160;
                                        currentexp = currentexp + gainedexp;
                                        pokemonList[currentPokemon].setEXP(currentexp);
                                    }
                                    trainer.setTrainerDefeated(true);
                                    money = money + 1000;
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                }

                                if (pokemonList[currentPokemon].getHP() <= 0)           // switches players pokemon when current pokemon runs out of HP
                                {
                                    currentPokemon++;
                                    if (currentPokemon < numberOfPokemon)               // ensures player has another pokemon to switch to
                                    {
                                        Console.WriteLine("You switched your Pokemon to {0}. Its level is {1} and its HP is {2}!\n", pokemonList[currentPokemon].getName(), pokemonList[currentPokemon].getLevel(), pokemonList[currentPokemon].getHP());
                                    }
                                }

                                if (pokemonList[numberOfPokemon - 1].getHP() <= 0)     // player loses if their last pokemon has no HP left
                                {
                                    Console.WriteLine("You lost the battle!\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                }
                            } while (currentPokemon < numberOfPokemon);
                            if (pokemonList[numberOfPokemon - 1].getHP() < 1)
                            {
                                break;
                            }
                        } while (trainerPokemon[trainer.getNumberOfPokemon() - 1].getHP() > 0);
                    }
                    else
                    {
                        Console.WriteLine("You don't have any Pokemon able to fight left!\n");          // if all of the players pokemon have no HP left
                    }
                }
                if (numberOfPokemon == 0) // if player has no pokemon 
                {
                    Console.WriteLine("You don't have any Pokemon to battle with!\n");
                }
            }
            else
            {
                Console.WriteLine("You are really strong");
            }

  }

        public void catchPokemon(Pokemon[] pokemonArray, int pokeAssign)
        {
            if (numberOfPokeballs > 0)
            {
                Console.WriteLine("{0} throws a pokeball!\n", name);
                if (numberOfPokemon == 0)
                {
                    pokemonList[numberOfPokemon] = pokemonArray[pokeAssign];        // adds pokemon to players array of pokemon
                    numberOfPokemon++;
                    numberOfPokeballs--;
                    Console.WriteLine("{0} caught the wild {1}!\n", name, pokemonArray[pokeAssign].getName());
                    
                }
                else
                {
                    Random rnd = new Random();
                    int catchChance = rnd.Next(0, 1);       // chance of catching pokemon
                    if (catchChance == 1)
                    {
                        pokemonList[numberOfPokemon] = pokemonArray[pokeAssign];    // adds pokemon to players array of pokemon
                        numberOfPokemon++;
                        numberOfPokeballs--;
                        Console.WriteLine("{0} caught the wild {1}!\n", name, pokemonArray[pokeAssign].getName());
                        
                    }
                    else
                    {
                        Console.WriteLine("The wild {0} broke out of the pokeball!\n", pokemonArray[pokeAssign].getName());
                        numberOfPokeballs--;
                    }
                }

            }
            else
            {
                Console.WriteLine("You need pokeballs to catch pokemon");
            }

            }

    }
}
