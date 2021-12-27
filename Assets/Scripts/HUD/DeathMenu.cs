using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public Text text;
    private float resapwnCounter = 11.0f;

    private void Update()
    {
        resapwnCounter -= Time.deltaTime;
        text.text = "You are dead, respawn in : " + (int)resapwnCounter + "\n [y / n] ?";
        RespawnTimeout();
        IfYesPressed();
        IfNoPressed();
    }

    private void RespawnTimeout()
    {
        if (resapwnCounter < 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void IfYesPressed()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void IfNoPressed()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(0);
        }
    }


}
