using System.Collections.Generic;
using UnityEngine;

public static class PianoKeyDisplayState
{
    private static List<string> activeKeyNames = new List<string>();

    public static void NoteOn(string keyName)
    {
        if (!activeKeyNames.Contains(keyName))
            activeKeyNames.Add(keyName);
    }

    public static void NoteOff(string keyName)
    {
        if (activeKeyNames.Contains(keyName))
            activeKeyNames.Remove(keyName);
    }

    public static string GetDisplayText()
    {
        if (activeKeyNames.Count == 0)
            return "---";

        return string.Join(", ", activeKeyNames);
    }

    public static void Clear()
    {
        activeKeyNames.Clear();
    }
}