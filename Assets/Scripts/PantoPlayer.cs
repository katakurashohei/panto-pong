using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualPantoFramework;
using System.Threading.Tasks;

public class PantoPlayer : MonoBehaviour
{
    PantoHandle meHandle;
    void Start()
    {
        meHandle = GameObject.Find("Panto").GetComponent<UpperHandle>();
    }

    void FixedUpdate()
    {
        if (!GameObject.FindObjectOfType<GameManager>().gameStarted) return;
        transform.position = meHandle.HandlePosition(transform.position);
        transform.eulerAngles = new Vector3(0, meHandle.GetRotation(), 0);
        Debug.Log(meHandle.GetRotation());
    }

    public async Task ActivatePlayer()
    {
        await meHandle.SwitchTo(gameObject, 20f);
        meHandle.Free();
    }
}
