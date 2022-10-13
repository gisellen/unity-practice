using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int speed = 50;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TARGET");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.one * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        Destroy(this.gameObject);
    }

}
