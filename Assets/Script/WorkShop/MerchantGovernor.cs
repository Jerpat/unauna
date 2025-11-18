using TMPro;
using UnityEngine;

public class MerchantGovernor : Character, IInteractable, ITalkable
{
    //SetUp
    public bool canTalk = true;
    public bool canInteract = true;
    public string LoadScene1Name;

    //Interact Text
    public TMP_Text interactionTextUI;

    //Talking Conversations Text 
    public GameObject TalkingPanel;
    public TMP_Text TalkingText;
    public string[] TalkingLines;
    private int index = 0;

    public bool isInteractable { get => canInteract; set => canInteract = value; }
    public bool isTalkable { get => canTalk; set => canTalk = value; }


    public override void SetUP()
    {
        interactionTextUI = GetComponentInChildren<TMP_Text>();

        //UI Setting
        TalkingPanel.gameObject.SetActive(false);
    }
    public void Update()
    {
        if (GetDistancePlayer() >= 2f || !canInteract)
        {
            interactionTextUI.gameObject.SetActive(false);
        }
        else
        {
            interactionTextUI.gameObject.SetActive(true);
        }
        //Turn(player.transform.position - transform.position);
    }

    public void Interact(Player player)
    {
        Talk(player);
        Debug.Log("Interact With Merchant Governor");
    }
    public void Talk(Player player)
    {
        //UI Setting
        TalkingPanel.gameObject.SetActive(true);

        if (index < TalkingLines.Length)
        {
            TalkingText.text = TalkingLines[index];
            index++;
        }
        else
        {
            TalkingPanel.gameObject.SetActive(false);
            GiveQuest();
            Debug.Log("Conversation Ended");
        }
    }

    public void GiveQuest()
    {
        QuestManager.instance.StartQuest();
        Debug.Log("Quest Given");
    }

    public void GiveReward()
    {

    }
}
