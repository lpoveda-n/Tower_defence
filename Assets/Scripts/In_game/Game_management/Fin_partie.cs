using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fin_partie : MonoBehaviour
{
    public string current_level_name;
    public void retry()
    {
        PlayerPrefs.SetInt("Reset", 1);
        Time.timeScale=1f;
        SceneManager.LoadScene(current_level_name);
    }
    public void Level_selector()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("Level_selector");
    }
    public void main_menu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("Main_menu");
    }
}
