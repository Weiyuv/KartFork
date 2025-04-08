using UnityEngine;

[CreateAssetMenu(menuName = "Items/Folha")]
public class FolhaItem : ItemBase
{
    public GameObject folhaPrefab;
    public float duration = 5f;

    public override void Use(GameObject user)
    {
        GameObject folha = Instantiate(folhaPrefab, user.transform.position + Vector3.up * 2f, Quaternion.identity);
        folha.GetComponent<FolhaOrbit>().Initialize(user.transform, duration);
    }
}
