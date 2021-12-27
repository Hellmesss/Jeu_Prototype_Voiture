using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    bool grounded=true;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private float speed; 


    [Header("AVEC courbe d'animation")]
    public AnimationCurve accelerationSpeed;

    private float timeFromMinToMax = 1.0f;
    private float accel_x = 0;
    private float speed_y;
    private int signAccel;
    private float amplitudeSpeed;
    private float minSpeed = 3f;

    public float maxSpeed = 50f;
    public float currentFuel = 100f;

    public static PlayerController Instance { get { return instance; } }
    public static PlayerController instance;
    // définir un coefficient entre la déclaration (absence d'acceleraion et frein) et le freinage
    private const float RAPPORT_DECELERATION_FREINAGE = 3.0f;


    private float horizontalInput;
    private float forwardInput;
    private float turnspeed = 20f;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    void Start()
    {
        speed = minSpeed;
        amplitudeSpeed = maxSpeed - minSpeed;
    }

    void Update()
    {
        ManagePlayer();
    }

    private void ManagePlayer()
    {
        float delta_x = Time.deltaTime / timeFromMinToMax;


        if (grounded)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            // DECELERATION 
            if (Mathf.Abs(forwardInput) < 0.01f)
            {
                accel_x -= delta_x / (RAPPORT_DECELERATION_FREINAGE + 1f);
            }
            // ACCELERATION ou FREINAGE
            else
            {
                signAccel = Math.Sign(forwardInput);
                accel_x += (delta_x * signAccel);
            }
            if (accel_x < 0.0f) accel_x = 0.0f;
            if (accel_x > 1.0f) accel_x = 1.0f;
            speed_y = accelerationSpeed.Evaluate(accel_x);

            speed = minSpeed + (amplitudeSpeed) * speed_y;

            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.Rotate(0f, Time.deltaTime * turnspeed * horizontalInput, 0f);

            grounded = false;
        }

        grounded = Physics.OverlapBox(groundCheck.transform.position, transform.localScale, Quaternion.identity, groundLayer).Length > 0;
    }

}
