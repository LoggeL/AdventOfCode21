using System;

class Program {

    public static void Main() {

        int p1 = 0;

        string[] lines = System.IO.File.ReadAllLines(@"Input.txt");

        int p2 = 0;

        for (int i = 0; i < lines.Length; i++) {
            string[] input = lines[i].Split(" | ")[0].Split(" ");
            string[] output = lines[i].Split(" | ")[1].Split(" ");

            // p1;
            for (int j = 0; j < output.Length; j++) {
                int len = output[j].Length;
                if (len == 2 || len == 4 || len == 3 || len == 7) p1++;
            }

            Console.WriteLine($"Solution p1: {p1}");

            // p2;
            string[] patterns = new string[10];

            // Easy Base Patterns
            for (int j = 0; j < input.Length; j++) {
                int len = input[j].Length;
                switch (len) {
                    case 2: patterns[1] = input[j]; break; // 1
                    case 3: patterns[7] = input[j]; break; // 7
                    case 4: patterns[4] = input[j]; break; // 4
                    case 7: patterns[8] = input[j]; break; // 8
                }
            }

            // Find 6
            patterns[6] = input.First(input => input.Length == 6 && !patterns[7].ToCharArray().All(c => input.Contains(c)));
             

            input = Array.FindAll(input, c => !patterns.Contains(c));

            // Find 9 
            patterns[9] = input.First(input => input.Length == 6 && patterns[4].ToCharArray().All(c => input.Contains(c)));

            input = Array.FindAll(input, c => !patterns.Contains(c));

            // Find 0
            patterns[0] = input.First(input => input.Length == 6);

            // Find 3
            patterns[3] = input.First(input => input.Length == 5 && patterns[7].ToCharArray().All(c => input.Contains(c)));

            input = Array.FindAll(input, c => !patterns.Contains(c));

            // Find 5
            patterns[5] = input.First(input => input.Length == 5 && input.ToCharArray().All(c => patterns[9].Contains(c)));

            input = Array.FindAll(input, c => !patterns.Contains(c));

            // Find 2 
            patterns[2] = input.First();

            // Sort Patterns
            for (int j  = 0; j < patterns.Length; j++) {
                patterns[j] = String.Concat(patterns[j].OrderBy(c => c));
            }

            int number = 0;  
            for (int j = 0; j < output.Length; j++) {

                string sorted = String.Concat(output[j].OrderBy(c => c));
                int pos = Array.IndexOf(patterns, sorted);

                number += (int)Math.Pow(10, output.Length - j - 1) * pos;
                
            }
            p2 += number;

        }
        Console.WriteLine($"Solution p2: {p2}");

        return;
        
    }

}