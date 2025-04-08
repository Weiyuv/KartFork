using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour
{
    public float levitateDuration = 2f;
    public float levitateSpeed = 3f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null && rb.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Levitate(rb));
        }

        Destroy(gameObject);
    }

    private IEnumerator Levitate(Rigidbody rb)
    {
        float timer = 0f;
        rb.useGravity = false;

        while (timer < levitateDuration)
        {
            rb.linearVelocity = new Vector3(0, levitateSpeed, 0);
            timer += Time.deltaTime;
            yield return null;
        }

        rb.linearVelocity = Vector3.zero;
        rb.useGravity = true;
    }
}
