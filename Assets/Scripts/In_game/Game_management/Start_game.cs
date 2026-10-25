using UnityEngine;

public class Start_game : MonoBehaviour
{
    public GameObject node_UI;
    public GameObject shop;
    public GameObject open_shop;
    public GameObject open_stratagems;
    public GameObject start_gamme_button;
    public Wave_spawner[] wave_Spawners;
    public Wave_spawner_endless[] wave_Spawners_endless;
    public bool endless;
    public bool game_started=false;
    public static Start_game Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance=this;
        } else
        {
            Destroy(gameObject);
        }
    }
    public void start_gamme(){
        game_started=true;
        node_UI.SetActive(false);
        shop.SetActive(false);
        open_shop.SetActive(false);
        open_stratagems.SetActive(true);
        start_gamme_button.SetActive(false);
        Build_manager.Instance.deselect_turret();
        Player_stats.Instance.game_started=true;
        if (endless)
        {
            for(int i = 0; i < wave_Spawners_endless.Length; i++)
            {
                wave_Spawners_endless[i].start_waves();
            }
        } else
        {
            for(int i = 0; i < wave_Spawners.Length; i++)
            {
                wave_Spawners[i].start_waves();
            }
        }
    }
}