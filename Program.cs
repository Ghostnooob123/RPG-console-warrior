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

            while (player.Health > 0) 
            {
                if (wins > 0) 
                {
                    Console.WriteLine("Player won! \n");
                    player.PlayerUpgrade(random);
                }
                Console.WriteLine("Fight begin!\n");
                Thread.Sleep(1500);

                int randomNumber = random.Next(0, 101);

                int phase = 0;

                while (goblin.Health >= 0|| spider.Health >= 0) 
                {
                    int turn = random.Next(1, 3);

                    Console.WriteLine($"Phase: {phase++}");

                    if (randomNumber <= 50)
                    {
                        Console.WriteLine($"Player health: {{{player.Health}}}\n");
                        Console.WriteLine($"Goblin health: {{{goblin.Health}}}\n");

                        Thread.Sleep(1500);

                        if (turn > 1) {
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
                            goblin.DealDamage(player, goblin.Attack);
                            if (player.Health <= 0)
                            {
                                Console.WriteLine($"\nPlayer Died!");
                                break;
                            }

                            Console.WriteLine('\n');
                            Thread.Sleep(1500);

                            player.DealDamage(goblin, player.Attack);
                            if (goblin.Health <= 0)
                            {
                                Console.WriteLine($"\nGoblin Died!");
                                break;
                            }

                            Thread.Sleep(1500);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Player health: {{{player.Health}}}\n");
                        Console.WriteLine($"Goblin health: {{{spider.Health}}}\n");

                        Thread.Sleep(1500);

                        if (turn > 1)
                        {
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
                        else
                        {
                            spider.DealDamage(player, spider.Attack);
                            if (player.Health <= 0)
                            {
                                Console.WriteLine($"\nPlayer Died!");
                                break;
                            }

                            Console.WriteLine('\n');
                            Thread.Sleep(1500);

                            player.DealDamage(spider, player.Attack);
                            if (spider.Health <= 0)
                            {
                                Console.WriteLine($"\nSpider Died!");
                                break;
                            }

                            Thread.Sleep(1500);
                        }
                    }

                    Console.WriteLine('\n');
                }

                Thread.Sleep(1500);

                if (player.Health > 0)
                {
                    wins++;

                    goblin = new Goblin();

                    goblin.Attack += (sbyte) (wins + 2);
                    goblin.Health += (sbyte) (wins + 2);
                    goblin.Defense += (sbyte) (wins + 2);

                    spider = new Spider();

                    spider.Attack += (sbyte) (wins + 2);
                    spider.Health += (sbyte) (wins + 2);
                    spider.Defense += (sbyte) (wins + 2);
                }
            }

            Console.WriteLine("Game ended!\n");
        }
    }
}