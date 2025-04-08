using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public ItemBase currentItem;
    public string useButton = "shoot1"; // Você pode trocar no Inspector

    void Update()
    {
        if (currentItem != null && Input.GetButtonDown(useButton))
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
