using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image itemIconImage;       // Refer�ncia ao Image da UI
    public ItemHolder itemHolder;     // Refer�ncia ao script que segura o item

    void Update()
    {
        // Se o jogador estiver segurando um item, mostra o �cone
        if (itemHolder != null && itemHolder.currentItem != null)
        {
            itemIconImage.enabled = true;

            // S� atualiza se o �cone for diferente para evitar "flicker"
            if (itemIconImage.sprite != itemHolder.currentItem.icon)
            {
                itemIconImage.sprite = itemHolder.currentItem.icon;
            }
        }
        else
        {
            itemIconImage.enabled = false;
        }
    }
}
