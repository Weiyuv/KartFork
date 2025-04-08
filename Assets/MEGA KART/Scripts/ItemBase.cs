using UnityEngine;

public abstract class ItemBase : ScriptableObject
{
    public string itemName;
    public Sprite icon;

    public abstract void Use(GameObject user);
}
