using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraa : MonoBehaviour
{
    GameObject player;
    Vector3 v;
    float set;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("player");
        set = Mathf.Abs(transform.position.z - player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        v = transform.position;
        v.z =player.transform.position.z-set;
        transform.position =v;
    }
}
