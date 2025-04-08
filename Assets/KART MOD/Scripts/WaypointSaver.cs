#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class WaypointSaver : MonoBehaviour
{
    [MenuItem("Ferramentas/Salvar Waypoints")]
    public static void SaveWaypoints()
    {
        GameObject container = GameObject.Find("WaypointContainer"); // ou use seu nome exato
        if (container == null)
        {
            Debug.LogWarning("WaypointContainer não encontrado.");
            return;
        }

        // Container novo para salvar os clones
        GameObject cloneContainer = new GameObject("WaypointsSalvos");

        int count = 0;

        foreach (Transform waypoint in container.transform)
        {
            GameObject clone = Object.Instantiate(waypoint.gameObject);
            clone.transform.position = waypoint.position;
            clone.transform.rotation = waypoint.rotation;
            clone.transform.SetParent(cloneContainer.transform);
            clone.name = waypoint.name + "_Clone";
            count++;
        }

        Debug.Log($"Clonagem concluída. {count} waypoint(s) clonados.");
    }
}
#endif
