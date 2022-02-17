using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleStand : MonoBehaviour
{

    public GameObject vehicleOnStand;
    public GameObject pad;
    public GameObject player;
    public Material gray;
    public Material green;
    public GameObject redPriceTag;

    // Start is called before the first frame update
    void Start()
    {

        vehicleOnStand.GetComponent<Vehicle>().isOnPlayer = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameManager.Instance.coinScore >= vehicleOnStand.GetComponent<Vehicle>().price)
        {

            pad.GetComponent<MeshRenderer>().sharedMaterial = green;
            redPriceTag.SetActive(false);

        }
        else
        {

            pad.GetComponent<MeshRenderer>().sharedMaterial = gray;
            redPriceTag.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player" && player.GetComponent<PlayerController>().activeVehicle == null)
        {

            if(GameManager.Instance.coinScore >= vehicleOnStand.GetComponent<Vehicle>().price)
            {



                switch (vehicleOnStand.GetComponent<Vehicle>().type)
                {

                    case "Skateboard":
                        player.GetComponent<PlayerController>().skateboard.SetActive(true);
                        break;
                    case "Bicycle":
                        player.GetComponent<PlayerController>().bicycle.SetActive(true);
                        break;
                    case "Motorcycle":
                        player.GetComponent<PlayerController>().motorcycle.SetActive(true);
                        break;
                    case "RollerSkate":
                        player.GetComponent<PlayerController>().rollerSkate[0].SetActive(true);
                        player.GetComponent<PlayerController>().rollerSkate[1].SetActive(true);
                        break;

                }

                GameManager.Instance.coinScore -= vehicleOnStand.GetComponent<Vehicle>().price;

            }
            else
            {


            }


        }

    }

}
