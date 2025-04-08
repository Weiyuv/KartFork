using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject waypointPrefab;
    public Transform startPoint;
    public Transform endPoint;
    public float spacing = 2f; // Distância entre os waypoints

    void Start()
    {
        GenerateWaypoints();
    }

    void GenerateWaypoints()
    {
        Vector3 direction = (endPoint.position - startPoint.position).normalized;
        float distance = Vector3.Distance(startPoint.position, endPoint.position);
        int waypointCount = Mathf.FloorToInt(distance / spacing);

        for (int i = 0; i <= waypointCount; i++)
        {
            Vector3 spawnPosition = startPoint.position + direction * spacing * i;

            // Opcional: Raycast para ajustar à pista
            if (Physics.Raycast(spawnPosition + Vector3.up * 10f, Vector3.down, out RaycastHit hit, 20f))
            {
                spawnPosition = hit.point;
            }

            Instantiate(waypointPrefab, spawnPosition, Quaternion.identity, transform);
        }
    }
}
