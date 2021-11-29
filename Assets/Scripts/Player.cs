using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 worldPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        worldPosition.y = 0;
        transform.position = worldPosition;
    }
    
}
