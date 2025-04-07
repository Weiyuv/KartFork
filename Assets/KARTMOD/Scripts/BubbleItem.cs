using UnityEngine;

[CreateAssetMenu(menuName = "Items/Bubble")]
public class BubbleItem : ItemBase
{
    public GameObject bubblePrefab;
    public float launchForce = 300f;

    public override void Use(GameObject user)
    {
        Vector3 spawnPos = user.transform.position + user.transform.forward * 2f + Vector3.up * 0.5f;
        Quaternion rotation = user.transform.rotation;

        GameObject bubble = GameObject.Instantiate(bubblePrefab, spawnPos, rotation);

        Rigidbody rb = bubble.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = user.transform.forward * launchForce;
            Debug.Log("Bolha lan�ada com velocidade: " + rb.linearVelocity);
        }
        else
        {
            Debug.LogWarning("Rigidbody n�o encontrado na bolha.");
        }
    }
}
