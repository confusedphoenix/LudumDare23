using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyTunnel : MonoBehaviour
{
    public ObstacleSpawn spawn;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tunnel")
        {
            Destroy(other.gameObject);
            spawn.tunnelIsDestroyed = true;
        }
    }
}
