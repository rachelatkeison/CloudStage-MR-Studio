using UnityEngine;

public class FloatingSpeakerReactiveGlow : MonoBehaviour
{
    public MusicAnalyzer musicState;

    public Renderer topRing;
    public Renderer bottomRing;

    public float minEmission = 2f;
    public float maxEmission = 20f;

    public float topRingBoost = 1.0f;
    public float bottomRingBoost = 0.7f;

    private Material topMat;
    private Material bottomMat;

    private Color topBaseEmission;
    private Color bottomBaseEmission;

    void Start()
    {
        if (topRing != null)
        {
            topMat = topRing.material;
            topMat.EnableKeyword("_EMISSION");
            topBaseEmission = topMat.GetColor("_EmissionColor");
        }

        if (bottomRing != null)
        {
            bottomMat = bottomRing.material;
            bottomMat.EnableKeyword("_EMISSION");
            bottomBaseEmission = bottomMat.GetColor("_EmissionColor");
        }
    }

    void Update()
    {
        if (musicState == null)
            return;

        float intensity = musicState.intensity;
        float emissionStrength = Mathf.Lerp(minEmission, maxEmission, intensity);

        if (topMat != null)
            topMat.SetColor("_EmissionColor", topBaseEmission * emissionStrength * topRingBoost);

        if (bottomMat != null)
            bottomMat.SetColor("_EmissionColor", bottomBaseEmission * emissionStrength * bottomRingBoost);
    }
}