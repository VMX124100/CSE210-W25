using System;
using System.IO;

public class Journal
{
    private string DateTime;
    private string Prompt;
    private string UserEntry;
    public string CompleteEntry;

    private List<string> _savedEntries = new List<string>();

    public void AddEntry(string prompt, string userEntry)
    {
        DateTime = System.DateTime.Now.ToString();
        Prompt = prompt;
        UserEntry = userEntry;
        CompleteEntry = DateTime + "|" + Prompt + "|" + UserEntry;
        _savedEntries.Add(CompleteEntry);
    }

    public void DisplayEntries()
    {

        foreach (string entry in _savedEntries)
        {
            string[] entryParts = entry.Split('|');
            Console.Write($"\nDate: {entryParts[0]}");
            Console.WriteLine($" Prompt: {entryParts[1]}");
            Console.WriteLine($" Entry: {entryParts[2]}");
        }
    }



    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (string entry in _savedEntries)
            {
                outputFile.WriteLine(entry);
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _savedEntries = new List<string>();

            foreach (string line in lines)
            {  
                _savedEntries.Add(line);
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}

