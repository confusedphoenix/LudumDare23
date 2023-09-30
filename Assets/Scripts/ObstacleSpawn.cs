using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject[] tunnels;
    public bool tunnelIsDestroyed;
    public int randomTunnel;
    public Vector3 spawnLoc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tunnelIsDestroyed)
        {
            randomTunnel = Random.Range (0, tunnels.Length);
            Instantiate(tunnels[randomTunnel], spawnLoc, Quaternion.identity);
            tunnelIsDestroyed = false;
        }
    }
}
