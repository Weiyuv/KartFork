using UnityEngine;

[CreateAssetMenu(menuName = "Items/Banana")]
public class BananaItem : ItemBase
{
    public GameObject bananaPrefab;

    public override void Use(GameObject user)
    {
        // Aumentamos a dist�ncia para 2 metros atr�s do jogador
        Vector3 spawnPos = user.transform.position - user.transform.forward * 2f;
        GameObject.Instantiate(bananaPrefab, spawnPos, Quaternion.identity);
    }
}
