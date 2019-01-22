using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dolarMovement : MonoBehaviour {
    public float fallSpeed = 8.0f;
    public float spinSpeed = 250.0f;
	Collider2D col;
	void Start(){
		col = GetComponent<Collider2D> ();
	}

    void Update()
    {

        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
        Destroy(gameObject,3.6f);
		if (transform.position.y < -90f)
			col.enabled = false;
			
    }

    


}
