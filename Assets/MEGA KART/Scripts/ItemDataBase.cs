using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance;
    public List<ItemBase> items;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public ItemBase GetRandomItem()
    {
        int index = Random.Range(0, items.Count);
        return Instantiate(items[index]); // Clone so it's safe for per-instance data
    }
}
