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
    PantoHandle itHandle;
    PantoHandle meHandle;

    public AudioClip weakHitClip;
    public AudioClip strongHitClip;
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        itHandle = GameObject.Find("Panto").GetComponent<LowerHandle>();
        meHandle = GameObject.Find("Panto").GetComponent<UpperHandle>();
        initializeDirection();
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
            audioSource.PlayOneShot(weakHitClip);
            ballDirection.x = -ballDirection.x;
        }

        if (other.gameObject.tag == "computer")
        {
            audioSource.PlayOneShot(strongHitClip);
            ballDirection.z = -ballDirection.z;
            ballDirection.x = Random.Range(0.5f, 1.5f) * ballDirection.x;
            ballDirection.Normalize();
        }

        if (other.gameObject.tag == "player")
        {
            audioSource.PlayOneShot(strongHitClip);
            ballDirection.z = -ballDirection.z;
            rotation = meHandle.GetRotation();
            if (rotation >= 0)
            {
                ballDirection.x = Mathf.Sin(rotation);
            }
            else
            {
                ballDirection.x = Mathf.Sin(360.0f+ rotation);
            }

            ballDirection.Normalize();
        }
    }

    public void initializeDirection()
    {
        ballDirection = new Vector3(2,0, -1).normalized;
    }
    

    public async Task ActivateBall()
    {
        await itHandle.SwitchTo(gameObject, 20f);
    }
}
