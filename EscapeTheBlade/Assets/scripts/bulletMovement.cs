using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour {
	public float moveSpeed = 110.0f;
	public int rotZ;
	//public GameObject Trump;
	// Use this for initialization
	//Collider2D col;
	void Start(){
		
		//col = GetComponent<Collider2D> ();
		transform.Rotate (Vector3.forward, rotZ);
		//col.isTrigger = true;
	}
	// Update is called once per frame
	void Update () {
		//if (transform.position.x < Trump.transform.position.x)
		//	col.isTrigger = false;
		transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
		Destroy(gameObject,7.0f);
	}
}

