using UnityEngine;

public class AutoDestructWhenUseless : MonoBehaviour
{
    private GameObject cars;
    public float maxDist;

    private void Start()
    {
        cars = GameObject.FindGameObjectWithTag("player");
    }
    void Update()
    {
        DestroyWithmaxDist();
        DestroyIfFall();
    }

    private void DestroyWithmaxDist()
    {
        if ((cars.transform.position.z - transform.position.z) > maxDist)
        {
            Destroy(this.gameObject);
        }
    }

    private void DestroyIfFall()
    {
        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
