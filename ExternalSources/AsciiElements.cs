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
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop + 5);
            Console.WriteLine(@"           /^\/^\");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"         _|__|  O|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.Write(@"\/"); 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(@"     /~     ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(@"\_/");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@" \");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.Write(@"\____"); 
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

        public static void PrintMinesweeperTitle()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"  __  __ _");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@" |  \/  (_)");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@" | \  / |_ _ __   ___  _____      _____  ___ _ __   ___ _ __");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@" | |\/| | | '_ \ / _ \/ __\ \ /\ / / _ \/ _ \ '_ \ / _ \ '__|");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@" | |  | | | | | |  __/\__ \\ V  V /  __/  __/ |_) |  __/ |");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@" |_|  |_|_|_| |_|\___||___/ \_/\_/ \___|\___| .__/ \___|_|");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine(@"                                            | |");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.CursorTop);
            Console.WriteLine("                                            |_|\n\n\n\n\n");
            Console.ResetColor();
        }

        public static void PrintMinesweeperMineDrawing()
        {
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("                             @@@                            ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("                           &@ %@@#                          ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("               &@@   &@@*,,,,,,,****%@@#  &@@#              ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("              @@@ %@@,     .,   ,   .,,&@@, @@@             ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("               @@@,  .,   (*,,,,,,,,/(,,,@@@@#              ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("               @@ .....,,,///,,,///,%@(*,@@@@#              ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("              @,  .,(,,,/(((((((/(((*,(&@(&@@@@             ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("           @@@@*,,  (,,(((@,  *(@#(((((&@(&@@@@@@@          ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("         @@&&&@*.  .,,,(((@(**%@@@@@##@((@@@@@@@@@@#        ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("           @@@@*, .,,,,((((&@@@@@@@@#((&@(&@@@@@@@          ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("              @@@(,,,/(@#(@#(@@@@@@@#(@#(@@@@@@             ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("               @@@@@#&@@##@##@((#@@@##@@@@@@@#              ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("                 @@@@@@(&@@#/@@@@@@@@@@@@@@@                ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("               @@(&@@@@@@@@@@@@@@@@@@@@@@@#(@#              ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("                #@@@####@@@@@@@@@@@@%####@@@#               ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("                           &@@#(@#                          ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, Console.CursorTop);
            Console.WriteLine("                             @@@                            ");
            
        }

        public static void PrintMinesweeperBoom()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0, j = -20; i < 2; i++, j += 30)
            {
                Console.WriteLine();
                Console.SetCursorPosition(Console.WindowWidth / 4 + j, Console.CursorTop);
                Console.WriteLine("    __                        ");
                Console.SetCursorPosition(Console.WindowWidth / 4 + j, Console.CursorTop);
                Console.WriteLine(@"   / /_  ____  ____  ____ ___ ");
                Console.SetCursorPosition(Console.WindowWidth / 4 + j, Console.CursorTop);
                Console.WriteLine(@"  / __ \/ __ \/ __ \/ __ `__ \");
                Console.SetCursorPosition(Console.WindowWidth / 4 + j, Console.CursorTop);
                Console.WriteLine(@" / /_/ / /_/ / /_/ / / / / / /");
                Console.SetCursorPosition(Console.WindowWidth / 4 + j, Console.CursorTop);
                Console.WriteLine(@"/_.___/\____/\____/_/ /_/ /_/ ");
            }
            Console.ResetColor();
        }
    }
}