using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float time;
    public float counter;

    // Start is called before the first frame update
    void Start()
    {

        counter = time;

    }

    // Update is called once per frame
    void Update()
    {


        if (GameManager.Instance.isGameStarted) {


            if (counter > 0 && !GameManager.Instance.isFailed && !GameManager.Instance.isSucceed)
            {

                counter -= Time.deltaTime;

                UIManager.Instance.TimeBarFiller.fillAmount = counter / time;

            }
            else
            {
                if(!GameManager.Instance.isSucceed)
                    GameManager.Instance.isFailed = true;


            }

            if(counter > time)
            {

                counter = time;

            }

        }

        

        

        
    }
}
