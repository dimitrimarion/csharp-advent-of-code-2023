using UtilsLibrary;

string[] input = FileLibrary.ReadInput("./input.txt");
FileLibrary.PrintInput(input);

Dictionary<string, int> cubesInBag = new Dictionary<string, int>
{
    {"red", 12},
    {"green", 13},
    {"blue", 14}
};

int gameIndex = 1;
int gameIndexSum = 0;
foreach (string line in input)
{
    //    Console.WriteLine(String.Join("|", line.Split(":")));
    string[] cubesSet = line.Split(":")[1].Split(";");
    Console.WriteLine(String.Join("|", cubesSet));
    bool gameValid = true;
    foreach (string set in cubesSet)
    {
        if (!gameValid)
            break;

        string[] colorsSet = set.Split(",");
        Console.WriteLine(String.Join("|", colorsSet));
        foreach (string color in colorsSet)
        {
            string[] cube = color.Trim().Split();
            string cubeColor = cube[1];
            int cubeValue = int.Parse(cube[0]);
            Console.WriteLine(String.Join("|", cube));
            int cubeColorValue;
            if (cubesInBag.TryGetValue(cubeColor, out cubeColorValue))
            {
                if (cubeValue > cubeColorValue)
                {
                    gameValid = false;
                    break;
                }
            }
        }
    }
    if (gameValid)
        gameIndexSum += gameIndex;
    gameIndex++;
}
Console.WriteLine($"Result {gameIndexSum}");