using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("HIT!");
        Destroy(gameObject); //remove pizza obj
        Destroy(other.gameObject); //remoave animal pizza colloided with
    }
}
