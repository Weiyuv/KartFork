using UnityEngine;

public class BoomerangProjectile : MonoBehaviour
{
    public float speed = 15f;
    public int maxBounces = 3;
    private int bounceCount = 0;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody não encontrado no Boomerang.");
            return;
        }

        rb.linearVelocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        bounceCount++;

        if (bounceCount >= maxBounces)
        {
            Destroy(gameObject);
            return;
        }

        // Ricochetear: refletir a direção
        Vector3 reflectDir = Vector3.Reflect(rb.linearVelocity.normalized, collision.contacts[0].normal);
        rb.linearVelocity = reflectDir * speed;
    }
}
