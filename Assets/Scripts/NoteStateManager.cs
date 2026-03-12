using System.Collections.Generic;
using UnityEngine;

public class NoteStateManager : MonoBehaviour
{
    public List<int> activeNotes = new List<int>();
    public List<float> activeVelocities = new List<float>();

    public void NoteOn(int noteNumber, float velocity)
    {
        if (!activeNotes.Contains(noteNumber))
        {
            activeNotes.Add(noteNumber);
            activeVelocities.Add(velocity);
        }
    }

    public void NoteOff(int noteNumber)
    {
        int index = activeNotes.IndexOf(noteNumber);

        if (index >= 0)
        {
            activeNotes.RemoveAt(index);
            activeVelocities.RemoveAt(index);
        }
    }

    public int GetActiveNoteCount()
    {
        return activeNotes.Count;
    }

    public float GetAverageVelocity()
    {
        if (activeVelocities.Count == 0)
            return 0f;

        float total = 0f;

        for (int i = 0; i < activeVelocities.Count; i++)
        {
            total += activeVelocities[i];
        }

        return total / activeVelocities.Count;
    }

    public List<int> GetActiveNotes()
    {
        return new List<int>(activeNotes);
    }
}