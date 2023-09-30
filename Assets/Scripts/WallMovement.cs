using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float wallSpeed;
    public WinLoseState gameState;


    void Start()
    {
        gameState = Object.FindObjectOfType<WinLoseState>();
    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * wallSpeed * Time.deltaTime);
    }
}
