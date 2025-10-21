using System;
using UnityEngine;

public class PhysicsSimulationController : MonoBehaviour
{
    public static PhysicsSimulationController Instance { get; private set; }

    [SerializeField] private float timeScale = 1f;
    [SerializeField] private CelestialBody[] celestialBodies;
    
    [Header("Preview Settings")]
    public bool DrawAllOrbits = false;
    public float previewDuration = 20f;
    public float previewStep = 0.1f;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        celestialBodies = FindObjectsOfType<CelestialBody>();
    }
    
    private void FixedUpdate()
    {
        float deltaTime = Time.fixedDeltaTime * timeScale;
    
        foreach (var celestialBody in celestialBodies)
            celestialBody.TickVelocity(celestialBodies, deltaTime);

        foreach (var celestialBody in celestialBodies)
            celestialBody.TickPosition(deltaTime);

        // Remove this block OR wrap it in a condition
        // if (Application.isEditor && !Application.isPlaying)
        // {
        //     foreach (var celestialBody in celestialBodies)
        //         celestialBody.UpdateOrbitPreview(previewDuration, previewStep);
        // }
        if (DrawAllOrbits)
        {
            foreach (var celestialBody in celestialBodies)
                celestialBody.UpdateOrbitPreview(previewDuration, previewStep);
        }

    }
    
    public Vector3[] PredictOrbit(CelestialBody target, float duration, float step)
    {
        if (celestialBodies == null || celestialBodies.Length == 0)
            celestialBodies = FindObjectsOfType<CelestialBody>();

        int bodyCount = celestialBodies.Length;
        Vector3[] positions = new Vector3[bodyCount];
        Vector3[] velocities = new Vector3[bodyCount];
        float[] masses = new float[bodyCount];

        for (int i = 0; i < bodyCount; i++)
        {
            positions[i] = celestialBodies[i].rigidbody.position;
            velocities[i] = celestialBodies[i].CurrentVelocity;
            masses[i] = celestialBodies[i].Mass;
        }

        int steps = Mathf.CeilToInt(duration / step);
        Vector3[] path = new Vector3[steps];
        int targetIndex = Array.IndexOf(celestialBodies, target);

        for (int s = 0; s < steps; s++)
        {
            Vector3[] accelerations = new Vector3[bodyCount];

            for (int i = 0; i < bodyCount; i++)
            {
                for (int j = 0; j < bodyCount; j++)
                {
                    if (i == j) continue;
                    Vector3 dir = positions[j] - positions[i];
                    float distSqr = dir.sqrMagnitude;
                    if (distSqr < 0.01f) continue;

                    accelerations[i] += (CelestialBody.G * masses[j] / distSqr) * dir.normalized;
                }
            }

            for (int i = 0; i < bodyCount; i++)
            {
                velocities[i] += accelerations[i] * step;
                positions[i] += velocities[i] * step;
            }

            path[s] = positions[targetIndex];
        }

        return path;
    }

}