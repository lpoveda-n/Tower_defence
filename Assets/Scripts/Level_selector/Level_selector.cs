using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Level_selector : MonoBehaviour
{
    public Button[] levels_buttons;
    private int level_reached;
    public GameObject level_2_trial_button;
    public GameObject level_5_trial_button;
    public GameObject level_7_trial_button;
    public GameObject level_8_trial_button;
    public GameObject endless_mode_button;
    public Turret_selector select_turret;
    public Stratagem_selector select_stratagem;
    public Select_equipement activate_select_equipement;
    void Start()
    {
        level_reached = PlayerPrefs.GetInt("level_reached", 1);
        for(int i = level_reached; i < levels_buttons.Length; i++)
        {
            levels_buttons[i].interactable = false;
        }
        if (PlayerPrefs.GetInt("level_2_trial", 0)==1)
        {
            level_2_trial_button.SetActive(true);
        }
        if (PlayerPrefs.GetInt("level_5_trial", 0)==1)
        {
            level_5_trial_button.SetActive(true);
        }
        if (PlayerPrefs.GetInt("level_7_trial", 0)==1)
        {
            level_7_trial_button.SetActive(true);
        }
        if (PlayerPrefs.GetInt("level_8_trial", 0)==1)
        {
            level_8_trial_button.SetActive(true);
        }
        if (PlayerPrefs.GetInt("endless_mode", 0)==1)
        {
            endless_mode_button.SetActive(true);
        }
    }
    public void select(string name)
    {
        if (name=="Level_tutoriel")
        {
            SceneManager.LoadScene(name);
        } else
        {
            if (select_turret.nb_selected == 0 || select_stratagem.nb_selected==0)
            {
                activate_select_equipement.level_name=name;
                activate_select_equipement.select_equipement();
            } else
            {
                SceneManager.LoadScene(name);
            }   
        }
    }
}