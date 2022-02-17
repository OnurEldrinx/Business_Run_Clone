using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerSkate : Vehicle
{
    // Start is called before the first frame update
    void Start()
    {

        this.price = 90;
        this.speed = 4;
        this.type = "RollerSkate";
        this.driver = GameObject.FindGameObjectWithTag("Player");



    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.activeSelf && this.isOnPlayer)
        {

            this.driver.transform.position = new Vector3(this.driver.transform.position.x, 0.15f, this.driver.transform.position.z);

            this.driver.GetComponent<Animator>().Play("Armature|Skateboarding");
            this.driver.GetComponent<PlayerController>().speed = this.speed;
            this.driver.GetComponent<PlayerController>().activeVehicle = this.gameObject;

        }
        else
        {



        }

    }
}
