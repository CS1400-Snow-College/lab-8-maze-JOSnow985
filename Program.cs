// Jaden Olvera, 10-28-25, Lab 8: Maze
Console.Clear();
Console.WriteLine("Welcome to a Maze Game!");
Console.WriteLine("Navigate a maze with your arrow keys and try to reach the \"*\"!");
Console.Write("Press enter to start playing!  ");
Console.ReadKey();
Console.Clear();

// Get the map from the file and print it
string[] mapRows = File.ReadAllLines("map.txt");
foreach (string row in mapRows)
{
    Console.WriteLine(row);
}
Console.WriteLine("Navigate with your arrow keys to reach the \"*\"!");

// Set up an int array to hold the initial x and y coordinates
int[] currentCoordinates = [0, 0];
Console.SetCursorPosition(currentCoordinates[0],currentCoordinates[1]);

// Get ready to keep track of what the last key pressed was
ConsoleKey lastKey;

// Main loop, playing on the maze already printed
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

    // If the cursor is on top of the *, exit loop
    if (mapRows[Console.CursorTop][Console.CursorLeft] == '*')
    {
        Thread.Sleep(500);
        break;
    }
} while (lastKey != ConsoleKey.Escape);

//Clear Map away
Console.Clear();

// ASCII Art credit: patorjk.com/software/taag/
string[] winScreen = File.ReadAllLines("winscreen.txt");
foreach (string row in winScreen)
{
    Console.WriteLine(row);
}

// Method for checking if an attempted move is valid
static bool TryMove(int targetX, int targetY, string[] mazeRows)
{
    if (targetX < 0)
        return false;
    else if (targetX > mazeRows[0].Length - 1)
        return false;
    else if (targetY < 0)
        return false;
    else if (targetY > mazeRows.Length - 1)
        return false;
    else
        return true;
}