using System.Text;

namespace task2;

internal static class Task2
{
    public static void Main()
    {
        var text = Console.ReadLine();
        var dg = new DiagramGenerator(text!);
        Console.WriteLine(dg.GetDiagram());
    }
}


internal class DiagramGenerator
{
    private const int DIAGRAMLENGHT = 10;
    private const char COUNTINGCHAR = '.';
    private const char PADDINGNGCHAR = '_';
    
    private readonly List<KeyValuePair<string, int>> _frequencies = new List<KeyValuePair<string, int>>();

    public DiagramGenerator(string text)
    {
        _frequencies = InitFrequencies(text);
    }


    public string GetDiagram()
    {
        var sb = new StringBuilder();
        
        var maxFrequency = _frequencies.Max(x => x.Value);
        
        foreach (var (word, frequency) in _frequencies)
        {
            var diagramLength = (int)Math.Round((double)frequency / maxFrequency * DIAGRAMLENGHT);

            var dots = new string(COUNTINGCHAR, diagramLength).PadRight(DIAGRAMLENGHT);
            sb.Append($"{word.PadLeft(_frequencies.Max(x => x.Key.Length), PADDINGNGCHAR)} {dots}");
            sb.Append('\n');
        }

        return sb.ToString();

    }

    private static List<KeyValuePair<string, int>> InitFrequencies(string inputString)
    {
        var frequencies = new Dictionary<string, int>();
        var text = inputString.Split(' ');

        foreach (var word in text)
        {
            if (frequencies.ContainsKey(word))
            {
                frequencies[word]++;
            }
            else
            {
                frequencies[word] = 1;
            }
        }

        return frequencies
            .OrderBy(x => x.Value)
            .ToList();
    }
}