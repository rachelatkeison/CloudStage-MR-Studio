using UnityEngine;

public class StageIntensityVisuals : MonoBehaviour
{
    public MusicStateSimulator musicState;

    public Light stageSpotL;
    public Light stageSpotR;
    public Light stageGlowL;
    public Light stageGlowR;

    public Renderer mainBackdrop;
    public Renderer accentLeft;
    public Renderer accentRight;

    public float minEmission = 2f;
    public float maxEmission = 25f;

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
        float emissionStrength = Mathf.Lerp(minEmission, maxEmission, intensity);

        if (mainMat != null)
            mainMat.SetColor("_EmissionColor", mainBaseEmission * emissionStrength);

        if (leftMat != null)
            leftMat.SetColor("_EmissionColor", leftBaseEmission * emissionStrength);

        if (rightMat != null)
            rightMat.SetColor("_EmissionColor", rightBaseEmission * emissionStrength);

        if (stageSpotL != null)
            stageSpotL.intensity = Mathf.Lerp(4f, 10f, intensity);

        if (stageSpotR != null)
            stageSpotR.intensity = Mathf.Lerp(4f, 10f, intensity);

        if (stageGlowL != null)
            stageGlowL.intensity = Mathf.Lerp(2f, 8f, intensity);

        if (stageGlowR != null)
            stageGlowR.intensity = Mathf.Lerp(2f, 8f, intensity);
    }
}