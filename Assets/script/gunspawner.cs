using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunspawner : MonoBehaviour
{
    private Vector3 position;
    [SerializeField] private GameObject[] gunsnew;
    private float timeLeft = 0;

    private void Start()
    {
        position.y = -3.5f;
    }
    
    private void Update ()
    {
        if (timeLeft < 0)//beter spawning maken
        {
            spawn();
            timeLeft = 20;
        }
        timeLeft -= Time.deltaTime;
    }
    private void spawn()
    {
        position.x = Random.Range(-11, 11);
        Instantiate(gunsnew[Random.Range(0, gunsnew.Length)], position, transform.rotation);
    }
}
