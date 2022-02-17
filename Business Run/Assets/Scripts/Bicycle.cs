using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicycle : Vehicle
{
    // Start is called before the first frame update
    void Start()
    {

        this.price = 200;
        this.speed = 6;
        this.type = "Bicycle";
        this.driver = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.activeSelf && this.isOnPlayer)
        {

            this.driver.GetComponent<Animator>().Play("OnBicycleAnim");
            this.driver.GetComponent<PlayerController>().speed = this.speed;
            this.driver.GetComponent<PlayerController>().activeVehicle = this.gameObject;
        }
    }
}
