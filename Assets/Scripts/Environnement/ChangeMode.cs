using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour
{
    public GameObject timer, fuelBar, fuelObj;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("LevelOption") == 1)
        {
            timer.SetActive(true);
            fuelBar.SetActive(false);
        }
        else
        {
            timer.SetActive(false);
            fuelBar.SetActive(true);
            Destroy(gameObject);
        }
    }
}
