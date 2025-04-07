using UnityEngine;

[CreateAssetMenu(menuName = "Items/Banana")]
public class BananaItem : ItemBase
{
    public GameObject bananaPrefab;

    public override void Use(GameObject user)
    {
        Vector3 spawnPos = user.transform.position - user.transform.forward;
        GameObject.Instantiate(bananaPrefab, spawnPos, Quaternion.identity);
    }
}
