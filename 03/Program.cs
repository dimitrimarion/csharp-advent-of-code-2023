using UtilsLibrary;
using System.Text.RegularExpressions;

string[] input = FileLibrary.ReadInput("./input.txt");
//FileLibrary.PrintInput(input);

Dictionary<int, int> indexNumbers = new Dictionary<int, int>();
int inputIndex = 0;
int result = 0;
int result2 = 0;
foreach (string line in input)
{
    int lineIndex = 0;
    foreach (char c in line)
    {
        if (Char.IsDigit(c))
        {
            // If previous characters is a digit, it means we already
            // processed the number
            int previousChar = Math.Max(0, lineIndex - 1);
            if (lineIndex == 0 || !Char.IsDigit(line[previousChar]))
            {
                // Take the next 2 char and keep only the digits
                // As there's no number with more than 3 digits,
                // we'll always extract the correct number by
                // removing the dots and special characters
                if (!Char.IsDigit(line[lineIndex + 1]) && Char.IsDigit(line[lineIndex + 2]))
                {
                    // example: 2.3, avoid extracting number 23
                    indexNumbers.Add(lineIndex + inputIndex * line.Length, int.Parse(c.ToString()));
                }
                else
                {
                    int maxLength = Math.Min(3, line.Length - lineIndex);
                    string maybeOnlyDigits = line.Substring(lineIndex, maxLength);
                    // Define the pattern for special characters
                    string pattern = "[^0-9]";

                    // Use Regex to replace special characters with an empty string
                    string onlyDigits = Regex.Replace(maybeOnlyDigits, pattern, "");
                    indexNumbers.Add(lineIndex + inputIndex * line.Length, int.Parse(onlyDigits));
                }
            }
        }
        lineIndex++;
    }
    inputIndex++;
}

inputIndex = 0;
foreach (string line in input)
{
    int lineIndex = 0;
    foreach (char c in line)
    {
        if (!c.Equals('.') && !Char.IsDigit(c))
        {
            int charIndex = lineIndex + inputIndex * line.Length;
            for (int i = 0; i < 5; i++)
            {
                int previousLine = 0;
                if (indexNumbers.TryGetValue(charIndex - 3 + i - line.Length, out previousLine))
                {
                    bool isAdgacent = true;
                    if (i < 2 && (previousLine.ToString().Length < (3 - i)))
                    {
                        isAdgacent = false;
                    }
                    if (isAdgacent)
                        result += previousLine;
                }
                int currentLine = 0;
                if (indexNumbers.TryGetValue(charIndex - 3 + i, out currentLine))
                {
                    bool isAdgacent = true;
                    if (i < 2 && (currentLine.ToString().Length < (3 - i)))
                    {
                        isAdgacent = false;
                    }
                    if (isAdgacent)
                        result += currentLine;
                }
                int nextLine = 0;
                if (indexNumbers.TryGetValue(charIndex - 3 + i + line.Length, out nextLine))
                {
                    bool isAdgacent = true;
                    if (i < 2 && (nextLine.ToString().Length < (3 - i)))
                    {
                        isAdgacent = false;
                    }
                    if (isAdgacent)
                        result += nextLine;
                }
            }
        }
        // part2
        if (c.Equals('*'))
        {
            int charIndex = lineIndex + inputIndex * line.Length;
            List<int> gearNumbers = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                int previousLine = 0;
                if (indexNumbers.TryGetValue(charIndex - 3 + i - line.Length, out previousLine))
                {
                    bool isAdgacent = true;
                    if (i < 2 && (previousLine.ToString().Length < (3 - i)))
                    {
                        isAdgacent = false;
                    }
                    if (isAdgacent)
                    {
                        gearNumbers.Add(previousLine);
                    }
                }
                int currentLine = 0;
                if (indexNumbers.TryGetValue(charIndex - 3 + i, out currentLine))
                {
                    bool isAdgacent = true;
                    if (i < 2 && (currentLine.ToString().Length < (3 - i)))
                    {
                        isAdgacent = false;
                    }
                    if (isAdgacent)
                    {
                        gearNumbers.Add(currentLine);
                    }
                }
                int nextLine = 0;
                if (indexNumbers.TryGetValue(charIndex - 3 + i + line.Length, out nextLine))
                {
                    bool isAdgacent = true;
                    if (i < 2 && (nextLine.ToString().Length < (3 - i)))
                    {
                        isAdgacent = false;
                    }
                    if (isAdgacent)
                    {
                        gearNumbers.Add(nextLine);
                    }
                }
            }
            if (gearNumbers.Count == 2)
            {
                result2 += gearNumbers[0] * gearNumbers[1];
            }
        }
        lineIndex++;
    }
    inputIndex++;
}
Console.WriteLine($"Result part 1: {result}");
Console.WriteLine($"Result part 2: {result2}");