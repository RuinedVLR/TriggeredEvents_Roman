using UnityEngine;

public class TableThrow : MonoBehaviour
{
    public Rigidbody[] tableRigidbody;
    public float throwForce = 8f;
    public float upForce = 1.5f;
    public bool throwAwayFromPlayer = false;
    public Vector3 fixedDirection = Vector3.right;
    public ForceMode forceMode = ForceMode.Impulse;

    void Reset()
    {
        if (tableRigidbody == null || tableRigidbody.Length == 0)
        {
            var rb = GetComponent<Rigidbody>();
            tableRigidbody = rb != null ? new Rigidbody[] { rb } : new Rigidbody[0];
        }
    }

    public void Start()
    {
        if (tableRigidbody == null)
            tableRigidbody = new Rigidbody[0];

        foreach (var rb in tableRigidbody)
        {
            if (rb != null)
                rb.isKinematic = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || tableRigidbody == null || tableRigidbody.Length == 0)
            return;

        foreach (var rb in tableRigidbody)
        {
            if (rb == null) continue;

            rb.isKinematic = false;

            Vector3 dir = throwAwayFromPlayer
                ? (rb.transform.position - other.transform.position).normalized
                : fixedDirection.normalized;

            Vector3 finalDir = (dir + Vector3.up * upForce).normalized;

            float forceVariation = Random.Range(0.9f, 1.1f);
            rb.AddForce(finalDir * (throwForce * forceVariation), forceMode);

            rb.AddTorque(Random.insideUnitSphere * throwForce * 0.2f * forceVariation, forceMode);
        }
    }
}
