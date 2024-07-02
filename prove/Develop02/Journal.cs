using System.ComponentModel.DataAnnotations;
using System.IO.Enumeration;

public class Journal {
    public List<Entry> _entries;
    public int EntryCount;

    public Journal(){
        _entries = new List<Entry>();
        EntryCount = 0;
    }
    public void AddEntry(Entry newEntry){
        _entries.Add(newEntry);
        EntryCount++;
    }

    public void DisplayAll() {
        foreach (var entry in _entries){
            entry.Display();
        }
    }

    public void SaveToFile (string filename) {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename)) // Added initialization of StreamWriter
        {
            foreach (var entry in _entries){
                file.WriteLine($"{entry._date}, {entry._promptText}, {entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string filename) {
        string[] lines = System.IO.File.ReadAllLines(filename);
        _entries.Clear();

        foreach (var line in lines)
        {
            string[] parts = line.Split(',');
            Entry entry = new Entry
            {
                _date = parts[0],
                _promptText = parts[1],
                _entryText = parts[2]
            };
            _entries.Add(entry);
        }
    }
}