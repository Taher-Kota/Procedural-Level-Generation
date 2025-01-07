using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    public float MoveSpeed , Distance_Factor = 1f;
    private float distance_Move;
    private bool GameJustStarted;

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        GameJustStarted = true;
        InvokeRepeating("UpdateDistance", 1f, 1f);
    }

    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        if (GameJustStarted)
        {
            if(MoveSpeed < 12f)
            {
                MoveSpeed += Time.deltaTime * 5f;
            }
            else
            {
                MoveSpeed = 12f;
                GameJustStarted = false;
            }
        }

        Camera.main.transform.position += new Vector3(MoveSpeed * Time.deltaTime,0f,0f);
        
    }

    void UpdateDistance()
    {
        distance_Move++;
        if(distance_Move >= 30f && distance_Move <= 60f)
        {
            MoveSpeed = 14f;
        }
        else if(distance_Move >= 60f)
        {
            MoveSpeed = 16f;
        }
    }
}
