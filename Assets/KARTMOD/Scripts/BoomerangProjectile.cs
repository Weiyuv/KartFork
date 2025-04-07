using UnityEngine;

public class BoomerangProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float returnDelay = 1.5f;
    private Vector3 startPosition;
    private bool returning = false;
    private Rigidbody rb;
    private GameObject owner;
    private Collider ownerCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;

        rb.linearVelocity = transform.forward * speed;

        // Garante que o projétil não colida com o dono
        if (owner != null)
        {
            ownerCollider = owner.GetComponent<Collider>();
            Collider thisCollider = GetComponent<Collider>();

            if (ownerCollider != null && thisCollider != null)
            {
                Physics.IgnoreCollision(thisCollider, ownerCollider);
            }
        }

        Invoke(nameof(StartReturn), returnDelay);
    }

    void StartReturn()
    {
        returning = true;
    }

    void FixedUpdate()
    {
        if (returning && owner != null)
        {
            Vector3 dirToOwner = (owner.transform.position - transform.position).normalized;
            rb.linearVelocity = dirToOwner * speed;
        }
    }

    public void SetOwner(GameObject user)
    {
        owner = user;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Ignora colisão com o dono
        if (collision.gameObject == owner)
            return;

        // Aqui você pode colocar efeitos, dano, etc.
        Destroy(gameObject);
    }
}
