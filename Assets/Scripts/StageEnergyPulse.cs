using UnityEngine;

public class StageEnergyPulse : MonoBehaviour
{
    public MusicAnalyzer musicState;

    public Renderer mainBackdrop;
    public Renderer accentLeft;
    public Renderer accentRight;

    public float pulseSpeed = 2.0f;
    public float pulseAmount = 0.15f;

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

        if (intensity <= 0.01f)
            return;

        float pulse = 1f + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount * intensity;

        if (mainMat != null)
            mainMat.SetColor("_EmissionColor", mainBaseEmission * pulse);

        if (leftMat != null)
            leftMat.SetColor("_EmissionColor", leftBaseEmission * pulse * 0.8f);

        if (rightMat != null)
            rightMat.SetColor("_EmissionColor", rightBaseEmission * pulse * 0.8f);
    }
}