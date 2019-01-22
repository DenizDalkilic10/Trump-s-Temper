using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

	public float timeLeft = 3.0f;
	public Text startText; // used for showing countdown from 3, 2, 1 


	void Update()
	{
		timeLeft -= Time.deltaTime;
		startText.text = (timeLeft).ToString("0");
		if (timeLeft < 0)
		{
			startText.enabled = false;
			//Do something useful or Load a new game scene depending on your use-case
		}
	}
}