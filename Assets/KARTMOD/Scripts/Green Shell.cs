using UnityEngine;

public class GreenShell : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 5f;

    private Rigidbody rb;
    private GameObject owner;
    private Collider shellCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        shellCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        Destroy(gameObject, lifetime);
    }

    public void Launch(Vector3 direction, GameObject shooter)
    {
        owner = shooter;

        // Aplica velocidade
        rb.linearVelocity = direction.normalized * speed;

        // Ignora colisão com quem lançou
        Collider ownerCollider = owner.GetComponent<Collider>();
        if (ownerCollider != null && shellCollider != null)
        {
            Physics.IgnoreCollision(shellCollider, ownerCollider, true);
            Invoke(nameof(ReenableCollision), 1f);
        }
    }

    private void ReenableCollision()
    {
        if (owner != null && shellCollider != null)
        {
            Collider ownerCollider = owner.GetComponent<Collider>();
            if (ownerCollider != null)
            {
                Physics.IgnoreCollision(shellCollider, ownerCollider, false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == owner) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Green shell hit a player!");
            // Spin ou outro efeito
        }

        Vector3 reflect = Vector3.Reflect(rb.linearVelocity, collision.contacts[0].normal);
        rb.linearVelocity = reflect.normalized * speed;
    }
}
