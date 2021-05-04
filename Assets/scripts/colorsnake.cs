using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorsnake : MonoBehaviour
{
	Renderer col;
    private void Start()
    {
		col = gameObject.GetComponentInChildren<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "line")
		{
			col.material.color = other.GetComponentInChildren<Renderer>().material.color;
		}
	}
}
