using TMPro;
using UnityEngine;

public class NPC : Stuff
{
    bool isGive = false;
    int talkTime = 3;
    int count = 0;
    public TMP_Text WordTextUI;
    public bool isInteractable { get => CanUse; set => CanUse = value; }
    Quest quest;

    public override void SetUP()
    {
        base.SetUP();
    }
   
}
