using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Camera cam_1st;
    public Camera cam_3rd;


    private Vector3 offset_1st = new Vector3(0, 3.5f, 0.5f);
    private Vector3 offset_3rd= new Vector3(0, 6f, -5f);

    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.3f;


    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");

        cam_1st.enabled = false;
        cam_3rd.enabled = true;

    }
    void Update()
    {
        SwapCamera();
    }
    
    private void LateUpdate()
    {
        cam_1st.transform.position = player.transform.position + offset_1st;
        cam_3rd.transform.position = Vector3.SmoothDamp(cam_3rd.transform.position, player.transform.position + offset_3rd, ref velocity, smoothTime);
    }

    private void SwapCamera()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cam_1st.enabled = !cam_1st.enabled;
            cam_3rd.enabled = !cam_3rd.enabled;
        }
    }
}
