namespace TicTacToe
{
    internal class TicTacToe
    {
        private static readonly char[,] field = new char[,]
        {
            {'_', '_', '_' },
            {'_', '_', '_' },
            {'_', '_', '_' },
        };

        private static void PrintField()
        {
            Console.WriteLine($"{field[0, 0]} | {field[0, 1]} | {field[0, 2]}" + Environment.NewLine +
                              $"{field[1, 0]} | {field[1, 1]} | {field[1, 2]}" + Environment.NewLine +
                              $"{field[2, 0]} | {field[2, 1]} | {field[2, 2]}");
        }

        private static void Start()
        {
            char player = 'X';
            char computer = 'O';
            bool game = true;

            for (int i = 0; game == true; i++)
            {
                if (i % 2 == 0)
                {
                    var rd = new Random();
                    Console.WriteLine("Ход компьютера");
                    while (true)
                    {
                        int line = rd.Next(0, 3);
                        int column = rd.Next(0, 3);
                        if (field[line, column] == '_')
                        {
                            field[line, column] = 'O';
                            PrintField();
                            break;
                        }
                    }
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("\r\nСделайте ваш шаг: ");
                        try
                        {
                            string[] step = Console.ReadLine()!.Split(' ', ',', '-');
                            int line = int.Parse(step[0]);
                            int column = int.Parse(step[1]);
                            if (field[line - 1, column - 1] == '_')
                            {
                                field[line - 1, column - 1] = 'X';
                                PrintField();
                                break;
                            }
                            else Console.WriteLine("Неверный шаг");
                        }
                        catch (Exception) { Console.WriteLine("Неверный шаг"); }
                    }
                }

                bool gameTemp1 = CheckRow(field, i % 2 == 0 ? computer : player);
                bool gameTemp2 = CheckColumn(field, i % 2 == 0 ? computer : player);
                bool gameTemp = CheckDiagonal(field, i % 2 == 0 ? computer : player);
                if (!gameTemp1 || !gameTemp2 || !gameTemp)
                {
                    string WinPlayer = i % 2 == 0 ? "Computer" : "Player";
                    Console.WriteLine($"Игрок {WinPlayer} выиграл");
                    game = false;
                }
            }

        }


        private static bool CheckRow(char[,] field, char player)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((field[i, 0] != '_' && field[i, 1] != '_' && field[i, 2] != '_') && 
                    field[i, 0] == player && field[i, 1] == player && field[i, 2] == player)
                {
                    return false;
                }
            }
            return true;
        }
        private static bool CheckColumn(char[,] field, char player)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((field[i, 0] != '_' && field[i, 1] != '_' && field[i, 2] != '_') && 
                    field[i, 0] == player && field[i, 1] == player && field[i, 2] == player)
                {
                    return false;
                }
            }
            return true;
        }
        private static bool CheckDiagonal(char[,] field, char player)
        {
            if ((field[0, 0] != '_' && field[1, 1] != '_' && field[2, 2] != '_') || 
                (field[0, 2] != '_' && field[1, 1] != '_' && field[2, 0] != '_'))
            {
                if (field[0, 0] == player && field[1, 1] == player && field[2, 2] == player)
                    return false;
                if (field[0, 2] == player && field[1, 1] == player && field[2, 0] == player)
                    return false;
            }
            return true;
        }

        private static void Play()
        {
            Console.WriteLine("Инструкция:");
            Console.WriteLine("Игровое поле:");
            PrintField();
            Console.WriteLine("Введите номер строки и столбца, чтобы сделать ход (например 1 3)");
            Console.WriteLine();
            Console.WriteLine("Игра началась...");
            Console.WriteLine();
            Start();
        }
        
        
        static void Main(string[] args)
        {
            Play();
        }
    }
}