using UnityEngine;

public class FolhaOrbit : MonoBehaviour
{
    private Transform target;
    private float timer;
    private float orbitSpeed = 180f;
    private float radius = 5f;
    private float angle;

    public void Initialize(Transform player, float duration, float startAngle)
    {
        target = player;
        timer = duration;
        angle = startAngle;

        // Posição inicial com ângulo
        Vector3 offset = Quaternion.Euler(0, angle, 0) * Vector3.right * radius;
        transform.position = target.position + offset;

        // Ignorar colisão com o jogador
        Collider folhaCol = GetComponent<Collider>();
        Collider playerCol = player.GetComponent<Collider>();
        if (folhaCol != null && playerCol != null)
        {
            Physics.IgnoreCollision(folhaCol, playerCol);
        }
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

        // Atualiza o ângulo e posição ao redor do jogador
        angle += orbitSpeed * Time.deltaTime;
        Vector3 offset = Quaternion.Euler(0, angle, 0) * Vector3.right * radius;
        transform.position = target.position + offset;
    }
}
