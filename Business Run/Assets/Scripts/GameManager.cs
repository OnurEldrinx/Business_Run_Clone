using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool isGameStarted;
    public bool isFailed;

    public static GameManager Instance;


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

        UIManager.Instance.LevelNameText.text = "LEVEL " + (SceneManager.GetActiveScene().buildIndex + 1); 
        

    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameStarted)
            StartGame();


        if (isFailed)
        {

            UIManager.Instance.YouAreFiredScreen.gameObject.SetActive(true);
            UIManager.Instance.RestartButton.gameObject.SetActive(true);
            isFailed = false;
        }

    }

    public void StartGame()
    {


        if (Input.GetMouseButtonDown(0))
        {

            isGameStarted = true;
            UIManager.Instance.TapToPlayBackground.gameObject.SetActive(false);

        }

    }

    public void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
