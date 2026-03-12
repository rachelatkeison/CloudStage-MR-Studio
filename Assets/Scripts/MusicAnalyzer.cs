using System.Collections.Generic;
using UnityEngine;

public class MusicAnalyzer : MonoBehaviour
{
    public NoteStateManager noteState;

    public int activeNotes = 0;
    public float intensity = 0f;
    public string currentChord = "None";
    public string keyEstimate = "Unknown";

    void Update()
    {
        if (noteState == null)
            return;

        activeNotes = noteState.GetActiveNoteCount();

        float averageVelocity = noteState.GetAverageVelocity();

        intensity = Mathf.Clamp01((activeNotes / 4f) * 0.7f + averageVelocity * 0.3f);

        DetectChord(noteState.activeNotes);
        EstimateKey();
    }

    void DetectChord(List<int> notes)
    {
        bool hasC = ContainsPitchClass(notes, 0);
        bool hasEb = ContainsPitchClass(notes, 3);
        bool hasE = ContainsPitchClass(notes, 4);
        bool hasG = ContainsPitchClass(notes, 7);

        if (hasC && hasE && hasG && !hasEb)
        {
            currentChord = "C Major";
        }
        else if (hasC && hasEb && hasG && !hasE)
        {
            currentChord = "C Minor";
        }
        else if (notes.Count == 0)
        {
            currentChord = "None";
        }
        else
        {
            currentChord = "Unknown";
        }
    }

    void EstimateKey()
    {
        if (currentChord == "C Major")
        {
            keyEstimate = "C Major";
        }
        else if (currentChord == "C Minor")
        {
            keyEstimate = "C Minor";
        }
        else if (currentChord == "None")
        {
            keyEstimate = "Unknown";
        }
    }

    bool ContainsPitchClass(List<int> notes, int pitchClass)
    {
        for (int i = 0; i < notes.Count; i++)
        {
            if (notes[i] % 12 == pitchClass)
                return true;
        }

        return false;
    }
}