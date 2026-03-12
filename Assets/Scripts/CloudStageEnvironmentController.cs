using UnityEngine;

public class CloudStageEnvironmentController : MonoBehaviour
{
    public MusicAnalyzer musicState;

    public Light stageSpotL;
    public Light stageSpotR;
    public Light stageGlowL;
    public Light stageGlowR;

    public Renderer mainBackdrop;
    public Renderer accentLeft;
    public Renderer accentRight;

    private Material mainMat;
    private Material leftMat;
    private Material rightMat;

    private Color mainBaseEmission;
    private Color leftBaseEmission;
    private Color rightBaseEmission;

    void Start()
    {
        if (mainBackdrop != null)
        {
            mainMat = mainBackdrop.material;
            mainMat.EnableKeyword("_EMISSION");
            mainBaseEmission = mainMat.GetColor("_EmissionColor");
        }

        if (accentLeft != null)
        {
            leftMat = accentLeft.material;
            leftMat.EnableKeyword("_EMISSION");
            leftBaseEmission = leftMat.GetColor("_EmissionColor");
        }

        if (accentRight != null)
        {
            rightMat = accentRight.material;
            rightMat.EnableKeyword("_EMISSION");
            rightBaseEmission = rightMat.GetColor("_EmissionColor");
        }
    }

    void Update()
    {
        if (musicState == null)
            return;

        float intensity = musicState.intensity;

        float zoneMultiplier = 1f;
        float accentMultiplier = 1f;

        if (CloudStageZoneTracker.currentMode == "Ambient")
        {
            zoneMultiplier = 0.75f;
            accentMultiplier = 0.8f;
        }
        else if (CloudStageZoneTracker.currentMode == "Listener")
        {
            zoneMultiplier = 1.0f;
            accentMultiplier = 1.0f;
        }
        else if (CloudStageZoneTracker.currentMode == "Performer")
        {
            zoneMultiplier = 1.15f;
            accentMultiplier = 1.05f;
        }

        float finalIntensity = Mathf.Clamp01(intensity * zoneMultiplier);

        if (stageSpotL != null)
            stageSpotL.intensity = Mathf.Lerp(3f, 8f, finalIntensity);

        if (stageSpotR != null)
            stageSpotR.intensity = Mathf.Lerp(3f, 8f, finalIntensity);

        if (stageGlowL != null)
            stageGlowL.intensity = Mathf.Lerp(1.5f, 5f, finalIntensity);

        if (stageGlowR != null)
            stageGlowR.intensity = Mathf.Lerp(1.5f, 5f, finalIntensity);

        float mainEmissionStrength = Mathf.Lerp(0.8f, 8f, finalIntensity);
        float accentEmissionStrength = Mathf.Lerp(0.5f, 4.5f, finalIntensity * accentMultiplier);

        if (mainMat != null)
            mainMat.SetColor("_EmissionColor", mainBaseEmission * mainEmissionStrength);

        if (leftMat != null)
            leftMat.SetColor("_EmissionColor", leftBaseEmission * accentEmissionStrength);

        if (rightMat != null)
            rightMat.SetColor("_EmissionColor", rightBaseEmission * accentEmissionStrength);
    }
}