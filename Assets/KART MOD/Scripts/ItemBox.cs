using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public ItemBase[] possibleItems;

    private void OnTriggerEnter(Collider other)
    {
        ItemHolder holder = other.GetComponent<ItemHolder>();
        if (holder != null && !holder.HasItem())
        {
            int randomIndex = Random.Range(0, possibleItems.Length);
            holder.SetItem(possibleItems[randomIndex]);

            Debug.Log("Item box ativada!");
            Destroy(gameObject); // ou use SetActive(false)
        }
    }
}
