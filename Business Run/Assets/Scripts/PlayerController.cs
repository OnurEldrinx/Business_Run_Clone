using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float defaultSpeed = 3;
    private float horizontalInput;

    public List<GameObject> rollerSkate;
    public GameObject motorcycle;
    public GameObject bicycle;
    public GameObject skateboard;

    public GameObject activeVehicle;

    // Start is called before the first frame update
    void Start()
    {

        skateboard.GetComponent<Vehicle>().isOnPlayer = true;
        rollerSkate[0].GetComponent<Vehicle>().isOnPlayer = true;
        rollerSkate[1].GetComponent<Vehicle>().isOnPlayer = true;
        motorcycle.GetComponent<Vehicle>().isOnPlayer = true;
        bicycle.GetComponent<Vehicle>().isOnPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.isGameStarted && !GameManager.Instance.isFailed && !GameManager.Instance.isSucceed)
        {

            Move();
            GetComponent<Animator>().SetBool("walking", true);

        }


        if (GameManager.Instance.isFailed)
        {

            if (activeVehicle == null)
                GetComponent<Animator>().SetBool("defeated", true);
            else
                activeVehicle.SetActive(false);
                GetComponent<Animator>().Play("Armature|Defeated");


        }

        /*
        if (activeVehicle == rollerSkate[0] || activeVehicle == rollerSkate[1] || activeVehicle == skateboard)
        {

            //GetComponent<Animator>().Play("Armature|Skateboarding");

        }
        else if (activeVehicle == motorcycle)
        {

            GetComponent<Animator>().Play("OnMotorcycleAnim");

        }
        else if (activeVehicle == bicycle)
        {

            GetComponent<Animator>().Play("OnBicycleAnim");

        }else if(activeVehicle == null && speed < 5)
        {

            GetComponent<Animator>().Play("Armature|Walking");
            GetComponent<Animator>().SetBool("walking", true);

        }
        else if (activeVehicle == null && speed >= 5)
        {

            GetComponent<Animator>().Play("Armature|medium_Run");
            GetComponent<Animator>().SetBool("running", true);
        }*/


    }

    public void Move()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        ClampPosition();


    }

    private void AutoMoveForward()
    {

        transform.Translate(Vector3.forward * (speed / 2) * Time.deltaTime);

    }

    private void ClampPosition()
    {

        AutoMoveForward();

        float c = Mathf.Clamp(transform.position.x, -1.4f, 1.4f);

        transform.position = new Vector3(c, transform.position.y, transform.position.z);

        
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Coin")
        {

            GameManager.Instance.coinScore += other.GetComponent<Collectable>().value;
            other.gameObject.SetActive(false);

        }else if (other.tag == "Time+" || other.tag == "Time-")
        {

            GameObject.Find("Timer").GetComponent<Timer>().counter += other.GetComponent<Collectable>().value;
            other.gameObject.SetActive(false);

        }else if(other.tag == "Finish" && !GameManager.Instance.isFailed)
        {

            GameManager.Instance.isSucceed = true;
            activeVehicle.SetActive(false);
            activeVehicle = null;
            GetComponent<Animator>().Play("Armature|Dance");
            UIManager.Instance.AmazingText.gameObject.SetActive(true);
            UIManager.Instance.NextButton.gameObject.SetActive(true);
            

        }


    }

}
