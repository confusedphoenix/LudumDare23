using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimate : MonoBehaviour
{
    private int randomMove;
    private float randomY;
    public float multiplier;

    void Start()
    {
        randomMove = Random.Range(0, 1);
        randomY = Random.Range(-0.5f, 0.5f);
        multiplier = Random.Range(3, 8);
    }

    void Update()
    {
        if (randomMove == 0)
        {
            transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.time * multiplier) + randomY), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, (Mathf.Cos(Time.time * multiplier) + randomY), transform.position.z);
        }
    }
}
