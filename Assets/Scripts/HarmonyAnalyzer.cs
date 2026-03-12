using System.Collections.Generic;
using UnityEngine;

public class HarmonyAnalyzer : MonoBehaviour
{
    public NoteStateManager noteState;

    public static int detectedRoot = -1;
    public static bool detectedMinor = false;

    void Update()
    {
        if (noteState == null)
            return;

        List<int> activeNotes = noteState.GetActiveNotes();

        if (activeNotes.Count < 3)
        {
            detectedRoot = -1;
            return;
        }

        List<int> pitchClasses = new List<int>();

        foreach (int note in activeNotes)
        {
            int pc = note % 12;

            if (!pitchClasses.Contains(pc))
                pitchClasses.Add(pc);
        }

        DetectChord(pitchClasses);
    }

    void DetectChord(List<int> notes)
    {
        for (int root = 0; root < 12; root++)
        {
            int majorThird = (root + 4) % 12;
            int minorThird = (root + 3) % 12;
            int fifth = (root + 7) % 12;

            if (notes.Contains(root) && notes.Contains(majorThird) && notes.Contains(fifth))
            {
                detectedRoot = root;
                detectedMinor = false;
                return;
            }

            if (notes.Contains(root) && notes.Contains(minorThird) && notes.Contains(fifth))
            {
                detectedRoot = root;
                detectedMinor = true;
                return;
            }
        }

        detectedRoot = -1;
    }
}