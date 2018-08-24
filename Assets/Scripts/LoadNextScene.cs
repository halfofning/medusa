using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// for loading the next text scene from a play scene
public class LoadNextScene : MonoBehaviour {
    
    public float delayTime = -0.4f;
    public bool changeScene = false;

    private AudioSource source;
    public AudioClip bell_sound;
    public float volume = 10f;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        // Set End Goal to Yellow colour
        if (gameObject.name.Equals("ExtraChar"))
            gameObject.transform.GetComponent<Renderer>().material.color = Color.yellow;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = GameObject.Find("Player");

        // If Player collides with the End Goal (ExtraChar)
        if (collision.gameObject.name.Equals("Player"))
        {
            // If Player has yet to touch the Water (Still appears as White colour)
            if (player.GetComponent<Renderer>().material.color == Color.white) {
                // Restart the Scene
                Time.timeScale = 0;
                StartCoroutine(ResumeAfterNSeconds(0.7f));
                gameObject.transform.GetComponent<Renderer>().material.color = Color.gray;
            }

            // If player has touched the water (Appears as Yellow colour)
            else {
                // Go to next scene
                source.PlayOneShot(bell_sound, volume);
                Time.timeScale = 0;
                StartCoroutine(ResumeAfterNSeconds(0.7f));
            }
        }
    }

    void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    float timer = 0;
    IEnumerator ResumeAfterNSeconds(float timePeriod)
    {
        yield return new WaitForEndOfFrame();
        timer += Time.unscaledDeltaTime;
        if (timer <= timePeriod) {
            StartCoroutine(ResumeAfterNSeconds(0.7f));
        }
        else
        {
            Time.timeScale = 1;
            var player = GameObject.Find("Player");

            // If Player is still white; yet to touch a Water object, restart scene
            if (player.GetComponent<Renderer>().material.color == Color.white) {
                Invoke("RestartScene", delayTime);
            }

            // If player has touched a water object, go to next scene
            else {
                Invoke("NextScene", delayTime);
            }
            timer = 0;
        }
    }
}