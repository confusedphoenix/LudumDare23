using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleResult : MonoBehaviour
{
    public WinLoseState gameState;
    public PlayerController player;


    void Start()
    {
        gameState = Object.FindObjectOfType<WinLoseState>();
        player = Object.FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        //if(player.isEnlarged)
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !player.isEnlarged)
        {
            Debug.Log("Lose");
            gameState.hasLost = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && player.isEnlarged)
        {
            Debug.Log("Explode");
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().AddForce(transform.up * 10);
        }
    }
}
