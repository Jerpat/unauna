using TMPro;
using UnityEngine;

public class NPC : Stuff, IInteractable, IQuestGiver
{
    public bool canTalk = true;
    bool isGive = false;
    int talkTime = 3;
    int count = 0;
    public TMP_Text WordTextUI;
    public bool isInteractable { get => canTalk; set => canTalk = value; }
    Quest quest;

    public override void SetUP()
    {
        base.SetUP();
        quest = new Quest("Kill Slime", "Kill 3 Slime");
    }
    public void Interact(Player player)
    {
        if (CanGiveQuest()) {
            WordTextUI.text = quest.description;
            WordTextUI.gameObject.SetActive(true);
            isGive = true;
            Invoke("CloseWord", 3);
            StartQuest(quest);
        }
        else{
            count++;
            WordTextUI.text = "Hi Player";
            WordTextUI.gameObject.SetActive(true);
            Invoke("CloseWord", 3);
        }
    }
    void CloseWord()
    {
        WordTextUI.gameObject.SetActive(false);
    }

    public bool CanGiveQuest()
    {
        return count > talkTime && isGive == false;
    }

    public void CompleteQuest(Quest quest)
    {
    }

    public void StartQuest(Quest quest)
    {
      
    }
}
