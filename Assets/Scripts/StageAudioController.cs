using UnityEngine;

public class StageAudioController : MonoBehaviour
{
    public Transform player;
    public AudioSource stageAudio;

    public float minDistance = 6f;
    public float maxDistance = 40f;

    public float minVolume = 0.2f;
    public float maxVolume = 1f;

    void Update()
    {
        if (player == null || stageAudio == null)
            return;

        float distance = Vector3.Distance(player.position, transform.position);

        float t = Mathf.InverseLerp(maxDistance, minDistance, distance);

        float volume = Mathf.Lerp(minVolume, maxVolume, t);

        stageAudio.volume = volume;
    }
}