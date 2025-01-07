
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleHolder : MonoBehaviour
{
    public Transform LaneUp, LaneDown;

    private void OnEnable()
    {
        transform.position = Random.Range(0, 2) == 0 ? LaneUp.position : LaneDown.position;
        Invoke("deactivate", 5f);
    }
    void Update()
    {
        transform.position -= new Vector3(GamePlayController.instance.MoveSpeed * Time.deltaTime, 0f, 0f);
    }

    void deactivate()
    {
        gameObject.SetActive(false);
    }
}
