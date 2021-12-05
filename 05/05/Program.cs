using System;

class Program {
    static void Main(string[] args) {

        string[] linesFile = System.IO.File.ReadAllLines(@"Input.txt");

        // Init Matrix
        int[,] board = new int[1000, 1000];
        //        for (int i = 0; i < board.GetLength(0); i++) {
        //            for (int j = 0; j < board.GetLength(1); j++) {
        //board[i, j] = 0;
        //}
        //}

        for (int i = 0; i < linesFile.Length; i++) {
            string[] split = linesFile[i].Split(" -> ");
            string[] from = split[0].Split(",");
            string[] to = split[1].Split(",");

            // part 1 filter 
            // if (from[0] != to[0] && from[1] != to[1]) continue;


            int fromx = Math.Min(int.Parse(from[0]), int.Parse(to[0]));
            int fromy = Math.Min(int.Parse(from[1]), int.Parse(to[1]));
            int tox = Math.Max(int.Parse(from[0]), int.Parse(to[0]));
            int toy = Math.Max(int.Parse(from[1]), int.Parse(to[1]));

            // part 2 filter
            if (fromx == tox) {
                // vertical
                for (int y = fromy; y <= toy; y++) {
                    board[fromx, y] += 1;
                }
            }
            else if (fromy == toy) {
                // horizontal
                for (int x = fromx; x <= tox; x++) {
                    board[x, fromy] += 1;
                }
            }
            else if (tox - fromx == toy - fromy) {
                // diagonal
                int m = (int.Parse(to[1]) - int.Parse(from[1])) / (int.Parse(to[0]) - int.Parse(from[0])); 
                if (m == 1) {
                    for (int x = fromx; x <= tox; x++) {
                        board[x, fromy + (x - fromx)] += 1;
                    }
                } else if (m == -1) {
                    for (int x = fromx; x <= tox; x++) {
                        board[x, toy - (x - fromx)] += 1;
                    }
                }

            }
        }

        // Evaluate board
        int count = 0;
        for (int i = 0;i < board.GetLength(0); i++) {
            for (int j = 0; j < board.GetLength(1); j++) {
                if (board[i, j] > 1) count++;
            }
        }

        Console.WriteLine($"Solution: {count}");
    }
}