using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualPantoFramework;
using System.Threading.Tasks;

public class Ball : MonoBehaviour
{
    public float speed = 5;
    public Vector3 ballDirection;
    
    PantoHandle itHandle;

    

    void Start()
    {
        itHandle = GameObject.Find("Panto").GetComponent<LowerHandle>();
        ballDirection = new Vector3(2,0, -1).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindObjectOfType<GameManager>().gameStarted) return;
        transform.Translate(ballDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            ballDirection.x = -ballDirection.x;
        }

        if (other.gameObject.tag == "computer" || other.gameObject.tag =="player")
        {
            ballDirection.z = -ballDirection.z;
            ballDirection.x = Random.Range(0.5f, 1.1f) * ballDirection.x;
            ballDirection.Normalize();
        }
        
    }
    

    public async Task ActivateBall()
    {
        await itHandle.SwitchTo(gameObject, 20f);
    }
}
