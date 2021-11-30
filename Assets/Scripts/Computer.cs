using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public float speed = 3.0f;
    private float step = 0.0f;


    private GameObject ball;
    private Vector3 ballPos;
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        step = 0.5f + Random.Range(-1.0f, 0.0f);
        Move(step);
    }

    void Move(float step)
    {
        if (!ball) ball = GameObject.FindGameObjectWithTag("ball");
 
        if (ball.GetComponent<Ball>().ballDirection.z  > 0 )
        {
            ballPos = ball.transform.position;

            if (ballPos.x - transform.position.x < -step)
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }

            if (ballPos.x - transform.position.x > step)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }
    }
}
