using UnityEngine;

public interface IQuestGiver 
{
    bool CanGiveQuest();
    void StartQuest(Quest quest);

}
