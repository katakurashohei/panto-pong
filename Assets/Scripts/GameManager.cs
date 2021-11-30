using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualPantoFramework;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    private GameObject ball;
    private GameObject player;
    PantoCollider[] pantoColliders;
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

    async void Update()
    {
        if (!gameStarted) return;
        if (ball.transform.position.z < -18f || ball.transform.position.z > -1)
        {
            gameStarted = false;
            await Task.Delay(2000);
            ball.transform.position = new Vector3(0,0,-10);
            player.transform.position = new Vector3(0,0,-14.7f);
            GameObject.FindObjectOfType<Ball>().initializeDirection();
            StartGame();
        }
    }

    public async Task StartGame()
    {
        Level level = GameObject.Find("Panto").GetComponent<Level>();
        await level.PlayIntroduction(1.0f);
        await GameObject.FindObjectOfType<Ball>().ActivateBall();
        await GameObject.FindObjectOfType<PantoPlayer>().ActivatePlayer();
        gameStarted = true;
    }
}
