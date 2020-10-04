﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    // Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    private void Start()
    {
        // Dropping apples every second
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>( applePrefab );
        apple.transform.position = transform.position;
        Invoke( "DropApple", secondsBetweenAppleDrops );
    }

    private void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if ( pos.x < -leftAndRightEdge )
        {
            speed = Mathf.Abs(speed); // Move right
        }
        else if ( pos.x > leftAndRightEdge )
        {
            speed = -Mathf.Abs(speed); // Move left
        }
    }

    private void FixedUpdate()
    {
        // Because in FixedUpdate() chance is time-based instead of framebased
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; // Change direction based on random value
        }
    }
}
