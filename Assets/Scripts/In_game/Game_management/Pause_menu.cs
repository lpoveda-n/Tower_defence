using UnityEngine;

public class Pause_menu : MonoBehaviour
{
    public GameObject ui;
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggle();
        }
    }
    public void toggle()
    {
        ui.SetActive(!ui.activeSelf);
        if (ui.activeSelf)
        {
            Time.timeScale=0f;
        } else
        {
            Time.timeScale=1f;
        }
    }
}
