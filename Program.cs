using App1;
using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Threading;
using System.Collections;

namespace MyApp
{
    internal class Program
    {
        const sbyte enemiesBuffer = 50;

        public static void GetEnemies(List<IEnemy> enemies)
        {
            Random random = new Random();

            for (int i = 0; i < enemiesBuffer; i++)
            {
                int randomMonster = random.Next(0, 101);

                if (randomMonster <= 50)
                {
                    if (i > 1)
                    {
                        int randomBuff = random.Next(1, 6);
                        Goblin goblin = new Goblin();

                        goblin.Attack += (sbyte) randomBuff;
                        goblin.Health += (sbyte)randomBuff;
                        goblin.Defense += (sbyte)randomBuff;

                        enemies.Add(goblin);
                    }
                    else
                    {
                        enemies.Add(new Goblin());
                    }
                }
                else
                {
                    if (i > 1)
                    {
                        int randomBuff = random.Next(1, 6);
                        Spider spider = new Spider();

                        spider.Attack += (sbyte)randomBuff;
                        spider.Health += (sbyte)randomBuff;
                        spider.Defense += (sbyte)randomBuff;

                        enemies.Add(spider);
                    }
                    else
                    {
                        enemies.Add(new Spider());
                    }
                }

            }
        }
        public static int MenuInput()
        {
            Console.WriteLine("Welcome to RPG Console Warrior\n\n");
            Console.WriteLine("1.Start Game\n");
            Console.WriteLine("2.Quit\n");
            Console.Write(": ");

            int option = int.Parse(Console.ReadLine());

            return option;
        }

        static void Main(string[] args)
        {
            

            switch (MenuInput())
            {
                case 1:
                    Player player = new Player();

                    List<IEnemy> enemies = new List<IEnemy>();
                    GetEnemies(enemies);

                    int wins = 0;
                    Random random = new Random();

                    for (int i = 0; i < enemiesBuffer; i++)
                    {
                        Console.Clear();

                        if (wins > 0)
                        {
                            Console.WriteLine("Player won! \n");
                            player.PlayerUpgrade(random);
                        }
                        Console.WriteLine($"Level: {wins}\n");
                        Thread.Sleep(1500);

                        int randomNumber = random.Next(0, 101);

                        int phase = 1;

                        while (enemies[i].Health >= 0)
                        {
                            Console.WriteLine($"\nPhase: {phase++}");
                            Thread.Sleep(1500);

                            Console.WriteLine($"Player vs {enemies[i].Type} \n");
                            Thread.Sleep(1500);
                            Console.WriteLine($"Player health: {{{player.Health}}} attack: {{{player.Attack}}} defense: {{{player.Defense}}}");
                            Console.WriteLine($"{enemies[i].Type} health: {{{enemies[i].Health}}} attack: {{{enemies[i].Attack}}} defense: {{{enemies[i].Defense}}}\n");

                            Thread.Sleep(2000);

                            Player.DealDamage(enemies[i], player.Attack);
                            if (enemies[i].Health <= 0)
                            {
                                Console.WriteLine($"\n{enemies[i].Type} Died!");
                                Thread.Sleep(1500);
                                break;
                            }

                            Console.WriteLine('\n');
                            Thread.Sleep(2000);

                            enemies[i].DealDamage(player, enemies[i].Attack);
                            if (player.Health <= 0)
                            {
                                Console.WriteLine($"\nPlayer Died!");
                                Thread.Sleep(1500);
                                break;
                            }
                        }

                        wins++;

                        Console.WriteLine("Press Enter to continue....");

                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        while (keyInfo.Key != ConsoleKey.Enter)
                        {

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