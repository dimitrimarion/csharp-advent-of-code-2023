using UtilsLibrary;

string[] input = FileLibrary.ReadInput("./input.txt");
//FileLibrary.PrintInput(input);

double result = 0;
int index = 0;
List<int> cards = Enumerable.Repeat(1, input.Length).ToList();

foreach (string line in input)
{
    string[] numbers = line.Split(":")[1].Split("|");
    string winningNumbers = numbers[0];
    string yourNumbers = numbers[1];
    int[] winningNumbersArray = winningNumbers.Trim()
                                              .Split()
                                              .Where(el => !string.IsNullOrEmpty(el))
                                              .Select(el => int.Parse(el)).ToArray();
    int[] yourNumbersArray = yourNumbers.Trim()
                                        .Split()
                                        .Where(el => !string.IsNullOrEmpty(el))
                                        .Select(el => int.Parse(el)).ToArray();

    HashSet<int> winningNumbersSet = new HashSet<int>(winningNumbersArray);
    HashSet<int> yoursNumbersSet = new HashSet<int>(yourNumbersArray);
    winningNumbersSet.IntersectWith(yoursNumbersSet);

    if (winningNumbersSet.Count > 0)
    {
        result += Math.Pow(2, winningNumbersSet.Count - 1);
    }

    for (int i = 0; i < cards[index]; i++)
    {
        for (int j = 0; j < winningNumbersSet.Count; j++)
        {
            cards[index + 1 + j] += 1;
        }
    }
    index++;
}

int totalCards = cards.Sum();
Console.WriteLine($"Result part 1: {result}");
Console.WriteLine($"Result part 2: {totalCards}");