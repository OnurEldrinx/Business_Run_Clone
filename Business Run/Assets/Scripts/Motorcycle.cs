using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motorcycle : Vehicle
{
    // Start is called before the first frame update
    void Start()
    {

        this.price = 300;
        this.speed = 7;
        this.type = "Motorcycle";
        this.driver = GameObject.FindGameObjectWithTag("Player");
        

    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.activeSelf && this.isOnPlayer)
        {



            this.driver.GetComponent<PlayerController>().speed = this.speed;
            this.driver.GetComponent<Animator>().Play("OnMotorcycleAnim");
            this.driver.GetComponent<PlayerController>().activeVehicle = this.gameObject;

        }
        


    }
}
