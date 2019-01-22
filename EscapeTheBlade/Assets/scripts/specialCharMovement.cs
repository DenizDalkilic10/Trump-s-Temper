using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialCharMovement : MonoBehaviour {
	public GameObject bullet;
	Vector2 bulletPos;
	float timeForm;
	float fireDelay = 1.6f;
	// Use this for initialization
	void Start () {
		timeForm = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion rot = transform.rotation;
		rot.y = 180;
		transform.rotation = rot;
		walk ();
		if (Time.time - timeForm > fireDelay && Time.time - timeForm < fireDelay+0.02 && !GameController.hard)
			fire ();
		else if (Time.time - timeForm > fireDelay && Time.time - timeForm < fireDelay+0.02 && GameController.hard && !GameController.ultraHard)
			fireLevel2 ();
		else if (Time.time - timeForm > fireDelay && Time.time - timeForm < fireDelay+0.02 && GameController.hard && GameController.ultraHard)
			fireLevel3 ();
	}
	void fire(){                                 //Simplify the below functions later could be implemented much easier and shorter
		bulletPos = transform.position;
		bulletPos.x = transform.position.x - 27;
		bulletPos.y = transform.position.y + 9;
		Instantiate (bullet, bulletPos, Quaternion.identity);
	}
	void fireLevel2(){
		fire ();
		bulletPos = transform.position;
		bulletPos.x = transform.position.x - 27;
		bulletPos.y = transform.position.y + 16;
		Instantiate (bullet, bulletPos, Quaternion.identity);
	}
	void fireLevel3(){
		fireLevel2 ();
		bulletPos = transform.position;
		bulletPos.x = transform.position.x - 27;
		bulletPos.y = transform.position.y + 6;
		Instantiate (bullet, bulletPos, Quaternion.identity);
	}
	void walk(){
		if (Time.time - timeForm > 0.9f && transform.position.x > 185) {
			Vector3 pos = transform.position;
			pos.x -= 80 * Time.deltaTime;
			transform.position = pos;
		}
	}
}
