using App1;
using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Threading;

namespace MyApp
{

    internal class Program
    {
        static void Main(string[] args)
        {

            Player player = new Player();

            Enemy goblin = new Goblin();
            Enemy spider = new Spider();

            int wins = 0;

            Random random = new Random();


            Console.WriteLine("Welcome to RPG Console Warrior\n\n");
            Console.WriteLine("1.Start Game\n");
            Console.WriteLine("2.Quit\n");
            Console.Write(": ");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    while (player.Health > 0)
                    {

                        Console.Clear();

                        if (wins > 0)
                        {
                            Console.WriteLine("\nPlayer won! \n");
                            player.PlayerUpgrade(random);
                        }
                        Console.WriteLine("Fight begin!\n");
                        Thread.Sleep(1500);

                        int randomNumber = random.Next(0, 101);

                        int phase = 0;

                        while (goblin.Health >= 0 || spider.Health >= 0)
                        {
                            int turn = random.Next(1, 3);

                            Console.WriteLine($"Phase: {phase++}");

                            if (randomNumber <= 50)
                            {
                                Console.WriteLine($"Player vs Goblin \n");
                                Console.WriteLine($"Player health: {{{player.Health}}} attack: {{{player.Attack}}} defense: {{{player.Defense}}}");
                                Console.WriteLine($"Goblin health: {{{goblin.Health}}} attack: {{{goblin.Attack}}} defense: {{{goblin.Defense}}}\n");

                                Thread.Sleep(1500);

                                player.DealDamage(goblin, player.Attack);
                                if (goblin.Health <= 0)
                                {
                                    Console.WriteLine($"\nGoblin Died!");
                                    break;
                                }

                                Console.WriteLine('\n');
                                Thread.Sleep(1500);

                                goblin.DealDamage(player, goblin.Attack);
                                if (player.Health <= 0)
                                {
                                    Console.WriteLine($"\nPlayer Died!");
                                    break;
                                }

                                Thread.Sleep(1500); 
                            }
                            else
                            {
                                Console.WriteLine($"Player vs Spider \n");
                                Console.WriteLine($"Player health: {{{player.Health}}} attack: {{{player.Attack}}} defense: {{{player.Defense}}}");
                                Console.WriteLine($"Spider health: {{{spider.Health}}} attack: {{{spider.Attack}}} defense: {{{spider.Defense}}}\n");

                                Thread.Sleep(1500);

                                player.DealDamage(spider, player.Attack);
                                if (spider.Health <= 0)
                                {
                                    Console.WriteLine($"\nSpider Died!");
                                    break;
                                }

                                Console.WriteLine('\n');
                                Thread.Sleep(1500);

                                spider.DealDamage(player, spider.Attack);
                                if (player.Health <= 0)
                                {
                                    Console.WriteLine($"\nPlayer Died!");
                                    break;
                                }

                                Thread.Sleep(1500);
                            }

                            Console.WriteLine('\n');
                        }

                        Thread.Sleep(1500);

                        if (player.Health > 0)
                        {
                            wins++;

                            int randomBuff = random.Next(1, 4);

                            goblin = new Goblin();

                            goblin.Attack += (sbyte)(randomBuff);
                            goblin.Health += (sbyte)(randomBuff);
                            goblin.Defense += (sbyte)(randomBuff);

                            spider = new Spider();

                            spider.Attack += (sbyte)(randomBuff);
                            spider.Health += (sbyte)(randomBuff);
                            spider.Defense += (sbyte)(randomBuff);
                        }
                    }

                    Console.WriteLine("Game ended!\n");
                    break;

                case 2:
                    Console.WriteLine("\nBye!\n");
                    break;
            }
        }
        }
    }