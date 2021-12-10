using System;

class Program {
    public static void Main() {

        Dictionary<char, char> inverse = new Dictionary<char, char>();
        inverse.Add('}', '{');
        inverse.Add(')', '(');
        inverse.Add('>', '<');
        inverse.Add(']', '[');
        inverse.Add('{', '}');
        inverse.Add('(', ')');
        inverse.Add('<', '>');
        inverse.Add('[', ']');

        Dictionary<char, int> points = new Dictionary<char, int>();
        points.Add(')', 3);
        points.Add(']', 57);
        points.Add('}', 1197);
        points.Add('>', 25137);

        Dictionary<char, int> pointsP2 = new Dictionary<char, int>();
        pointsP2.Add(')', 1);
        pointsP2.Add(']', 2);
        pointsP2.Add('}', 3);
        pointsP2.Add('>', 4);

        int p1 = 0;
        double p2 = 0;

        List<double> p2Scores = new List<double>();

        string[] fileLines = System.IO.File.ReadAllLines(@"Input.txt");

        for (int i = 0; i < fileLines.Length; i++) {

            List<char> charArray = fileLines[i].ToCharArray().ToList();

            for (int j = 0; j < charArray.Count; j++) {
                if (charArray[j] == '(' || charArray[j] == '{' || charArray[j] == '<' || charArray[j] == '[') {
                    
                }
                else {
                    if (charArray[j - 1] != inverse[charArray[j]]) {
                        Console.WriteLine($"Illegal: {charArray[j]}");
                        p1 += points[charArray[j]];
                        fileLines[i] = "";
                        break;
                    } else {
                        charArray.RemoveAt(j);
                        charArray.RemoveAt(j - 1);
                        j = j - 2;
                    }
                }
            }

            // p2
            double p2SubScore = 0;
            if (fileLines[i].Length == 0) continue;
            for (int j = charArray.Count - 1; j >= 0; j--) {
                char closing = inverse[charArray[j]];
                p2SubScore *= 5;
                p2SubScore += pointsP2[closing];
            }
            p2Scores.Add(p2SubScore);
        }

        p2Scores = p2Scores.OrderBy(d => d).ToList();
        p2 = p2Scores[(int)(p2Scores.Count * 0.5)];

        Console.WriteLine($"p1: {p1}");
        Console.WriteLine($"p2: {p2}");
    }
}