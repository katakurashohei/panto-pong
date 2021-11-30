using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualPantoFramework;
using System.Threading.Tasks;

public class Ball : MonoBehaviour
{
    public float speed = 5;
    private float rotation;
    public Vector3 ballDirection;

    
    void Start()
    {
        initializeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(ballDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            ballDirection.x = -ballDirection.x;
        }

        if (other.gameObject.tag == "computer")
        {
            ballDirection.z = -ballDirection.z;
            ballDirection.x = Random.Range(0.5f, 1.5f) * ballDirection.x;
            ballDirection.Normalize();
        }

        if (other.gameObject.tag == "player")
        {
            ballDirection.z = -ballDirection.z;
            ballDirection.Normalize();
        }
    }

    public void initializeDirection()
    {
        ballDirection = new Vector3(2,0, -1).normalized;
    }
}
