using System;

class Program {
    public static void Main() {

        string[] fileLines = System.IO.File.ReadAllLines(@"Input.txt");
        int[,] data = new int[fileLines.Length, fileLines[0].Length];

        // Data to Matrix
        for (int i = 0; i < fileLines.Length; i++) {
            for (int j = 0; j < fileLines[i].Length; j++) {
                data[i, j] = int.Parse(fileLines[i][j].ToString());
            }
        }

        // Solve p1
        int p1 = 0;
        for (int i = 0; i < data.GetLength(0); i++) {
            for (int j = 0; j < data.GetLength(1); j++) {
                int value = data[i, j];
                if (i > 0 && value >= data[i - 1, j]) continue;
                if (j > 0 && value >= data[i, j - 1]) continue;

                if (i < data.GetLength(0) - 1 && value >= data[i + 1, j]) continue;
                if (j < data.GetLength(1) - 1 && value >= data[i, j + 1]) continue;

                p1 += value + 1;
            }
        }

        // Solve p2
        List<int> basinCounts = new List<int>();

        // Find Low Point
        for (int y = 0; y < data.GetLength(0); y++) {
            for (int x = 0; x < data.GetLength(1); x++) {
                int value = data[y, x];
                if (y > 0 && value >= data[y - 1, x]) continue;
                if (x > 0 && value >= data[y, x - 1]) continue;

                if (y < data.GetLength(0) - 1 && value >= data[y + 1, x]) continue;
                if (x < data.GetLength(1) - 1 && value >= data[y, x + 1]) continue;

                // Low Point found

                List<int> ToLookAt = new List<int>();
                List<int> AlreadyLookedAt = new List<int>();

                ToLookAt.Add(y * 100 + x);

                while (ToLookAt.Count > 0) {
                    int lookingAt = ToLookAt[0];
                    AlreadyLookedAt.Add(lookingAt);
                    ToLookAt.Remove(lookingAt);

                    int X = lookingAt % 100;
                    int Y = (lookingAt - X) / 100;

                    if (Y > 0 && data[Y - 1, X] != 9 && !AlreadyLookedAt.Contains((Y - 1) * 100 + X)) ToLookAt.Add((Y - 1) * 100 + X);
                    if (X > 0 && data[Y, X - 1] != 9 && !AlreadyLookedAt.Contains(Y * 100 + (X - 1))) ToLookAt.Add(Y * 100 + (X - 1));

                    if (Y < data.GetLength(0) - 1 && data[Y + 1, X] != 9 && !AlreadyLookedAt.Contains((Y + 1) * 100 + X)) ToLookAt.Add((Y + 1) * 100 + X);
                    if (X < data.GetLength(1) - 1 && data[Y, X + 1] != 9 && !AlreadyLookedAt.Contains(Y * 100 + (X + 1))) ToLookAt.Add(Y * 100 + (X + 1));

                    ToLookAt = ToLookAt.Distinct().ToList();
                    AlreadyLookedAt = AlreadyLookedAt.Distinct().ToList();
                }

                basinCounts.Add(AlreadyLookedAt.Count());
            }
                
        }

        basinCounts.Sort((a, b) => { return b - a; });
        int p2 = basinCounts[0] * basinCounts[1] * basinCounts[2];

        Console.WriteLine($"Solution p1: {p1}");
        Console.WriteLine($"Solution p2: {p2}");

    }
}