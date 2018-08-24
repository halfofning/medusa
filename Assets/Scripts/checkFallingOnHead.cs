using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkFallingOnHead : MonoBehaviour
{
    private float delayTime = 2f;
    private float time;

    //public Animation anim;

    //private void Start()
    //{
    //    anim = GetComponent<Animation>();
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.GetComponentInParent<Collision>().falling)
        {
            Destroy(collision.gameObject);
            Invoke("SceneDeath", delayTime);
        }
    }

    void SceneDeath() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}