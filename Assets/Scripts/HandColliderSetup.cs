using UnityEngine;

/// <summary>Attach to each tracked hand object to configure its physical sphere collider.</summary>
[RequireComponent(typeof(SphereCollider))]
public class HandColliderSetup : MonoBehaviour
{
    [Min(0.01f)] public float radius = 0.08f;

    private void Awake() => Apply();

    private void OnValidate()
    {
        radius = Mathf.Max(0.01f, radius);
        Apply();
    }

    private void Apply()
    {
        SphereCollider handCollider = GetComponent<SphereCollider>();
        handCollider.radius = radius;
        handCollider.isTrigger = false;
    }
}
