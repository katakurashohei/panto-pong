using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject ball;
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.z < -17.5f || ball.transform.position.z > -2)
        {
            ball.transform.position = new Vector3(0,0,-10);
        }
    }
}
