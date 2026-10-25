using System;
using UnityEngine;
using UnityEngine.UI;

public class Game_manager : MonoBehaviour
{
    public bool endless;
    public float duree;
    public Text time_survived;
    public GameObject[] bat_principal;
    public string[] loots;
    public string[] optional_loots;
    public int[] loots_int;
    public int[] optional_loots_int;
    public GameObject optional_UI;
    public int optional_min_gold;
    public int optional_min_HP;
    public int optional_min_nb_turret;
    public int nb_turret;
    public int nb_enemis_alive=0;
    public bool last_wave_spawn=false;
    public bool game_over=false;
    public bool win=false;
    public GameObject win_menu;
    public GameObject lose_menu;
    public int level_to_unlock;
    public static Game_manager Instance;
    public GameObject GUI;
    void Awake()
    {
        GUI.SetActive(true);
        if (Instance == null)
        {
            Instance=this;
        } else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            win_fct();
        }
        if (Input.GetKey(KeyCode.O))
        {
            game_over_fct();
        }
        if(Input.GetKeyDown(KeyCode.P) && Input.GetKey(KeyCode.N))
        {
            Sound_manager.Instance.troll = !Sound_manager.Instance.troll;
        }
        if (Player_stats.Instance.game_started)
        {
            duree+=Time.deltaTime;     
        }
        if(game_over || win)
        {
            return;
        }
        if(last_wave_spawn && nb_enemis_alive <= 5)
        {
            win_fct();
        }
    }
    public void game_over_fct()
    {
        game_over=true;
        if (endless)
        {
            time_survived.text="Game Over\nTime survived : "+(int)duree+"s";
        }
        lose_menu.SetActive(true);
    }
    public void win_fct()
    {
        win=true;
        win_menu.SetActive(true);
        int max_level_rached=PlayerPrefs.GetInt("level_reached",0);
        PlayerPrefs.SetInt("level_reached",Math.Max(max_level_rached,level_to_unlock));
        int i=0;
        foreach(string loot in loots)
        {
            if(loot=="Nb_max_stratagem" || loot == "Nb_max_stratagem")
            {
                PlayerPrefs.SetInt(loot,Math.Max(loots_int[i],PlayerPrefs.GetInt(loot)));
            } else
            {
                PlayerPrefs.SetInt(loot,1);   
            }
            i++;
        }
        i=0;
        if (Player_stats.lives>=optional_min_HP && Player_stats.money>=optional_min_gold && nb_turret>=optional_min_nb_turret)
        {
            optional_UI.SetActive(true);
            foreach(string loot in optional_loots)
            {
                if(loot=="Nb_max_stratagem" || loot == "Nb_max_turret")
                {
                    PlayerPrefs.SetInt(loot,Math.Max(optional_loots_int[i],PlayerPrefs.GetInt(loot)));
                } else
                {
                    PlayerPrefs.SetInt(loot,1);
                }
                i++;
            }
        }
    }
}
