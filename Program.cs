// Jaden Olvera, 10-28-25, Lab 8: Maze
Console.Clear();
Console.WriteLine("Welcome to a Maze Game!");
Console.WriteLine("Navigate a maze with your arrow keys and try to reach the \"*\"!");
string[] mapRows = File.ReadAllLines("map.txt");
foreach (string row in mapRows)
{
    Console.WriteLine(row);
}
int[] currentCoordinates = { 0, 2 };
Console.SetCursorPosition(currentCoordinates[0],currentCoordinates[1]);
ConsoleKey lastKey = ConsoleKey.Enter;
do {
    lastKey = Console.ReadKey(true).Key;
    switch (lastKey)
    {
        case ConsoleKey.UpArrow:
            currentCoordinates[1] -= 1;
            break;
        case ConsoleKey.DownArrow:
            currentCoordinates[1] += 1;
            break;
        case ConsoleKey.LeftArrow:
            currentCoordinates[0] -= 1;
            break;
        case ConsoleKey.RightArrow:
            currentCoordinates[0] += 1;
            break;
        default:
            break;
    }
    Console.SetCursorPosition(currentCoordinates[0],currentCoordinates[1]);
} while (lastKey != ConsoleKey.Escape);
Console.Clear();