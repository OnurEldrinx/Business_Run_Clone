using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private float horizontalInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.isGameStarted && !GameManager.Instance.isFailed)
        {

            Move();
            GetComponent<Animator>().SetBool("walking", true);

        }


        if (GameManager.Instance.isFailed)
        {

            GetComponent<Animator>().SetBool("defeated", true);

        }

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

}
