using TMPro;
using UnityEngine;

public abstract class InteractableBase : MonoBehaviour
{
    [Header("Interaction UI")]
    public TMP_Text interactionTextUI;
    public TMP_Text wordTextUI;

    protected Player player;

    public bool canInteract = true;
    public float showDistance = 3f;

    public void UpdateUI(Player _player)
    {
        player = _player;
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (interactionTextUI != null)
        {
            interactionTextUI.gameObject.SetActive(canInteract && distance <= showDistance);
        }
    }

    public void ShowWordUI()
    {
        if (wordTextUI != null)
        {
            wordTextUI.gameObject.SetActive(true);
            CancelInvoke(nameof(CloseWordUI));
            Invoke(nameof(CloseWordUI), 3f);
        }
    }

    protected virtual void CloseWordUI()
    {
        if (wordTextUI != null)
            wordTextUI.gameObject.SetActive(false);
    }
}
