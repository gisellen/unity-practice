using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //keep player in bounds
        if(transform.position.x < -xRange){
           transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        //left/right input
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //space input
        if(Input.GetKeyDown(KeyCode.Space)){
            //Launch projectile from player 
            Vector3 foodVector = new Vector3(transform.position.x, transform.position.y+1, transform.position.z+1);
            Instantiate(projectilePrefab, foodVector, projectilePrefab.transform.rotation);
        }
        
    }
}
