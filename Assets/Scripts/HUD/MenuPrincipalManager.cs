using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{

    public GameObject optionsWindow, difficultyWindow;

    private void Awake()
    {
        PlayerPrefs.SetInt("max_rand_obstacle", 8);
        PlayerPrefs.SetInt("max_rand_fuel", 8);
    }

    public void FuelButton() 
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("LevelOption", 0);
        PlayerPrefs.SetInt("Environnement", 1);
        Time.timeScale = 1f;
    }

    public void ChronoButton()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("LevelOption", 1);
        PlayerPrefs.SetInt("Environnement", 0);
        Time.timeScale = 1f;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void HowToPlayButton()
    {
        optionsWindow.SetActive(true);
    }

    public void QuitOptionsButton()
    {
        optionsWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitDifficultyButton()
    {
        difficultyWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    public void DifficultyButton()
    {
        difficultyWindow.SetActive(true);
    }

    public void EasyButton()
    {
        PlayerPrefs.SetInt("max_rand_obstacle", 6);        
        PlayerPrefs.SetInt("max_rand_fuel", 8);
        difficultyWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MediumButton()
    {
        PlayerPrefs.SetInt("max_rand_obstacle", 6);
        PlayerPrefs.SetInt("max_rand_fuel", 9);
        difficultyWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    public void HardButton()
    {
        PlayerPrefs.SetInt("max_rand_obstacle", 5);
        PlayerPrefs.SetInt("max_rand_fuel", 10);
        difficultyWindow.SetActive(false);
        Time.timeScale = 1f;
    }
}
