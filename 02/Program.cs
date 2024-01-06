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
int power = 0;
foreach (string line in input)
{
    //    Console.WriteLine(String.Join("|", line.Split(":")));
    string[] cubesSet = line.Split(":")[1].Split(";");
    bool gameValid = true;
    foreach (string set in cubesSet)
    {
        if (!gameValid)
            break;

        string[] colorsSet = set.Split(",");
        foreach (string color in colorsSet)
        {
            string[] cube = color.Trim().Split();
            string cubeColor = cube[1];
            int cubeValue = int.Parse(cube[0]);
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

    Dictionary<string, int> cubesNumbers = new Dictionary<string, int>
    {
        {"blue", 0},
        {"red", 0},
        {"green", 0}
    };

    foreach (string set in cubesSet)
    {
        string[] colorsSet = set.Split(",");
        foreach (string color in colorsSet)
        {
            string[] cube = color.Trim().Split();
            string cubeColor = cube[1];
            int cubeValue = int.Parse(cube[0]);
            int cubeColorValue;
            if (cubesNumbers.TryGetValue(cubeColor, out cubeColorValue))
            {
                if (cubeColorValue < cubeValue)
                {
                    cubesNumbers[cubeColor] = cubeValue;
                }
            }
        }
    }

    int cubesPower = 1;
    foreach (KeyValuePair<string, int> kv in cubesNumbers)
    {
        cubesPower *= kv.Value;
    }
    power += cubesPower;
}
Console.WriteLine($"Result {gameIndexSum}");
Console.WriteLine($"Result Power {power}");