int increase = 0;
int previous = 0;
int rollingAverage = 3;

string[] lines = System.IO.File.ReadAllLines(@"Input.txt");
for (int i = 0; i <= lines.Length - rollingAverage; i++) {
    int value = 0;
    for (int j = 0; j < rollingAverage; j++) {
        value += int.Parse(lines[i + j]);
    }
    if (previous != 0 && value > previous) {
        increase++;
    }
    previous = value;
}

Console.WriteLine($"Number of decreases is {increase}!");