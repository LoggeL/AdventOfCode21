using System;

class Program {
    public static void Main() {

        string[] fileLines = System.IO.File.ReadAllLines(@"Input.txt");

        IDictionary<string, string> paths = new Dictionary<string, string>();

        // Construct ghetto node tree
        foreach (string line in fileLines) {
            string[] path = line.Split('-');
            if (!paths.ContainsKey(path[0])) paths.Add(path[0], path[1]);
            else paths[path[0]] += "," + path[1];
        }

        // Populate return paths
        string[] keys = paths.Keys.ToArray();
        foreach (string key in keys) {
            string[] splitKeys = paths[key].Split(',');
            for (int i = 0; i < splitKeys.Length; i++) {
                string value = splitKeys[i];
                if (!paths.ContainsKey(value)) paths.Add(value, key);
                else if (paths[value].Contains(key)) continue;
                else paths[value] += "," + key;
            }
        }

        List<string> pastPaths = new List<string> { };
        string[] start = paths["start"].Split(',');
        for (int i = 0; i < start.Length; i++) {
            walkPath("start," + start[i]);
        }

        Console.WriteLine($"Paths {pastPaths.Count} paths");

        void walkPath(string currentPath) {
            string[] steps = currentPath.Split(',');
            string[] possibleSteps = paths[steps[steps.Length - 1]].Split(',');

            for (int i = 0; i < possibleSteps.Length; i++) {
                string pStep = possibleSteps[i];
                if (pStep == "end") {
                    if (!pastPaths.Contains(currentPath.Replace("-", ""))) {
                        pastPaths.Add(currentPath);
                        //Console.WriteLine($"End {currentPath},end");
                    }
                }
                else if (pStep == "start") continue; // We only visit start once
                else {
                    if (pStep == pStep.ToUpper()) {
                        walkPath(currentPath + ',' + pStep);
                    } else if (pStep == pStep.ToLower()) {
                        // We append a - to the beginning of the string if we've visited a small cave twice
                        if (currentPath.StartsWith('-') && currentPath.Contains(pStep)) continue;
                        if (currentPath.Contains(pStep)) {
                            walkPath('-' + currentPath + ',' + pStep);
                        } else {
                            walkPath(currentPath + ',' + pStep);
                        }
                    }
                    // Dead end
                }
                
            }
            return;
        }
    }
}