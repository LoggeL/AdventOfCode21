using System;

class Program {
    static void Main() {
        string[] linesFile = System.IO.File.ReadAllLines(@"Input.txt");

        // Get DrawOrder
        string[] drawOrder = linesFile[0].Split(',');

        // Parse Boards
        var boards = new List<List<string[]>>();
        for (int i = 0; i < (linesFile.Length - 1) / 6; i++) {
            var board = new List<string[]>();
            for (int j = 0; j < 5; j++) {
                board.Add(linesFile[i * 6 + j + 2].Split(' ', StringSplitOptions.RemoveEmptyEntries));
            }
            boards.Add(board);
        }

        // Init Marker Array
        int[,,] marker = new int[boards.Count, boards[0].Count, 5];

        // Mark Boards that won
        int[] wonBoards = new int[boards.Count];

        // Play the game
        for (int i = 0; i < drawOrder.Length;i++) {
            string drawnNumber = drawOrder[i];
            for (int j = 0; j < boards.Count;j++) {
                for (int k = 0; k < boards[i].Count; k++) {
                    int pos = Array.IndexOf(boards[j][k], drawnNumber);
                    if (pos != -1) {
                        marker[j, k, pos] = 1;
                    }
                }
            }

            // Check for game over
            if (i >= 5) {
                for (int j = 0;j < boards.Count;j++) {
                    if (wonBoards[j] == 1) continue; // Skip boards that already won
                    
                    for (int k = 0; k < boards[j].Count; k++) {

                        // Check horizontal & vertical
                        int sumH = 0, sumV = 0;
                        for (int l = 0; l < boards[j][k].Count(); l++) {
                            sumH += marker[j, k, l];
                            sumV += marker[j, l, k];
                        }

                        if (sumH == 5 || sumV == 5) {
                            // Game Over
                            Console.WriteLine($"Game Over for Board #{j}");
                            wonBoards[j] = 1;

                            if (wonBoards.Sum() == boards.Count) {
                                // Last board to win

                                // Calc number
                                int outputSum = 0;
                                for (int k2 = 0; k2 < boards[j].Count; k2++) {
                                    for (int l2 = 0; l2 < boards[j][k2].Count(); l2++) {
                                        if (marker[j, k2, l2] == 0) {
                                            outputSum += int.Parse(boards[j][k2][l2]);
                                        }
                                    }
                                }
                                Console.WriteLine($"Solution: {outputSum} * {int.Parse(drawnNumber)} = {outputSum * int.Parse(drawnNumber)}");
                                return;
                            } else {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}