using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image itemIconImage;       // Referência ao Image da UI
    public ItemHolder itemHolder;     // Referência ao script que segura o item

    void Update()
    {
        // Se o jogador estiver segurando um item, mostra o ícone
        if (itemHolder != null && itemHolder.currentItem != null)
        {
            itemIconImage.enabled = true;

            // Só atualiza se o ícone for diferente para evitar "flicker"
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
