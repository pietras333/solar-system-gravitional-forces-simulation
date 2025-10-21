using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(LineRenderer))]
public class OrbitPreview : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [Header("Color Settings")]
    [SerializeField] private float alpha = 0.9f;

    private void OnEnable()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.widthMultiplier = .5f;
        lineRenderer.useWorldSpace = true;
        lineRenderer.loop = false;

        lineRenderer.colorGradient = GenerateSingleColorGradient();
        lineRenderer.enabled = false;
    }

    private Gradient GenerateSingleColorGradient()
    {
        Color vibrantColor = new Color(Random.value, Random.value, Random.value);
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[]
        {
            new GradientColorKey(vibrantColor, 0f),
            new GradientColorKey(vibrantColor, 1f)
        };
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[]
        {
            new GradientAlphaKey(alpha, 0f),
            new GradientAlphaKey(alpha, 1f)
        };
        gradient.SetKeys(colorKeys, alphaKeys);
        return gradient;
    }

    public void DrawOrbit(Vector3[] path)
    {
        if (path == null || path.Length == 0)
        {
            lineRenderer.enabled = false;
            return;
        }

        lineRenderer.positionCount = path.Length;
        lineRenderer.SetPositions(path);
        lineRenderer.enabled = true;
    }

    public void Clear()
    {
        if (lineRenderer == null) return;
        lineRenderer.positionCount = 0;
        lineRenderer.enabled = false;
    }
}