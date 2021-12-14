using System;

class Program {

    static void Main() {

        string[] fileLines = System.IO.File.ReadAllLines(@"Input.txt");

        string polymer = fileLines[0];

        Dictionary<string, string> elementMapper = new Dictionary<string, string>();
        for (int i = 2; i < fileLines.Length; i++) {
            string[] split = fileLines[i].Split(" -> ");
            elementMapper.Add(split[0], split[1]);
        }

        Dictionary<string, double> patternCounter = new Dictionary<string, double>();
        for (int i = 0; i < polymer.Length - 1; i++) {
            string key = polymer.Substring(i, 2);
            if (patternCounter.ContainsKey(key)) {
                patternCounter[key]++;
            } else {
                patternCounter[key] = 1;
            }
        }

        for (int i = 0; i < 40; i++) {
            Dictionary<string, double> NewPatternCounter = new Dictionary<string, double>();
            foreach (string key in patternCounter.Keys.ToList()) {
                double count = patternCounter[key];
                string element = elementMapper[key];
                string newFrontPattern = key.Substring(0, 1) + element;
                string newBackPattern = element + key.Substring(1, 1);
                if (NewPatternCounter.ContainsKey(newFrontPattern)) {
                    NewPatternCounter[newFrontPattern] += count;
                } else {
                    NewPatternCounter[newFrontPattern] = count;
                }
                if (NewPatternCounter.ContainsKey(newBackPattern)) {
                    NewPatternCounter[newBackPattern] += count;
                } else {
                    NewPatternCounter[newBackPattern] = count;
                }

                patternCounter[key] = 0;
            }
            patternCounter = NewPatternCounter;
        }

        Dictionary<char, double> charCounter = new Dictionary<char, double>();
        foreach (string charKey in patternCounter.Keys) {
            double count = patternCounter[charKey];

            if (charCounter.ContainsKey(charKey[0])) {
                charCounter[charKey[0]] += 0.5 * count;
            } else {
                charCounter[charKey[0]] = 0.5 * count;
            }

            if (charCounter.ContainsKey(charKey[1])) {
                charCounter[charKey[1]] += 0.5 * count;
            } else {
                charCounter[charKey[1]] = 0.5 * count;
            }
        }

        charCounter[polymer[0]] += 0.5;
        charCounter[polymer[polymer.Length - 1]] += 0.5;


        double min = 1e99, max = 0;
        foreach (char key in charCounter.Keys) {
            double val = charCounter[key];
            if (val < min) {
                min = val;
            }
            if (val > max) {
                max = val;
            }
        }

        double solution = max - min;
        Console.WriteLine($"solution: {solution}");

    }

}