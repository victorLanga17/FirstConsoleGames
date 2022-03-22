using System;

namespace ExternalSources
{
    public class AsciiElements
    {
        public static void PrintSnakeTitle()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("   ▄████████ ███▄▄▄▄      ▄████████    ▄█   ▄█▄    ▄████████");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("  ███    ███ ███▀▀▀██▄   ███    ███   ███ ▄███▀   ███    ███");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("  ███    █▀  ███   ███   ███    ███   ███▐██▀     ███    █▀");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("  ███        ███   ███   ███    ███  ▄█████▀     ▄███▄▄▄");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("▀███████████ ███   ███ ▀███████████ ▀▀█████▄    ▀▀███▀▀▀");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("         ███ ███   ███   ███    ███   ███▐██▄     ███    █▄");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("   ▄█    ███ ███   ███   ███    ███   ███ ▀███▄   ███    ███");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(" ▄████████▀   ▀█   █▀    ███    █▀    ███   ▀█▀   ██████████");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.Write("                                      ▀");
            Console.ResetColor();
            Console.WriteLine("          by Victor Langa");
        }

        public static void PrintSnakeDrawing()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"           /^\/^\");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"         _|__|  O|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@"                    \/"); 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(@"     /~     ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(@"\_/");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@" \");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@"                     \____"); 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"|__________/  \");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"        \_______      \");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"                `\     \                 \");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"                  |     |                  \");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"                 /      /                    \");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"                /     /                       \\");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"              /      /                         \ \");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"             /     /                            \  \");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"           /     /             _----_            \   \");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"          /     /           _-~      ~-_         |   |");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"         (      (        _-~    _--_    ~-_     _/   |");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"          \      ~-____-~    _-~    ~-_    ~-_-~    /");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"            ~-_           _-~          ~-_       _-~");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"               ~--______-~                ~-___-~");
            Console.ResetColor();
        }

        public static void PrintSnakeVictory()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("▄██   ▄    ▄██████▄  ███    █▄        ▄█     █▄   ▄██████▄  ███▄▄▄▄");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("███   ██▄ ███    ███ ███    ███      ███     ███ ███    ███ ███▀▀▀██▄");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("███▄▄▄███ ███    ███ ███    ███      ███     ███ ███    ███ ███   ███");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("▀▀▀▀▀▀███ ███    ███ ███    ███      ███     ███ ███    ███ ███   ███");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("▄██   ███ ███    ███ ███    ███      ███     ███ ███    ███ ███   ███");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("███   ███ ███    ███ ███    ███      ███     ███ ███    ███ ███   ███");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("███   ███ ███    ███ ███    ███      ███ ▄█▄ ███ ███    ███ ███   ███");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(" ▀█████▀   ▀██████▀  ████████▀        ▀███▀███▀   ▀██████▀   ▀█   █▀\n");
            Console.ResetColor();
        }

        public static void PrintSnakeDefeat()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(" ▄██████▄     ▄█    █▄         ███▄▄▄▄    ▄██████▄");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("███    ███   ███    ███        ███▀▀▀██▄ ███    ███");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("███    ███   ███    ███        ███   ███ ███    ███");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("███    ███  ▄███▄▄▄▄███▄▄      ███   ███ ███    ███");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("███    ███ ▀▀███▀▀▀▀███▀       ███   ███ ███    ███");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("███    ███   ███    ███        ███   ███ ███    ███");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("███    ███   ███    ███        ███   ███ ███    ███");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(" ▀██████▀    ███    █▀          ▀█   █▀   ▀██████▀ ");
            Console.ResetColor();
        }
    }
}