using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xRange = 14;
    public float zRange =8;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate() {
        float HorizontalMovement = Input.GetAxis("Horizontal");
        float VerticalMovement = Input.GetAxis("Vertical");   
        Vector3 moveBall = new Vector3(HorizontalMovement, 0, VerticalMovement);

        if(transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y,transform.position.z);
        }

        if(transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y,transform.position.z);
        }

        if(transform.position.z < -zRange){
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if(transform.position.z > zRange){
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        gameObject.transform.GetComponent<Rigidbody>().AddForce(moveBall * speed);
    }
}
