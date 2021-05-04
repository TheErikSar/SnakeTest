using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SnakeMovment : MonoBehaviour
{
	Renderer col;
	Animation anim;
	Ray ray;
	public int coin;
	public float Speed;
	public float RotationSpeed;
	public List<GameObject> tailObjects = new List<GameObject>();
	public float z_offset = 0.5f;
	Vector3 pos;
	Vector3 move;
	public GameObject TailPrefab;
	public Text ScoreText;
	public int score = 0;
	float flag;
	float distance;
	int counttail = 2;
	public bool fev=false;
	Vector3 fevermove;
	public Text txt;
	void Start()
	{
		col = gameObject.GetComponentInChildren<Renderer>();
		tailObjects.Add(gameObject);
		move = new Vector3(0, 0, Speed);
		fevermove = new Vector3(Speed,0,Speed*3);
		AddTail();
		AddTail();
		anim = gameObject.GetComponentInChildren<Animation>();
	}
	void Update()
	{
		ScoreText.text = coin.ToString();
		txt.text = score.ToString();
		if (!fev)
		{
			transform.position += move * Time.deltaTime;
			if (Input.GetMouseButton(0))
			{
				ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, Mathf.Infinity))
				{
					pos = transform.position;
					pos.x = hit.point.x;
					distance = transform.position.x - pos.x;
					transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * Speed);

					if (Mathf.Abs(distance) > 1)
					{
						flag = distance < 0 ? 1 : -1;
						transform.forward = new Vector3(0.5f * flag, 0, 0.5f);
					}
					else
						transform.forward = Vector3.forward;
				}
			}
			else if (Input.GetMouseButtonUp(0))
			{
				transform.forward = Vector3.forward;
			}
		}
        else
        {
			fever();
        }
	}
	public void AddTail()
	{
		Vector3 newTailPos = tailObjects[tailObjects.Count - 1].transform.position;
		newTailPos.z -= z_offset;
		tailObjects.Add(GameObject.Instantiate(TailPrefab, newTailPos, Quaternion.identity) as GameObject);
	}

	//очки за поедание
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "eat")
		{
			anim.Play();
			if (col.material.color == other.GetComponentInChildren<Renderer>().material.color)
			{
				if (counttail < 8)
				{
					counttail++;
					AddTail();
				}
				score++;
			}
			else if (!fev) gameover();
		}
		//проигрыш
		if (other.tag == "enemy")
		{
			if(fev)
				anim.Play();
			else
				gameover();
		}
		if (other.tag == "coin")
		{
			anim.Play();
			coin += 10;
            if (coin > 29)
            {
				fev = true;
				transform.position = new Vector3(516.223f, transform.position.y, transform.position.z);
				Invoke("stopfever", 5);
            }
		}
        if (other.tag == "line")
        {
            col.material.color = other.GetComponentInChildren<Renderer>().material.color;
        }
    }
	void gameover()
    {
		SceneManager.LoadScene(0);
    }
	void fever()
    {

		
		transform.position += fevermove * Time.deltaTime;
		if (517.223f< transform.position.x || 515.223f>transform.position.x)
			fevermove.x *=-1 ;

	}
	void stopfever()
    {
		
		coin = 0;
		fev = false;
    }
}
