// Jaden Olvera, 10-28-25, Lab 8: Maze
Console.Clear();
Console.WriteLine("Welcome to a Maze Game!");
Console.WriteLine("Navigate a maze with your arrow keys and try to reach the \"*\"!");
string[] mapRows = File.ReadAllLines("map.txt");
foreach (string row in mapRows)
{
    Console.WriteLine(row);
}
int[] currentCoordinates = [0, 2];
Console.SetCursorPosition(currentCoordinates[0],currentCoordinates[1]);
ConsoleKey lastKey;
do {
    lastKey = Console.ReadKey(true).Key;
    switch (lastKey)
    {
        case ConsoleKey.UpArrow:
            if (TryMove(currentCoordinates[0], currentCoordinates[1] - 1, mapRows) == true)
                currentCoordinates[1]--;
            break;
        case ConsoleKey.DownArrow:
            if (TryMove(currentCoordinates[0], currentCoordinates[1] + 1, mapRows) == true)
                currentCoordinates[1]++;
            break;
        case ConsoleKey.LeftArrow:
            if (TryMove(currentCoordinates[0] - 1, currentCoordinates[1], mapRows) == true)
                currentCoordinates[0]--;
            break;
        case ConsoleKey.RightArrow:
            if (TryMove(currentCoordinates[0] + 1, currentCoordinates[1], mapRows) == true)
                currentCoordinates[0]++;
            break;
        default:
            break;
    }
    Console.SetCursorPosition(currentCoordinates[0],currentCoordinates[1]);
} while (lastKey != ConsoleKey.Escape);
Console.Clear();

static bool TryMove(int targetX, int targetY, string[] mazeRows)
{
    if (targetX >= 0 && targetX < mazeRows[0].Length && targetY >= 2 && targetY < mazeRows.Length + 2)
    {
        return true;
    }
    else
        return false;
}