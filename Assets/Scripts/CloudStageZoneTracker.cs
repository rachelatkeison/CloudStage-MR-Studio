using UnityEngine;

public class CloudStageZoneTracker : MonoBehaviour
{
    public static string currentZone = "None";
    public static string currentMode = "Listener";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PerformerZone"))
        {
            currentZone = "Stage";
            currentMode = "Performer";
        }
        else if (other.CompareTag("AudienceCenterZone"))
        {
            currentZone = "Audience";
            currentMode = "Listener";
        }
        else if (other.CompareTag("RearAmbientZone"))
        {
            currentZone = "Rear Hall";
            currentMode = "Ambient";
        }
    }
}