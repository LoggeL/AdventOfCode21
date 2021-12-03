class Program {
    static void Main() {

        string[] linesFile = System.IO.File.ReadAllLines(@"Input.txt");

        for (int type = 0; type < 2; type++) {

            var lines = new List<string>(linesFile);
            int[] counter = new int[lines[0].Length];

            for (int i = 0; i < lines[0].Length; i++) {
                counter[i] = 0;

                // Count Digits
                for (int j = 0; j < lines.Count; j++) {
                    char[] bits = lines[j].ToCharArray();
                    counter[i] += int.Parse(bits[i].ToString());
                }

                int c = counter[i] / lines.Count;
                var removeIndex = new List<int>();
                // Remove Lines
                for (int j = 0; j < lines.Count; j++) { 
                    char[] bits = lines[j].ToCharArray();
                    //if (counter[i] == lines.Count || counter[i] == 0) continue; // Skip 
                    if (counter[i] >= lines.Count * 0.5 && bits[i].ToString() == (type).ToString()) {
                        // If 1 is major and item ist 0 drop
                        // If 1 is major and item is 1 drop
                        removeIndex.Add(j);
                        //lines.RemoveAt(j);
                    }
                    else if (counter[i] < lines.Count * 0.5 && bits[i].ToString() == (1 - type).ToString()) {
                        // If 0 is major and item ist 1 drop
                        // If 0 is major and item is 0 drop
                        //lines.RemoveAt(j);
                        removeIndex.Add(j);
                        //j--;
                    }
                }

                for (int j = removeIndex.Count - 1; j > 0; j--) {
                    lines.RemoveAt(removeIndex[j]);
                }
            }

            Console.WriteLine($"content: {lines[0]} decimal: {Convert.ToInt32(lines[0], 2)} count: {lines.Count}");
        }

        //int gamma = Convert.ToInt32(oxy, 2);
        // int epsilon = Convert.ToInt32(co2, 2);
        //Console.WriteLine($"Solution: {gamma * epsilon}");
        // Console.WriteLine($"Solution: {'hi'}");
    }
}