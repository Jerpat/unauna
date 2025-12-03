using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameManager : MonoBehaviour
{
    public static UIGameManager instance;

    //Talking UI Setting
    public GameObject talkingPanel;
    public TMP_Text talkingText;
    public TMP_Text talkingNameText;

    //Quest UI Setting
    public GameObject questPanel;
    public TMP_Text questText;
    public Slider quest1Progressbar;
    public Slider quest2Progressbar;
    public Slider quest3Progressbar;

    public GameObject pausemenuUI;
    public TMP_Text hPText;
    public TMP_Text potionCountText;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

}
