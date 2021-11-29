using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualPantoFramework;
using System.Threading.Tasks;

public class PantoPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    PantoHandle upperHandle;
    async void Start()
    {
        upperHandle = GameObject.Find("Panto").GetComponent<UpperHandle>();
        // await ActivatePlayer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameObject.FindObjectOfType<GameManager>().gameStarted) return;
        transform.position = (upperHandle.HandlePosition(transform.position));
        transform.eulerAngles = new Vector3(0, upperHandle.GetRotation(), 0);
    }

    public async Task ActivatePlayer()
    {
        await upperHandle.SwitchTo(gameObject, 20f);
        upperHandle.Free();
    }
}
