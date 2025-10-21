using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(OrbitPreview))]
public class CelestialBody : MonoBehaviour
{
    [Header("Physical Properties")] [SerializeField]
    private float radius = 1f;

    [SerializeField] private float mass = 1f;

    [Header("Orbital Properties")]
    // this is optional, if you want to add a moon to planet, select the planet as a parent body
    // so the moon can derive its velocity from the planet's velocity
    [SerializeField]
    private CelestialBody parentBody; // optional for moons

    [SerializeField] private Vector3 initialVelocity;

    [Header("Runtime Data")] [SerializeField, HideInInspector]
    private Vector3 currentVelocity;

    [HideInInspector] public Rigidbody rigidbody;
    private OrbitPreview orbitPreview;

    public const float G = 100f;
    public float Mass => mass;
    public Vector3 CurrentVelocity => currentVelocity;
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (parentBody != null)
            currentVelocity = parentBody.initialVelocity + initialVelocity;
        else
            currentVelocity = initialVelocity;
    }
#endif

    private void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody>();
        orbitPreview = GetComponent<OrbitPreview>();
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;

        if (parentBody != null)
            currentVelocity = parentBody.initialVelocity + initialVelocity;
        else
            currentVelocity = initialVelocity;

        transform.localScale = Vector3.one * radius * 2f;
    }

    public void TickVelocity(CelestialBody[] bodies, float deltaTime)
    {
        foreach (var body in bodies)
        {
            if (body == this) continue;

            Vector3 dir = body.rigidbody.position - rigidbody.position;
            float dist = dir.magnitude;
            if (dist < 0.1f) continue;

            Vector3 accel = (G * body.mass / (dist * dist)) * dir.normalized;
            currentVelocity += accel * deltaTime;
        }
    }

    public void TickPosition(float deltaTime)
    {
        rigidbody.position += currentVelocity * deltaTime;
    }

    public void UpdateOrbitPreview(float duration, float step)
    {
        var controller = FindObjectOfType<PhysicsSimulationController>();
        if (controller == null) return;

        Vector3[] path = controller.PredictOrbit(this, duration, step);
        orbitPreview.DrawOrbit(path);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw predicted orbit when selected in Editor
        var controller = FindObjectOfType<PhysicsSimulationController>();
        if (controller == null) return;

        if (!controller.DrawAllOrbits)
        {
            UpdateOrbitPreview(controller.previewDuration, controller.previewStep);
        }
    }

    private void OnDrawGizmos()
    {
        // Optionally draw all if enabled
        var controller = FindObjectOfType<PhysicsSimulationController>();
        if (controller != null && controller.DrawAllOrbits)
        {
            UpdateOrbitPreview(controller.previewDuration, controller.previewStep);
        }
    }
}