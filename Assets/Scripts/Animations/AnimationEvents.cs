using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void Jump()
    {
        PlayerController.instance.PlayerJump = false;
    }

    public void ChangingLane()
    {
        PlayerController.instance.LaneChanged = false;
    }
}
