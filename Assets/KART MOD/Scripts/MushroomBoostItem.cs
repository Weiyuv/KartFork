using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Items/Mushroom Boost")]
public class MushroomBoostItem : ItemBase
{
    public float boostForce = 300f;
    public float boostDuration = 2f;

    public override void Use(GameObject user)
    {
        user.GetComponent<MonoBehaviour>().StartCoroutine(ApplyBoost(user));
    }

    private IEnumerator ApplyBoost(GameObject user)
    {
        Rigidbody rb = user.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody não encontrado no jogador.");
            yield break;
        }

        float timer = 0f;
        while (timer < boostDuration)
        {
            rb.AddForce(user.transform.forward * boostForce * Time.deltaTime, ForceMode.VelocityChange);
            timer += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Boost finalizado.");
    }
}
