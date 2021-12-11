using System;

class Program {
    public static void Main() {

        string[] fileLines = System.IO.File.ReadAllLines(@"Input.txt");

        int[,] octo = new int[fileLines.Length, fileLines[0].Length];

        for (int i = 0; i < octo.GetLength(0); i++) {
            char[] charArray = fileLines[i].ToCharArray();
            for (int j = 0; j < octo.GetLength(1); j++) {
                octo[i, j] = int.Parse(charArray[j].ToString());
            }
        }

        int[,] flashed = new int[octo.GetLength(0), octo.GetLength(1)];

        int p1 = 0;
        int p2 = 0;

        for (int iterations = 0; iterations < 1000; iterations++) {
            Array.Clear(flashed, 0, flashed.Length);
            for (int i = 0; i < octo.GetLength(0); i++) {
                for (int j = 0; j < octo.GetLength(1); j++) {
                    octo[i, j]++;
                    if (octo[i ,j] > 9) {
                        flash(i, j);
                    }
                }
            }
            for (int i = 0; i < octo.GetLength(0); i++) {
                for (int j = 0; j < octo.GetLength(1); j++) {
                    if (octo[i, j] > 9) octo[i, j] = 0;
                }
            }

            // p2 
            if (octo.Cast<int>().Sum() == 0) {
                p2 = iterations + 1;
                break;
            }
        }
        Console.WriteLine($"p1: {p1}");
        Console.WriteLine($"p2: {p2}");

        void flash(int i, int j) {
            if (flashed[i, j] == 1) return;
            flashed[i, j] = 1; 
            p1++;
            for (int i2 = -1; i2 <= 1; i2++) {
                for (int j2 = -1; j2 <= 1; j2++) {
                    if (i + i2 >= 0 && i + i2 < octo.GetLength(0) && j + j2 >= 0 && j + j2 < octo.GetLength(1)) {
                        octo[i + i2,j + j2]++;
                        if (octo[i + i2, j + j2] > 9) flash(i + i2, j + j2);
                    }
                }
            }
            //if (i > 0 && j > 0) octo[i - 1, j - 1]++;
            //if (i > 0) octo[i - 1, j]++;
            //if (i > 0 && j < octo.GetLength(1) - 1) octo[i - 1, j + 1]++;
            //if (j > 0) octo[i, j - 1]++;
            //if (j < octo.GetLength(1) - 1) octo[i, j + 1]++;
            //if (i < octo.GetLength(0) - 1 && j > 0) octo[i + 1, j - 1]++;
            //if (i < octo.GetLength(0) - 1) octo[i + 1, j]++;
            //if (i < octo.GetLength(0) - 1 && j < octo.GetLength(1) - 1) octo[i + 1, j + 1]++;
        }
    }
}