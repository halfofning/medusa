using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressM : MonoBehaviour {

    public string previousScene;

	// Use this for initialization
	void Start () {
        previousScene = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
        checkMenu();
	}

    private void checkMenu()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("LevelSelect");

        }
        //{
        ////if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Debug.Log("hi");
        //    SceneManager.LoadScene(currentScene);
        //}
    }
}
