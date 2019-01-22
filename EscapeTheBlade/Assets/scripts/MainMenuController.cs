using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    public GameObject mainMenu, options;
	public void PlayGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	}

    public void Options() {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }

    public void MainMenu() {
        options.SetActive(false);
        mainMenu.SetActive(true);
    }


	public void QuitGame(){
		Debug.Log ("Quit");
		Application.Quit ();
	}
}
