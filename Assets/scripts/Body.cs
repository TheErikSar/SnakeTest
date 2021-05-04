using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public GameObject body;
    public Transform SnakeHead;
    public float CircleDiameter;

    //private List<Vector3> positions = new List<Vector3>();


    void Start()
    {
        SnakeHead = gameObject.GetComponentInParent<Transform>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp( SnakeHead.position, transform.position, 100);
    }
}