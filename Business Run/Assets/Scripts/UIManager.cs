using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public Image TapToPlayBackground;
    public Image TapToPlay;
    public TextMeshProUGUI CoinScoreText;
    public TextMeshProUGUI LevelNameText;
    public Image EmptyTimeBar;
    public Image TimeBarFiller;
    public Image YouAreFiredScreen;
    public Button RestartButton;
    public Button NextButton;
    public TextMeshProUGUI AmazingText;

    public static UIManager Instance;

    private void Awake()
    {
        
        if(Instance == null)
        {

            Instance = this;

        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        UIManager.Instance.CoinScoreText.text = GameManager.Instance.coinScore.ToString();


    }
}
