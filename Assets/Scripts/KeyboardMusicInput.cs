using UnityEngine;

public class KeyboardMusicInput : MonoBehaviour
{
    public NoteStateManager noteState;

    void Update()
    {
        HandleKey(KeyCode.Alpha1, 60); // C
        HandleKey(KeyCode.Alpha2, 64); // E
        HandleKey(KeyCode.Alpha3, 67); // G
        HandleKey(KeyCode.Alpha4, 63); // Eb
    }

    void HandleKey(KeyCode key, int midiNote)
    {
        if (Input.GetKeyDown(key))
        {
            noteState.NoteOn(midiNote, 1.0f);
        }

        if (Input.GetKeyUp(key))
        {
            noteState.NoteOff(midiNote);
        }
    }
}