using System.Collections;
using UnityEngine;

public class HurtObject : MonoBehaviour
{

    private GameObject fuelManager;
    private bool isCollisionned = true;

    private void Start()
    {
        fuelManager = GameObject.Find("FuelBar");
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
        fuelManager.GetComponent<PlayerFuel>().SubstractFuel(100);
        yield return new WaitForSecondsRealtime(2.0f);
        isCollisionned = true;
    }
}


