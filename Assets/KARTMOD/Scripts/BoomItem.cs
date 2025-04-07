using UnityEngine;

[CreateAssetMenu(menuName = "Items/Boomerang")]
public class BoomItem : ItemBase
{
    public GameObject boomerangPrefab;

    public override void Use(GameObject user)
    {
        // Posi��o de spawn um pouco � frente e acima do jogador
        Vector3 spawnPos = user.transform.position + user.transform.forward * 2f + Vector3.up * 0.5f;
        Quaternion rotation = Quaternion.LookRotation(user.transform.forward);

        GameObject boomerang = GameObject.Instantiate(boomerangPrefab, spawnPos, rotation);

        // Impede colis�o imediata com o jogador
        Collider userCollider = user.GetComponent<Collider>();
        Collider boomerangCollider = boomerang.GetComponent<Collider>();
        if (userCollider != null && boomerangCollider != null)
        {
            Physics.IgnoreCollision(boomerangCollider, userCollider);
        }
    }
}
