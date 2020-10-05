using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public static float bottomY = -20f;
    public float speed = -50f;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
    }
}
