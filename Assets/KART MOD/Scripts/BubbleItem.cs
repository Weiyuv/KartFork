using UnityEngine;

[CreateAssetMenu(menuName = "Items/Bubble")]
public class BubbleItem : ItemBase
{
    public GameObject bubblePrefab;
    public float launchForce = 300f;

    public override void Use(GameObject user)
    {
        // Afastando mais no forward e subindo mais no eixo Y
        Vector3 spawnPos = user.transform.position + user.transform.forward * 10f + Vector3.up * 1.5f;
        Quaternion rotation = user.transform.rotation;

        GameObject bubble = GameObject.Instantiate(bubblePrefab, spawnPos, rotation);

        Rigidbody rb = bubble.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = user.transform.forward * launchForce;
            Debug.Log("Bolha lançada com velocidade: " + rb.linearVelocity);
        }
        else
        {
            Debug.LogWarning("Rigidbody não encontrado na bolha.");
        }
    }
}
