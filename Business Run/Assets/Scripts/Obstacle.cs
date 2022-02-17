using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(this.tag == "Hole" && other.tag == "Player")
        {

            other.transform.parent = this.transform;
            other.transform.localPosition = Vector3.zero;
            other.GetComponent<Rigidbody>().useGravity = true;
            GameManager.Instance.isFailed = true;
            GameObject.Find("CM - Player").GetComponent<CinemachineVirtualCamera>().Follow = this.gameObject.transform;
            GameObject.Find("CM - Player").GetComponent<CinemachineVirtualCamera>().LookAt = this.gameObject.transform;



        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Player" && (this.tag == "Worker" || this.tag == "Barrier" ))
        {

            collision.gameObject.transform.DOMoveZ(collision.gameObject.transform.position.z - 2.5f,0.5f).SetEase(Ease.Flash);

            if (collision.gameObject.GetComponent<PlayerController>().activeVehicle != null)
            {

                collision.gameObject.GetComponent<PlayerController>().activeVehicle.SetActive(false);
                collision.gameObject.GetComponent<PlayerController>().activeVehicle = null;

            }
            
            
            collision.gameObject.GetComponent<Animator>().Play("Armature|Walking");
            collision.gameObject.GetComponent<PlayerController>().speed = collision.gameObject.GetComponent<PlayerController>().defaultSpeed;

        }
        

    }
}
