using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterDeath : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
        // If gameobject falls below y = -20, restart current scene
        if (gameObject.transform.position.y < -20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
