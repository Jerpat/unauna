using TMPro;
using UnityEngine;

public class GameManager02 : MonoBehaviour
{
    public TMP_Text HealthText;

    public void UpdateHealth(int health)
    {
        Debug.Log("HP : " + health);
        HealthText.text = "HP : " + " " + health.ToString();
    }
}
