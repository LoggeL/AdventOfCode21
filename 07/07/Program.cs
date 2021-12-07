using System;

class Program {
    static void Main(string[] args) {

        string[] linesFile = System.IO.File.ReadAllLines(@"Input.txt");

        double[] inputs = linesFile[0].Split(',').Select(double.Parse).ToArray();

        // Elegant Solution for a)
        // https://rosettacode.org/wiki/Averages/Median#C.23
        //inputs = inputs.OrderBy(i => i).ToArray();
        // or Array.Sort(myArr) for in-place sort

        //int mid = inputs.Length / 2;
        //double median;

        //if (inputs.Length % 2 == 0) {
        //we know its even
        //    median = (inputs[mid] + inputs[mid - 1]) / 2.0;
        //}
        //else {
        //we know its odd
        //    median = inputs[mid];
        //}

        // Brute Force Solution :( for b)
        int min = (int)inputs.Min();
        int max = (int)inputs.Max();

        double[] costs = new double[max - min];

        for (int i = 0; i < costs.Length; i++) {
            costs[i] = 0;
            int median = i + min;
            for (int j = 0; j < inputs.Length; j++) {
                // Sum 1toN is N * (N + 1) / 2
                double val = Math.Abs(inputs[j] - median);
                costs[i] += Math.Abs(val * (val + 1) / 2);
                //Console.WriteLine($"median {median} input {inputs[j]} error {(inputs[j] - median) * (inputs[j] - median + 1) / 2}");
            }
        }

        int lowestCost = (int)costs.Min();
        int lowestMedian = Array.IndexOf(costs, lowestCost);


        Console.WriteLine($"Median: {lowestMedian}. Solution: {lowestCost}");

        return;
    }
}