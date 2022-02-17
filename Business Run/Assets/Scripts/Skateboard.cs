using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skateboard : Vehicle
{
    // Start is called before the first frame update
    void Start()
    {

        this.price = 120;
        this.speed = 5;
        this.type = "Skateboard";
        this.driver = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.activeSelf && this.isOnPlayer)
        {

            this.driver.GetComponent<Animator>().Play("Armature|Skateboarding");
            this.driver.GetComponent<PlayerController>().speed = this.speed;
            this.driver.GetComponent<PlayerController>().activeVehicle = this.gameObject;
        }

    }
}
