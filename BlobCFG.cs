using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BlobCFG
{
    public string FilePath { get; private set; }
    public Dictionary<string, object> Properties { get; private set; }

    private Stack<Change> undoStack;
    private Stack<Change> redoStack;
    private int lastSavedChangeCount;

    public BlobCFG(string filePath)
    {
        FilePath = filePath;
        Properties = new Dictionary<string, object>();
        undoStack = new Stack<Change>();
        redoStack = new Stack<Change>();
        lastSavedChangeCount = 0;
    }

    public void Load()
    {
        using (StreamReader reader = new StreamReader(FilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                //if (line.StartsWith("$") || line.StartsWith("@"))
                //{
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    object value = parts.Length > 1 ? parts[1].Trim() : "";

                    if (line.StartsWith("@"))
                    {
                        value = parts[1].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                    }

                    Properties[key] = value;
                //}
            }
        }
    }

    public void Save()
    {
        using (StreamWriter writer = new StreamWriter(FilePath))
        {
            foreach (var property in Properties)
            {
                if (property.Value is string)
                {
                    writer.WriteLine($"{property.Key} = {property.Value}");
                }
                else if (property.Value is string[])
                {
                    writer.WriteLine($"{property.Key} = {string.Join("; ", (string[])property.Value)}");
                }
            }
        }
        lastSavedChangeCount = undoStack.Count;
    }

    public object GetProperty(string key)
    {
        return Properties.ContainsKey(key) ? Properties[key] : null;
    }

    public void SetProperty(string key, object value)
    {
        if (Properties.ContainsKey(key))
        {
            undoStack.Push(new Change(key, Properties[key]));
        }
        else
        {
            undoStack.Push(new Change(key, null));
        }
        redoStack.Clear();
        Properties[key] = value;
    }

    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            Change change = undoStack.Pop();
            redoStack.Push(new Change(change.Key, Properties.ContainsKey(change.Key) ? Properties[change.Key] : null));
            if (change.Value == null)
            {
                Properties.Remove(change.Key);
            }
            else
            {
                Properties[change.Key] = change.Value;
            }
        }
    }

    public void Redo()
    {
        if (redoStack.Count > 0)
        {
            Change change = redoStack.Pop();
            undoStack.Push(new Change(change.Key, Properties.ContainsKey(change.Key) ? Properties[change.Key] : null));
            if (change.Value == null)
            {
                Properties.Remove(change.Key);
            }
            else
            {
                Properties[change.Key] = change.Value;
            }
        }
    }

    public bool IsDirty()
    {
        return undoStack.Count != lastSavedChangeCount;
    }

    private class Change
    {
        public string Key { get; set; }
        public object Value { get; set; }

        public Change(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}