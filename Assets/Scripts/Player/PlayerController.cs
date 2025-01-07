using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Animator anim;
    public Vector3 PlayerPosFirst, PlayerPosSecond;

    [HideInInspector]
    public bool PlayerDied, PlayerJump , LaneChanged;
    

    private void Awake()
    {
        MakeInstance();
        anim = GetComponentInChildren<Animator>();
    }
    
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        ChangeLane();
        JumpAnim();
    }

    void ChangeLane()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!LaneChanged && transform.localPosition != PlayerPosSecond)
            {
                LaneChanged = true ;
                anim.SetTrigger(MyTags.ChangeLane);
                transform.localPosition = PlayerPosSecond;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!LaneChanged && transform.localPosition != PlayerPosFirst)
            {
                LaneChanged = true;
                anim.SetTrigger(MyTags.ChangeLane);
                transform.localPosition = PlayerPosFirst;
            }
        }
    }

    void JumpAnim()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!PlayerJump)
            {
                PlayerJump = true;
                anim.SetTrigger(MyTags.Jump);
            }            
        }
    }
}
