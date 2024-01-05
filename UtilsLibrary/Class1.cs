namespace UtilsLibrary;

public static class FileLibrary
{
    public static string[] ReadInput(string path)
    {
        string[] readText = [];
        if (File.Exists(path))
        {
            readText = File.ReadAllLines(path);
        }
        return readText;
    }

    public static void PrintInput(string[] input)
    {
        foreach (string line in input)
        {
            Console.WriteLine(line);
        }
    }

}
