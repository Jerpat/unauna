using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Stuff : Identity
{
    public TMP_Text interactionTextUI;
    protected Collider _collider;
    public bool CanUse = true;
    public override void SetUP()
    {
        interactionTextUI = GetComponentInChildren<TMP_Text>();
        _collider = GetComponent<Collider>();
    }
    public void Update()
    {
        //Logic for Stuff
        if (GetDistancePlayer() >= 3 || !CanUse)
        {
            interactionTextUI.gameObject.SetActive(false);
        }
        else
        {
            interactionTextUI.gameObject.SetActive(true);
        }
    }

}
