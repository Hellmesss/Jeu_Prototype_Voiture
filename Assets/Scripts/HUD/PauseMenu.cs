using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] GameObject pauseMenu;

    void Update()
    {
        ActivePauseMenu();
    }

    private void ActivePauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) //activer le menu lorsqu'on joue
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void ResumeGame() //button pour reprendre la partie en cours
    {
        pauseMenu.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1f;
    }
    private void PauseGame() //fonction qui active notre menu et arrete le temps
    {
        pauseMenu.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0f;
    }
    public void LoadMenu() //button qui nous envoie sur le menu principal
    {
        SceneManager.LoadScene(0);
        isGamePaused = false;
        Time.timeScale = 1f;
    }
    public void RestartButton() //button qui relance la partie en cours
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGamePaused = false;
        Time.timeScale = 1f;
    }
}

