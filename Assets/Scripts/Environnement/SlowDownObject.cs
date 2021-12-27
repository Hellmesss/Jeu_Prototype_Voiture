using System.Collections;
using UnityEngine;

public class SlowDownObject : MonoBehaviour
{

    private GameObject car;
    private bool isCollisionned = true;

    private void Start()
    {
        car = GameObject.FindGameObjectWithTag("player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player") && isCollisionned)
        {
            isCollisionned = false;
            StartCoroutine(EnterCollision());
        }
    }

    IEnumerator EnterCollision()
    {
        PlayerController.Instance.maxSpeed -= 2f;
        yield return new WaitForSecondsRealtime(2.0f);
        isCollisionned = true;
    }

}


