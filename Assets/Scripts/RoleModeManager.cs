using UnityEngine;

public class RoleModeManager : MonoBehaviour
{
    public enum RoleMode
    {
        Listener,
        Performer
    }

    public static RoleModeManager instance;
    public static RoleMode currentMode = RoleMode.Listener;

    [Header("Scene References")]
    public Transform player;
    public Transform listenerSpawn;
    public Transform performerSpawn;

    [Header("World Objects")]
    public GameObject stageKeyboardRoot;

    [Header("UI")]
    public CanvasGroup listenerControlsCanvas;
    public CanvasGroup performerModeCanvas;
    public GameObject titleMenuPanel;

    [Header("Options")]
    public bool keyboardVisibleInListenerMode = true;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ApplyState();
    }

    public void SetListenerMode()
    {
        currentMode = RoleMode.Listener;
        PianoFocusState.pianoFocused = false;
        ApplyState();
    }

    public void SetPerformerMode()
    {
        currentMode = RoleMode.Performer;
        PianoFocusState.pianoFocused = false;
        ApplyState();
    }

    public void ToggleKeyboardVisibilityPreference()
    {
        keyboardVisibleInListenerMode = !keyboardVisibleInListenerMode;
        ApplyState();
    }

    public void EnterExperience()
    {
        TitleMenuState.menuOpen = false;
        ApplyState();
    }

    public void ApplyState()
    {
        bool menuOpen = TitleMenuState.menuOpen;

        if (titleMenuPanel != null)
            titleMenuPanel.SetActive(menuOpen);

        bool showKeyboard = false;

        if (!menuOpen)
        {
            if (currentMode == RoleMode.Performer)
                showKeyboard = true;
            else if (currentMode == RoleMode.Listener)
                showKeyboard = keyboardVisibleInListenerMode;
        }

        if (stageKeyboardRoot != null)
            stageKeyboardRoot.SetActive(showKeyboard);

        SetCanvasVisible(listenerControlsCanvas, !menuOpen && currentMode == RoleMode.Listener);
        SetCanvasVisible(performerModeCanvas, !menuOpen && currentMode == RoleMode.Performer);

        if (!menuOpen)
            TeleportToCurrentRole();
    }

    public void TeleportToCurrentRole()
    {
        if (player == null)
        {
            Debug.LogError("RoleModeManager: Player is not assigned.");
            return;
        }

        Transform target = currentMode == RoleMode.Listener ? listenerSpawn : performerSpawn;

        if (target == null)
        {
            Debug.LogError("RoleModeManager: Spawn not assigned for " + currentMode);
            return;
        }

        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null)
            cc.enabled = false;

        player.position = target.position;
        player.rotation = target.rotation;

        if (cc != null)
            cc.enabled = true;

        Debug.Log("Teleported to " + currentMode + " at " + player.position);
    }

    void SetCanvasVisible(CanvasGroup canvas, bool visible)
    {
        if (canvas == null)
            return;

        canvas.alpha = visible ? 1f : 0f;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }
}