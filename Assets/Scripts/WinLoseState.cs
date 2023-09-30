using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WinLoseState : MonoBehaviour
{
    public bool hasLost;
    public WallMovement[] tunnels;

    void Start()
    {

    }


    void Update()
    {
        tunnels = Object.FindObjectsOfType<WallMovement>();

        if (hasLost)
        {
            //tunnels[tunnels.Length - 1].wallSpeed = 0f;

            foreach (WallMovement tunnel in tunnels)
            {
                tunnel.wallSpeed = 0f;
            }

        }
    }
}
