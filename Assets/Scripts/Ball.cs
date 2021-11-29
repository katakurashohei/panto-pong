using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualPantoFramework;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    bool movementStarted = false;
    PantoHandle itHandle;
    
    public Vector3 ballDirection;
    

    async void Start()
    {
        itHandle = GameObject.Find("Panto").GetComponent<LowerHandle>();
        await itHandle.SwitchTo(gameObject, 20f);
        movementStarted = true;
        ballDirection = new Vector3(2,0, -1).normalized;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((ballDirection * speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            ballDirection.x = -ballDirection.x;
        }

        if (other.gameObject.tag == "bar")
        {
            ballDirection.z = -ballDirection.z;
            ballDirection.x = Random.Range(0.5f, 1.1f) * ballDirection.x;
            ballDirection.Normalize();
        }
    }
}
