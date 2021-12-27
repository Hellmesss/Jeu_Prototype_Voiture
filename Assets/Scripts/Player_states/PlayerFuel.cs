using UnityEngine;

public class PlayerFuel : MonoBehaviour
{
    private int maxFuel = 100;
    private int currentFuel;

    public FuelBar fuelBar;
    public PlayerDeath deathManager;



    private GameObject player;
    private float lastPos = 0f;

    private int dist;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");

        currentFuel = maxFuel;
        fuelBar.SetMaxFuel(maxFuel);


        dist = (int)player.transform.position.z-4 ; //4 est la dimension de la voiture en z
    }

    private void Update()
    {
        dist = (int)player.transform.position.z;
        UseFuel(dist);
        CheckedIfEmpty();
    }

    void UseFuel(int dist)
    {
       if (player.transform.position.z - lastPos> 10f) //distance parcourrue 
       {
            currentFuel -= 1;

            lastPos = player.transform.position.z;
       }
        fuelBar.SetFuel(currentFuel);
    }

    public void AddFuel(int fuel)
    {
        if (currentFuel <= 90)
        {
            currentFuel += fuel;
            fuelBar.SetFuel(currentFuel);
        }
    }

    public void SubstractFuel(int fuel)
    {
        currentFuel -= fuel;
        fuelBar.SetFuel(currentFuel);
    }
     public void CheckedIfEmpty()
    {
        if (currentFuel <= 0)
        {
            deathManager.Dead();
        }
    }

}
