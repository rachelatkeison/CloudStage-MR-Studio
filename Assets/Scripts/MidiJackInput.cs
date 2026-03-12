using UnityEngine;
using MidiJack;

public class MidiJackInput : MonoBehaviour
{
    public NoteStateManager noteState;

    private bool[] noteHeld = new bool[128];

    void Update()
    {
        for (int note = 0; note < 128; note++)
        {
            float velocity = MidiMaster.GetKey(note);

            bool isPressed = velocity > 0f;

            if (isPressed && !noteHeld[note])
            {
                noteHeld[note] = true;
                noteState.NoteOn(note, velocity);
            }
            else if (!isPressed && noteHeld[note])
            {
                noteHeld[note] = false;
                noteState.NoteOff(note);
            }
        }
    }
}