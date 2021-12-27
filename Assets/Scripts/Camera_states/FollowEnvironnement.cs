using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnvironnement : MonoBehaviour
{

    public GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }


     private void LateUpdate()
    {
        transform.position = player.transform.position;
    }
}
