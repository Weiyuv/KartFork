using UnityEngine;

public class FolhaOrbit : MonoBehaviour
{
    private Transform target;
    private float timer;
    private float orbitSpeed = 180f; // graus por segundo
    private float radius = 2f;

    private Vector3 offset;

    public void Initialize(Transform player, float duration)
    {
        target = player;
        timer = duration;
        offset = new Vector3(radius, 0, 0); // começa à direita
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
            return;
        }

        // Rotação ao redor do player
        transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
