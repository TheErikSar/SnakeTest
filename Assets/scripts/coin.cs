using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    void Start()
    {

    }

 
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "rot")
        {
            Destroy(gameObject);
        }
    }
}
