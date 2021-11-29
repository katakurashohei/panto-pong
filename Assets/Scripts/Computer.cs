using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public float speed = 10.0f;
    public float level = 0.5f;
    private float step = 0.0f;


    private GameObject ball;

    private Vector3 ballPos;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        step = level + Random.Range(-1.0f, 0.0f);
        Move(step);

    }

    void Move(float step)
    {
        if (!ball) ball = GameObject.FindGameObjectWithTag("ball");

        if (ball.GetComponent<Ball>().ballDirection.z  > 0 )
        {
            ballPos = ball.transform.localPosition;

            if (ballPos.x - transform.localPosition.x < -step)
            {
                transform.localPosition += new Vector3(-speed * Time.deltaTime, 0, 0);
            }

            if (ballPos.x - transform.localPosition.x > step)
            {
                transform.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }


    }

   
}
