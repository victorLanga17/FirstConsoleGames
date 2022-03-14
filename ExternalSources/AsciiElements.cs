using System;

namespace ExternalSources
{
    public class AsciiElements
    {
        public static void PrintSnakeTitle()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("                       ▄████████ ███▄▄▄▄      ▄████████    ▄█   ▄█▄    ▄████████");
            Console.WriteLine("                      ███    ███ ███▀▀▀██▄   ███    ███   ███ ▄███▀   ███    ███");
            Console.WriteLine("                      ███    █▀  ███   ███   ███    ███   ███▐██▀     ███    █▀");
            Console.WriteLine("                      ███        ███   ███   ███    ███  ▄█████▀     ▄███▄▄▄");
            Console.WriteLine("                    ▀███████████ ███   ███ ▀███████████ ▀▀█████▄    ▀▀███▀▀▀");
            Console.WriteLine("                             ███ ███   ███   ███    ███   ███▐██▄     ███    █▄");
            Console.WriteLine("                       ▄█    ███ ███   ███   ███    ███   ███ ▀███▄   ███    ███");
            Console.WriteLine("                     ▄████████▀   ▀█   █▀    ███    █▀    ███   ▀█▀   ██████████");
            Console.Write("                                                          ▀");
            Console.ResetColor();
            Console.WriteLine("          by Victor Langa");
        }

        public static void PrintSnakeDrawing()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"                               /^\/^\");
            Console.WriteLine(@"                             _|__|  O|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@"                    \/"); // rojo
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(@"     /~     ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(@"\_/");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@" \");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@"                     \____"); //rojo
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"|__________/  \");
            Console.WriteLine(@"                            \_______      \");
            Console.WriteLine(@"                                    `\     \                 \");
            Console.WriteLine(@"                                      |     |                  \");
            Console.WriteLine(@"                                     /      /                    \");
            Console.WriteLine(@"                                    /     /                       \\");
            Console.WriteLine(@"                                  /      /                         \ \");
            Console.WriteLine(@"                                 /     /                            \  \");
            Console.WriteLine(@"                               /     /             _----_            \   \");
            Console.WriteLine(@"                              /     /           _-~      ~-_         |   |");
            Console.WriteLine(@"                             (      (        _-~    _--_    ~-_     _/   |");
            Console.WriteLine(@"                              \      ~-____-~    _-~    ~-_    ~-_-~    /");
            Console.WriteLine(@"                                ~-_           _-~          ~-_       _-~");
            Console.WriteLine(@"                                   ~--______-~                ~-___-~");
            Console.ResetColor();
        }

        public static void PrintSnakeVictory()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                   ▄██   ▄    ▄██████▄  ███    █▄        ▄█     █▄   ▄██████▄  ███▄▄▄▄");   
            Console.WriteLine("                   ███   ██▄ ███    ███ ███    ███      ███     ███ ███    ███ ███▀▀▀██▄"); 
            Console.WriteLine("                   ███▄▄▄███ ███    ███ ███    ███      ███     ███ ███    ███ ███   ███"); 
            Console.WriteLine("                   ▀▀▀▀▀▀███ ███    ███ ███    ███      ███     ███ ███    ███ ███   ███"); 
            Console.WriteLine("                   ▄██   ███ ███    ███ ███    ███      ███     ███ ███    ███ ███   ███");
            Console.WriteLine("                   ███   ███ ███    ███ ███    ███      ███     ███ ███    ███ ███   ███");
            Console.WriteLine("                   ███   ███ ███    ███ ███    ███      ███ ▄█▄ ███ ███    ███ ███   ███");
            Console.WriteLine("                    ▀█████▀   ▀██████▀  ████████▀        ▀███▀███▀   ▀██████▀   ▀█   █▀\n");
            Console.ResetColor();
        }

        public static void PrintSnakeDefeat()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                    ▄██████▄     ▄█    █▄         ███▄▄▄▄    ▄██████▄");
            Console.WriteLine("                   ███    ███   ███    ███        ███▀▀▀██▄ ███    ███");
            Console.WriteLine("                   ███    ███   ███    ███        ███   ███ ███    ███");
            Console.WriteLine("                   ███    ███  ▄███▄▄▄▄███▄▄      ███   ███ ███    ███");
            Console.WriteLine("                   ███    ███ ▀▀███▀▀▀▀███▀       ███   ███ ███    ███");
            Console.WriteLine("                   ███    ███   ███    ███        ███   ███ ███    ███");
            Console.WriteLine("                   ███    ███   ███    ███        ███   ███ ███    ███");
            Console.WriteLine("                    ▀██████▀    ███    █▀          ▀█   █▀   ▀██████▀ ");
            Console.ResetColor();
        }
    }
}