using UnityEngine;

/// <summary>
/// Simple hand-pushing locomotion starter for a tracked VR rig.
/// Attach to the player root with a Rigidbody and assign both hand transforms.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerHandLocomotion : MonoBehaviour
{
    [Header("Tracked hands")]
    public Transform leftHand;
    public Transform rightHand;

    [Header("Movement")]
    [Min(0.01f)] public float handRadius = 0.08f;
    [Min(0f)] public float movementMultiplier = 1.15f;
    [Min(0f)] public float maxVelocity = 8f;
    [Range(0.9f, 1f)] public float velocityDamping = 0.995f;
    public LayerMask locomotionLayers = ~0;

    private Rigidbody body;
    private Vector3 previousLeft;
    private Vector3 previousRight;
    private bool initialized;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        body.useGravity = true;
        body.constraints |= RigidbodyConstraints.FreezeRotation;
        body.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void OnEnable() => initialized = false;

    private void FixedUpdate()
    {
        if (leftHand == null || rightHand == null) return;

        if (!initialized)
        {
            previousLeft = leftHand.position;
            previousRight = rightHand.position;
            initialized = true;
            return;
        }

        Vector3 leftPush = CalculatePush(leftHand.position, ref previousLeft);
        Vector3 rightPush = CalculatePush(rightHand.position, ref previousRight);
        Vector3 push = (leftPush + rightPush) * movementMultiplier;

        if (push.sqrMagnitude > 0f)
            body.velocity = Vector3.ClampMagnitude(
                body.velocity + push / Time.fixedDeltaTime, maxVelocity);

        body.velocity *= velocityDamping;
    }

    private Vector3 CalculatePush(Vector3 current, ref Vector3 previous)
    {
        Vector3 movement = current - previous;
        previous = current;

        if (movement.sqrMagnitude < 0.000001f) return Vector3.zero;

        bool touchedSurface = Physics.SphereCast(
            current, handRadius, -movement.normalized,
            out RaycastHit hit, movement.magnitude,
            locomotionLayers, QueryTriggerInteraction.Ignore);

        if (!touchedSurface) return Vector3.zero;

        // Push the body opposite the hand's movement along the contacted surface.
        return -Vector3.ProjectOnPlane(movement, hit.normal);
    }
}
