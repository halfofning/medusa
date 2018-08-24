using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour {

    //public float speed = 1.0f;
    //public Color startColor;
    //public Color endColor;
    //float startTime;

    Rigidbody2D rb;

    //bool colourChangeCollision = false;
    public bool falling = false;

    private AudioSource source;
    public AudioClip water_sound;
    public float volume = 1.5f;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        var player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();

        // Change all block colours to black on Start.
        if (!gameObject.name.Equals("Water"))
            gameObject.transform.GetComponent<Renderer>().material.color = Color.black;

        // Change the player to a White colour
        player.transform.GetComponent<Renderer>().material.color = Color.white;

        // If block is configured to Fall from the start
        if (gameObject.name.Equals("Tile_Fall"))
        {
            Invoke("DropTile", 1.2f);
            gameObject.transform.GetComponent<Renderer>().material.color = Color.gray;
        }
    }

    void Update()
    {
        //checkColourChange();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = GameObject.Find("Player");
        //colourChangeCollision = true;
        //startTime = Time.time;

        // If a block collides with Player
        if (collision.gameObject.name.Equals("Player")) {
            // If the block is not a water block and the player has yet to touch a water block (Not "Yellow" colour)
            if (!gameObject.name.Equals("Water") && player.GetComponent<Renderer>().material.color != Color.yellow)
            {
                // The block will fall; change the block colour to Gray
                falling = true;
                Invoke("DropTile", 1.2f);
                gameObject.transform.GetComponent<Renderer>().material.color = Color.gray;
            }

            // If the block is a water block, change the player to "Yellow" colour
            if (gameObject.name.Equals("Water"))
            {
                // Change the player to "Yellow" and play sound.
                player.transform.GetComponent<Renderer>().material.color = Color.yellow;
                source.PlayOneShot(water_sound, volume);
            }
        }
    }

    void DropTile()
    {
        rb.isKinematic = false;
    }

    //void checkColourChange()
    //{
    //    // Supposedly adds a slow gradient effect into the block upon touch, but didn't work out the way we wanted it to.
    //    if (colourChangeCollision)
    //    {
    //        float t = (Time.time - startTime) * speed;
    //        GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
    //        gameObject.transform.GetComponent<Renderer>().material.color = Color.yellow;
    //    }
    //}



}
