﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    private void Start()
    {
        // Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the Text Component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();
        // Set the starting number of points to 0;
        scoreGT.text = "0";
    }

    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera's z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Find out what hit this basket
        GameObject collidedWith = collision.gameObject;
        if ( collidedWith.tag == "Apple" )
        {
            string name = collidedWith.name;
            Destroy(collidedWith);

            // Parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            // Add points for catching the apple
            if (name == "Apple(Clone)")
            { score += 100; }
            else if (name == "HarderApple(Clone)")
            { score += 125; }
            else if (name == "HardApple(Clone)")
            { score += 150; }
            else if (name == "VeryHardApple(Clone)")
            { score += 175; }
            else if (name == "HardestApple(Clone)")
            { score += 200; }
            else 
            { score += 0; }
            
            // Convert the score back to a string and display it
            scoreGT.text = score.ToString();

            // Track the high score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }

        if (collidedWith.tag == "Rock")
        {
            Destroy(collidedWith);
            int score = int.Parse(scoreGT.text);
            score -= 500;
            scoreGT.text = score.ToString();
        }
    }
}
