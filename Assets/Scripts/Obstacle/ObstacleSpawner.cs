using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private GameObject[] obstacles;
    private float MinDelay = 15f, MaxDelay = 30f;
    private Vector3 Distance;   

    void Start()
    {
        GetObstacles();
        StartCoroutine("SpawnObstacles");
    }

    void GetObstacles()
    {
        obstacles = new GameObject[gameObject.transform.childCount];
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i] = gameObject.GetComponentsInChildren<ObstacleHolder>(true)[i].gameObject;
        }
    }

    IEnumerator SpawnObstacles()
    {
        float timer = Random.Range(MinDelay, MaxDelay)/12f;
        yield return new WaitForSeconds(timer);
        CreateObstacle();
        StartCoroutine("SpawnObstacles");
    }

    void CreateObstacle()
    {
        int rand = Random.Range(0, obstacles.Length);
        if (!obstacles[rand].activeInHierarchy)
        {
            obstacles[rand].SetActive(true);
        }              
    }
}
