using UnityEngine;

[CreateAssetMenu(menuName = "Items/Folha")]
public class FolhaItem : ItemBase
{
    public GameObject folhaPrefab;
    public int quantidade = 3;
    public float duracao = 5f;

    public override void Use(GameObject user)
    {
        for (int i = 0; i < quantidade; i++)
        {
            GameObject folha = Instantiate(folhaPrefab);
            FolhaOrbit orbit = folha.GetComponent<FolhaOrbit>();

            float angulo = (360f / quantidade) * i;
            orbit.Initialize(user.transform, duracao, angulo);
        }
    }
}
