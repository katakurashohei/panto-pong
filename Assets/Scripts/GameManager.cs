using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualPantoFramework;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject ball;
    private GameObject player;
    PantoCollider[] pantoColliders;
    PantoHandle upperHandle;
    public bool gameStarted = false;
    void Start()
    {
        StartGame();
        ball = GameObject.FindGameObjectWithTag("ball");
        player = GameObject.FindGameObjectWithTag("player");
        pantoColliders = GameObject.FindObjectsOfType<PantoCollider>();
        foreach (PantoCollider collider in pantoColliders)
        {
            collider.CreateObstacle();
            collider.Enable();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted) return;
        if (ball.transform.position.z < -17.5f || ball.transform.position.z > -2)
        {
            gameStarted = false;
            ball.transform.position = new Vector3(0,0,-10);
            player.transform.position = new Vector3(0,0,-14.7f);
            GameObject.FindObjectOfType<Ball>().ballDirection = new Vector3(2,0, -1).normalized;
            StartGame();
        }
    }

    public async void StartGame()
    {
        Level level = GameObject.Find("Panto").GetComponent<Level>();
        await level.PlayIntroduction(1f);
        await GameObject.FindObjectOfType<Ball>().ActivateBall();
        await GameObject.FindObjectOfType<PantoPlayer>().ActivatePlayer();
        gameStarted = true;
    }
}
