using System;

public class Submarine
{
    public int Forward { get; set; }
    public int Depth { get; set; }
    public int Aim { get; set; }
    public Submarine(int forward, int depth, int aim) {
        Depth = depth;
        Forward = forward;
        Aim = aim;
    }
}

class Program { 
    static void Main() {

        Submarine Sub = new Submarine(0, 0, 0);

        string[] lines = System.IO.File.ReadAllLines(@"Input.txt");

        for (int i = 0; i < lines.Length; i++) {
            string[] elements = lines[i].Split(" ");
            int value = int.Parse(elements[1]);
            if (elements[0] == "up") {
                // Sub.Depth -= value;
                Sub.Aim -= value;
            } else if (elements[0] == "down") {
                // Sub.Depth += value;
                Sub.Aim += value;
            } else if (elements[0] == "forward") {
                Sub.Forward += value;
                Sub.Depth += value * Sub.Aim;
            } else {
                throw new Exception("Unkown Command Exception");
            }
        }

        Console.WriteLine($"Current Depth: {Sub.Depth}!");
        Console.WriteLine($"Current Forward: {Sub.Forward}!");
        Console.WriteLine($"Solution: {Sub.Forward * Sub.Depth}");
    }
}