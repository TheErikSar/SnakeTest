using UnityEngine;
using System.Collections;


public class TailMovment : MonoBehaviour {
	public float Speed;
	public Vector3 tailTarget;
    GameObject tailTargetObj;
	SnakeMovment mainSnake;
	public GameObject My;

	void Awake()
	{
		//mainSnake = tailTargetObj.GetComponent<SnakeMovment>();
		mainSnake = GameObject.FindGameObjectWithTag("player").GetComponent<SnakeMovment>();
		tailTargetObj = mainSnake.tailObjects[mainSnake.tailObjects.Count-1];
		gameObject.GetComponentInChildren<Renderer>().material.color = mainSnake.gameObject.GetComponentInChildren<Renderer>().material.color;
	
	}
    void Update () {
		tailTarget = tailTargetObj.transform.position;
		//tailTarget.z -= 3;
		tailTarget -= tailTargetObj.transform.forward;
		transform.LookAt(tailTarget);
		
		transform.position = Vector3.Lerp(transform.position,tailTarget,Time.deltaTime*Speed);
		
	}
}
	

