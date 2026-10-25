using UnityEngine;

public class Summoner : MonoBehaviour
{
    public float spawn_cooldown;
    public float current_spawn_cooldown;
    public GameObject enemy_prefab;
    public Enemy_move enemy_Move;
    void Update()
    {
        current_spawn_cooldown-=Time.deltaTime;
        if (current_spawn_cooldown <= 0)
        {
            current_spawn_cooldown=0;
        }
        if(current_spawn_cooldown <= 0f)
        {
            spawn();
            current_spawn_cooldown=spawn_cooldown;
        }
    }
    void spawn()
    {
        Game_manager.Instance.nb_enemis_alive++;
        GameObject new_mob=Instantiate(enemy_prefab,transform.position,transform.rotation);
        new_mob.GetComponent<Enemy_move>().next_waypoint=enemy_Move.next_waypoint;
    }
}
