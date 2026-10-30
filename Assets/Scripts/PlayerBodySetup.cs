using UnityEngine;

/// <summary>Optional helper for configuring the VR player's physics body.</summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerBodySetup : MonoBehaviour
{
    [Min(0.1f)] public float mass = 1f;
    [Min(0f)] public float drag = 0.05f;

    private void Awake()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.mass = Mathf.Max(0.1f, mass);
        body.drag = Mathf.Max(0f, drag);
        body.constraints |= RigidbodyConstraints.FreezeRotation;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }
}
