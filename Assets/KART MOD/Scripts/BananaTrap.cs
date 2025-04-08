using UnityEngine;

public class BananaTrap : MonoBehaviour
{
    public float destroyDelay = 5f;
    private Collider bananaCollider;

    private void Start()
    {
        bananaCollider = GetComponent<Collider>();
        Destroy(gameObject, destroyDelay);
    }

    public void IgnorePlayer(GameObject player)
    {
        Collider playerCollider = player.GetComponent<Collider>();

        if (bananaCollider != null && playerCollider != null)
        {
            Physics.IgnoreCollision(bananaCollider, playerCollider, true);
            Invoke(nameof(ReenableCollision), 1f); // Reativa depois de 1 segundo (opcional)
        }
    }

    private void ReenableCollision()
    {
        // Se quiser reativar a colisão com o jogador depois de um tempo
        // Comente se quiser ignorar para sempre
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Aqui você pode ativar seu giro/efeito normal
        Debug.Log("Colidiu com: " + collision.gameObject.name);
        Destroy(gameObject); // Destroi a banana após o uso
    }
}
