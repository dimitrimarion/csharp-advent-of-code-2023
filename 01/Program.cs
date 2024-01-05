using System.Text;

Dictionary<string, string> digitMapping = new Dictionary<string, string>
{
    { "one", "1" },
    { "two", "2" },
    { "three", "3" },
    { "four", "4" },
    { "five", "5" },
    { "six", "6" },
    { "seven", "7" },
    { "eight", "8" },
    { "nine", "9" }
};

string path = "./input.txt";
if (File.Exists(path))
{
    string[] readText = File.ReadAllLines(path);
    int calibrationsSum = 0;
    foreach (string line in readText)
    {
        Console.WriteLine(line);
        StringBuilder sb = new StringBuilder();
        StringBuilder sbDigits = new StringBuilder();
        foreach (char c in line)
        {
            int number;
            bool isInt = int.TryParse(new string([c]), out number);
            if (isInt)
            {
                sb.Append(c);
                sbDigits.Clear();
            }
            else
            {
                sbDigits.Append(c);
                string sbDigitsStr = sbDigits.ToString();

                foreach (var pair in digitMapping)
                {
                    if (sbDigitsStr.Contains(pair.Key))
                    {
                        sb.Append(pair.Value);
                        sbDigits.Clear();
                        sbDigits.Append(c);
                    }
                }
            }
        }
        string numbers = sb.ToString();
        Console.WriteLine(numbers);
        string calibration = new string([numbers[0], numbers[numbers.Length - 1]]);
        int calibrationInt = Int32.Parse(calibration);
        calibrationsSum += calibrationInt;
        Console.WriteLine(calibration);
        Console.WriteLine("");
    }
    Console.WriteLine(calibrationsSum);
}