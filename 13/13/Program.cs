using System;

class Program {

    static void Main() {

        string[] fileLines = System.IO.File.ReadAllLines(@"Input.txt");

        int[,] paper = new int[2000, 2000];
        int xlimit = 2000; int ylimit = 2000;
        List<string> folds = new List<string>();
        bool setFolds = false;

        for (int i = 0; i < fileLines.Length; i++) {
            if (fileLines[i] == "") {
                setFolds = true;
                continue;
            }

            if (setFolds) {
                folds.Add(fileLines[i]);
            } else {
                string[] split = fileLines[i].Split(',');
                paper[int.Parse(split[0]), int.Parse(split[1])] = 1;
            }
        }

        for (int i = 0;i < folds.Count;i++) {
            string[] split = folds[i].Split('=');
            int pos = int.Parse(split[1]);

            if (split[0].EndsWith('x')) {
                xlimit = pos;
                for (int x = 0; x < xlimit; x++) {
                    for (int y = 0; y < ylimit; y++) {
                        paper[x, y] += paper[2 * xlimit - x, y];
                    }
                }
            } else if (split[0].EndsWith('y')) {
                ylimit = pos;
                for (int x = 0; x < xlimit; x++) {
                    for (int y = 0; y < ylimit; y++) {
                        paper[x, y] += paper[x, 2 * ylimit - y];
                    }
                }
            } else {
                throw new Exception("Unexpected Fold Operation");
            }

            // Uncomment for p1
            //int p1 = 0;
            //for (int x = 0; x < xlimit; x++) {
            //    for (int y = 0; y < ylimit; y++) {
            //        if (paper[x, y] > 0) p1++;
            //    }
            //}
            //Console.WriteLine($"p1: {p1}");
            //return;
        }

        //p2
        for (int y = 0; y < ylimit; y++) {
            for (int x = 0; x < xlimit; x++) {
                Console.Write(paper[x, y] > 0 ? "X" : " ");
            }
            Console.WriteLine();
        }

        return;
    }
}