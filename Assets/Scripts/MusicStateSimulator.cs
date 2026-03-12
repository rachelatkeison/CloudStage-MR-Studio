using UnityEngine;

public class MusicStateSimulator : MonoBehaviour
{
    public int activeNotes = 0;
    public float intensity = 0f;
    public string currentChord = "None";
    public string keyEstimate = "Unknown";

    void Update()
    {
        bool noteC = Input.GetKey(KeyCode.Alpha1);
        bool noteE = Input.GetKey(KeyCode.Alpha2);
        bool noteG = Input.GetKey(KeyCode.Alpha3);
        bool noteEb = Input.GetKey(KeyCode.Alpha4);

        activeNotes = 0;

        if (noteC) activeNotes++;
        if (noteE) activeNotes++;
        if (noteG) activeNotes++;
        if (noteEb) activeNotes++;

        intensity = activeNotes / 4f;

        DetectChord(noteC, noteE, noteG, noteEb);
        EstimateKey();
    }

    void DetectChord(bool noteC, bool noteE, bool noteG, bool noteEb)
    {
        if (noteC && noteE && noteG && !noteEb)
        {
            currentChord = "C Major";
        }
        else if (noteC && noteEb && noteG && !noteE)
        {
            currentChord = "C Minor";
        }
        else if (activeNotes == 0)
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
}