using System;

class Program {
    static void Main(string[] args) {

        string[] lines = System.IO.File.ReadAllLines(@"Input.txt");
        var inputs = lines[0].Split(',').Select(int.Parse).ToArray();

        int days = 256; //80;

        double[] timers = new double[10];

        for (int i = 0; i < inputs.Length; i++) {
            timers[inputs[i]] += 1;
        }

        for (int i = 0; i < days; i++) {
            timers[9] += timers[0];
            timers[7] += timers[0];
            for (int j = 0; j < timers.Length - 1; j++) {
                timers[j] = timers[j + 1];
            }
            timers[9] = 0;
        }

        double sum = 0;
        for (int j = 0; j < timers.Length - 1; j++) {
            sum += timers[j];
        }

        Console.WriteLine($"Solution Population: {sum}");

        return;
    }
}