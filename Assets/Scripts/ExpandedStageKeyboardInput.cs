using UnityEngine;

public class ExpandedStageKeyboardInput : MonoBehaviour
{
    [Header("Systems")]
    public NoteStateManager noteState;
    public StageSynthEngine stageSynth;
    public JuceUdpSender juce;

    [Header("White Keys")]
    public GameObject keyC;
    public GameObject keyD;
    public GameObject keyE;
    public GameObject keyF;
    public GameObject keyG;
    public GameObject keyA;
    public GameObject keyB;

    [Header("Black Keys")]
    public GameObject keyCSharp;
    public GameObject keyDSharp;
    public GameObject keyFSharp;
    public GameObject keyGSharp;
    public GameObject keyASharp;

    [Header("Visual Settings")]
    public float pressDepth = 0.08f;

    private Vector3 cStart, dStart, eStart, fStart, gStart, aStart, bStart;
    private Vector3 csStart, dsStart, fsStart, gsStart, asStart;

    void Start()
    {
        if (keyC != null) cStart = keyC.transform.localPosition;
        if (keyD != null) dStart = keyD.transform.localPosition;
        if (keyE != null) eStart = keyE.transform.localPosition;
        if (keyF != null) fStart = keyF.transform.localPosition;
        if (keyG != null) gStart = keyG.transform.localPosition;
        if (keyA != null) aStart = keyA.transform.localPosition;
        if (keyB != null) bStart = keyB.transform.localPosition;

        if (keyCSharp != null) csStart = keyCSharp.transform.localPosition;
        if (keyDSharp != null) dsStart = keyDSharp.transform.localPosition;
        if (keyFSharp != null) fsStart = keyFSharp.transform.localPosition;
        if (keyGSharp != null) gsStart = keyGSharp.transform.localPosition;
        if (keyASharp != null) asStart = keyASharp.transform.localPosition;
    }

    void Update()
    {
        if (TitleMenuState.menuOpen)
            return;

        if (RoleModeManager.currentMode != RoleModeManager.RoleMode.Performer)
            return;

        if (!PianoFocusState.pianoFocused)
            return;

        HandleKey(KeyCode.A, 60, "C",  keyC, cStart);
		HandleKey(KeyCode.S, 62, "D",  keyD, dStart);
		HandleKey(KeyCode.D, 64, "E",  keyE, eStart);
		HandleKey(KeyCode.F, 65, "F",  keyF, fStart);
		HandleKey(KeyCode.G, 67, "G",  keyG, gStart);
		HandleKey(KeyCode.H, 69, "A",  keyA, aStart);
		HandleKey(KeyCode.J, 71, "B",  keyB, bStart);

		HandleKey(KeyCode.W, 61, "C#", keyCSharp, csStart);
		HandleKey(KeyCode.E, 63, "Eb", keyDSharp, dsStart);
		HandleKey(KeyCode.T, 66, "F#", keyFSharp, fsStart);
		HandleKey(KeyCode.Y, 68, "Ab", keyGSharp, gsStart);
		HandleKey(KeyCode.U, 70, "Bb", keyASharp, asStart);
    }

    void HandleKey(KeyCode triggerKey, int midiNote, string noteName, GameObject keyObject, Vector3 startPos)
{
    if (Input.GetKeyDown(triggerKey))
    {
        if (noteState != null)
            noteState.NoteOn(midiNote, 1.0f);

        if (stageSynth != null)
            stageSynth.NoteOn(midiNote, 1.0f);

        if (juce != null)
            juce.SendNoteOn(midiNote, 1.0f);

        PianoKeyDisplayState.NoteOn(noteName);

        if (keyObject != null)
            keyObject.transform.localPosition = startPos + new Vector3(0f, -pressDepth, 0f);
    }

    if (Input.GetKeyUp(triggerKey))
    {
        if (noteState != null)
            noteState.NoteOff(midiNote);

        if (stageSynth != null)
            stageSynth.NoteOff(midiNote);

        if (juce != null)
            juce.SendNoteOff(midiNote);

        PianoKeyDisplayState.NoteOff(noteName);

        if (keyObject != null)
            keyObject.transform.localPosition = startPos;
    }
}
}