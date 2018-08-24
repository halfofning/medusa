using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// for loading the next play scene from a text scene
public class TextLoadNextScene : MonoBehaviour {

    float delayTime = 2.5f;
	
	// Update is called once per frame
	void Update () {
        Invoke("SceneChange", delayTime);
	}

    void SceneChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
