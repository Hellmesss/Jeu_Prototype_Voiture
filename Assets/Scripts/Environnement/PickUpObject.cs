using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    private GameObject fuelManager;

    private void Start()
    {
        fuelManager =  GameObject.Find("FuelBar");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {

            fuelManager.GetComponent<PlayerFuel>().AddFuel(10);
            Destroy(gameObject);

        }
    }
}


