using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private GameObject cars;

    
    private void Start()
    {
        //deathManager = GameObject.Find("DeathManager");
        cars = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDead();
    }

    public void  Dead()
    {
       SceneManager.LoadScene(2);
    }

    private void CheckIfDead()
    {
        if (cars.transform.position.y < -10)
        {
            Dead();
        }
    }
}
