using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public int value;

    // Start is called before the first frame update
    void Start()
    {

        switch (this.tag)
        {

            case "Coin":

                value = 1000;

                break;

            case "Time+":

                value = 5;

                break;

            case "Time-":

                value = -5;

                break;



        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
