using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public ItemBase currentItem;

    void Update()
    {
        if (currentItem != null && Input.GetKeyDown(KeyCode.Space))
        {
            UseItem();
        }
    }

    public void SetItem(ItemBase item)
    {
        currentItem = item;
        Debug.Log("Item recebido: " + item.itemName);
    }

    public void UseItem()
    {
        if (currentItem != null)
        {
            currentItem.Use(gameObject);
            Debug.Log("Item usado: " + currentItem.itemName);
            currentItem = null;
        }
    }

    public bool HasItem()
    {
        return currentItem != null;
    }
}
