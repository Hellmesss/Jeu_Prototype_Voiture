using UnityEngine;

public class CreateDynamicRoad : MonoBehaviour
{
    public GameObject cars, prefabRoad,prefabRoad_2, prefabObject, prefabFuel, prefabSpool, empty, environement;
    private int max_rand_fuel;
    private int max_rand_obstacle;

    private float render;
    private float nb_road=20;
    private float roadSize_x;


    private float rand_pos_x;
    private float pos_z;

    private GameObject car;

    private static CreateDynamicRoad instance;
    public static CreateDynamicRoad Instance { get { return instance; } }


    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);

        }
        instance = this;

        //recup longueur route
        roadSize_x = prefabRoad.GetComponent<Renderer>().bounds.size.x;
        render = roadSize_x / 0.04f;
        Init();

    }

    private void Start()
    {
        max_rand_obstacle = PlayerPrefs.GetInt("max_rand_obstacle");
        max_rand_fuel = PlayerPrefs.GetInt("max_rand_fuel");
    }

    void Update()
    {
        GenerateRoad();
    }

    private void Init() //create static road
    {
        GameObject e;
        car =Instantiate(cars, new Vector3(0, 0, roadSize_x), Quaternion.identity);
        e = Instantiate(environement, new Vector3(0, 0, roadSize_x), Quaternion.identity);
        e.GetComponent<FollowEnvironnement>().player = car;

       for (int i = 0; i < nb_road; i++)
       {                                                          
           Instantiate(prefabRoad, new Vector3(0, 0, i * roadSize_x), Quaternion.Euler(0f, 90f, 0f));
       }
        empty.transform.position = new Vector3(0, 0, empty.transform.position.z + roadSize_x);

    }

    public void GenerateRoad() //create dynamc road
    {

        if (empty.transform.position.z - car.transform.position.z < render)
        {
            int rand_nb_for_road = Random.Range(0, 6);

            if (rand_nb_for_road == 0)
            {
                GameObject Road2 = GameObject.Instantiate(prefabRoad_2, new Vector3(0, 0, empty.transform.position.z), Quaternion.Euler(0, 90, 0));
            }
            else
            {
                GameObject Road1 = GameObject.Instantiate(prefabRoad, new Vector3(0, 0, empty.transform.position.z), Quaternion.Euler(0, 90, 0));

            }

            int rand_nb_object = Random.Range(0, max_rand_obstacle);

            if (PlayerPrefs.GetInt("Environnement") == 1)
            {
                //generation crate
                if (rand_nb_object == 0)
                {
                    rand_pos_x = Random.Range(-roadSize_x - 2f, roadSize_x + 2f); //dimension de la route - dimension des barrieres
                    pos_z = empty.transform.position.z;

                    GameObject NewCrate = GameObject.Instantiate(prefabObject, new Vector3(rand_pos_x, 0, pos_z), Quaternion.Euler(0, 90, 0));
                }
                int rand_nb_fuel = Random.Range(0, max_rand_fuel);

                //generation jerrycan de fuel
                if (rand_nb_fuel == 0)
                {
                    rand_pos_x = Random.Range(-roadSize_x - 2f, roadSize_x + 2f);
                    pos_z = empty.transform.position.z;

                    GameObject NewFuel = GameObject.Instantiate(prefabFuel, new Vector3(rand_pos_x, 0, pos_z), Quaternion.Euler(0, 90, 0));
                }
            }
            else
            {
                //generation spool
                if (rand_nb_object == 0 || rand_nb_object == 1)
                {
                    rand_pos_x = Random.Range(-roadSize_x - 2f, roadSize_x + 2f); //dimension de la route - dimension des barrieres
                    pos_z = empty.transform.position.z;

                    GameObject NewCrate = GameObject.Instantiate(prefabSpool, new Vector3(rand_pos_x, 0, pos_z), Quaternion.Euler(0, 90, 0));
                }
            }
            empty.transform.position = new Vector3(0, 0, empty.transform.position.z + roadSize_x);
        }
    }
}
