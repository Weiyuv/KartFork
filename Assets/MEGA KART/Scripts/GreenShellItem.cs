using UnityEngine;

[CreateAssetMenu(menuName = "Items/Green Shell")]
public class GreenShellItem : ItemBase
{
    public GameObject shellPrefab;

    public override void Use(GameObject user)
    {
        Vector3 spawnPos = user.transform.position + user.transform.forward * 1.5f;
        Quaternion rotation = user.transform.rotation;

        GameObject shell = GameObject.Instantiate(shellPrefab, spawnPos, rotation);

        GreenShell shellScript = shell.GetComponent<GreenShell>();
        if (shellScript != null)
        {
            shellScript.Launch(user.transform.forward, user);
        }
        else
        {
            Debug.LogWarning("GreenShell script not found on shell prefab.");
        }
    }
}
