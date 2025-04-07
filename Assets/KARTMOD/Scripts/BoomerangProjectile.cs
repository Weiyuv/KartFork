using UnityEngine;

public class BoomerangProjectile : MonoBehaviour
{
    public float radius = 2f;
    public float rotationSpeed = 180f;
    public float duration = 3f;
    public Transform centerPoint; // Pode ser deixado vazio pra usar Vector3.zero

    private float angle;
    private float timer;

    void Start()
    {
        if (centerPoint == null)
            centerPoint = new GameObject("BoomerangCenter").transform;

        centerPoint.position = Vector3.zero; // Ou qualquer ponto fixo desejado

        angle = 0f;
        timer = 0f;

        Vector3 offset = new Vector3(radius, 0f, 0f);
        transform.position = centerPoint.position + offset;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > duration)
        {
            Destroy(gameObject);
            return;
        }

        angle += rotationSpeed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(rad), 0f, Mathf.Sin(rad)) * radius;
        transform.position = centerPoint.position + offset;
    }
}
