using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanEat : MonoBehaviour
{
    Transform Rot;
    bool isDead = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (isDead)
        {
            transform.position = Vector3.Lerp(transform.position,Rot.position, 0.5f); 
            gameObject.transform.localScale *= 0.95f;
        }
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "rot")
        {
            Rot = other.GetComponentInParent<Transform>();
            isDead = true;
            Invoke("Dead", 0.5f);
        }

    }
    private void Dead()
    {
        Destroy(gameObject);
    }
}
