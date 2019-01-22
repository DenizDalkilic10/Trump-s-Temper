using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDolar : MonoBehaviour {
	//GameController control = new GameController();
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Trump")
        {
			GameController.points += 1;
            Destroy(gameObject);
        }
    }
}
