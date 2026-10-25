using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Wave_spawner : MonoBehaviour
{
    public Wave[] waves;
    public GameObject waypoint;
    private Game_manager game_Manager;
    void spawn_enemy(GameObject enemy)
    {
        game_Manager.nb_enemis_alive++;
        GameObject new_mob=Instantiate(enemy,transform.position,transform.rotation);
        new_mob.GetComponent<Enemy_move>().next_waypoint=waypoint;
    }
    IEnumerator spawn_wave(Wave wave)
    {
        for(int i = 0; i < wave.mini_waves.Length; i++)
        {
            Mini_wave mini_wave=wave.mini_waves[i];
            yield return new WaitForSeconds(mini_wave.time_before_start_wave);
            for(int j = 0 ; j < mini_wave.count ; j++)
            {
                spawn_enemy(wave.enemy);
                yield return new WaitForSeconds(mini_wave.time_between_spawn);
            }
            yield return new WaitForSeconds(mini_wave.time_after_wave);
        }
        game_Manager.last_wave_spawn=true;
    }
    public void start_waves()
    {
        game_Manager=Game_manager.Instance;
        for(int i = 0 ; i < waves.Length ; i++)
        {
            StartCoroutine(spawn_wave(waves[i]));
        }
    }
}