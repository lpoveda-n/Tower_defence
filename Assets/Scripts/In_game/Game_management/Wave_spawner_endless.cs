using UnityEngine;
using System.Collections;

public class Wave_spawner_endless : MonoBehaviour
{
    public int chill_wave;
    private int intencity=2500;
    private int[] cost={10,50,15,50,30,100,750,15,150};
    public GameObject[] ennemis;
    private Mini_wave[] mini_waves;//0 normal 1 chonk 2 infesteur 3 summoner 4 tunelier 5 transeporteurs 6 gigachonk 7 fantomes 8 sheildeur
    public GameObject waypoint;
    private Game_manager game_Manager;
    void spawn_enemy(GameObject enemy)
    {
        game_Manager.nb_enemis_alive++;
        GameObject new_mob=Instantiate(enemy,transform.position,transform.rotation);
        new_mob.GetComponent<Enemy_move>().next_waypoint=waypoint;
    }
    IEnumerator spawn_mini_wave(Mini_wave mini_wave,GameObject enemy)
    {
        yield return new WaitForSeconds(mini_wave.time_before_start_wave);
        for(int j = 0 ; j < mini_wave.count ; j++)
        {
            spawn_enemy(enemy);
            yield return new WaitForSeconds(mini_wave.time_between_spawn);
        }
        yield return new WaitForSeconds(mini_wave.time_after_wave);
    }
    IEnumerator spawn_wave()
    {
        int intencity_this_wave;
        while (true)
        {
            if (chill_wave < 3)
            {
                chill_wave++;
                intencity_this_wave=intencity/4;
                mini_waves=new Mini_wave[3];
                for (int i = 0; i < 3; i++)
                {
                    mini_waves[i] = new Mini_wave();
                }
                int[] count=new int[3];
                for(int i=0 ; i<3 ; i++)
                {
                    count[i]=0;
                }
                while (intencity_this_wave > 0)
                {
                    int chosen=Random.Range(0, 3);
                    intencity_this_wave-=cost[chosen];
                    if (intencity_this_wave >= 0)
                    {
                        count[chosen]++;
                    }
                }
                
                for(int i=0 ; i<3 ; i++)
                {
                    Debug.Log(count[i]);
                    mini_waves[i].count=count[i];
                    mini_waves[i].time_between_spawn=count[i]!=0 ? 60f/count[i] : 0;
                    mini_waves[i].time_after_wave=0;
                    mini_waves[i].time_before_start_wave=count[i]!=0 ? 0 : 60;
                    StartCoroutine(spawn_mini_wave(mini_waves[i],ennemis[i]));
                }
            } else
            {
                chill_wave=0;
                intencity_this_wave=intencity;
                mini_waves=new Mini_wave[9];
                for (int i = 0; i < 9; i++)
                {
                    mini_waves[i] = new Mini_wave();
                }
                int[] count=new int[9];
                for(int i=0 ; i<9 ; i++)
                {
                    count[i]=0;
                }
                int strategy=Random.Range(0, 3);
                if (strategy == 0)
                {
                    intencity_this_wave-=cost[6];
                    count[6]++;
                    mini_waves[6].count=count[6];
                    mini_waves[6].time_between_spawn=0;
                    mini_waves[6].time_after_wave=60;
                    mini_waves[6].time_before_start_wave=0;
                    mini_waves[7].count=0;
                    mini_waves[7].time_between_spawn=0;
                    mini_waves[7].time_after_wave=0;
                    mini_waves[7].time_before_start_wave=60;
                    mini_waves[8].count=0;
                    mini_waves[8].time_between_spawn=0;
                    mini_waves[8].time_after_wave=0;
                    mini_waves[8].time_before_start_wave=60;
                }
                if (strategy == 1)
                {
                    intencity_this_wave-=cost[7]*10;
                    count[7]+=10;
                    mini_waves[6].count=0;
                    mini_waves[6].time_between_spawn=0;
                    mini_waves[6].time_after_wave=0;
                    mini_waves[6].time_before_start_wave=60;
                    mini_waves[7].count=count[7];
                    mini_waves[7].time_between_spawn=1;
                    mini_waves[7].time_after_wave=50;
                    mini_waves[7].time_before_start_wave=0;
                    mini_waves[8].count=0;
                    mini_waves[8].time_between_spawn=0;
                    mini_waves[8].time_after_wave=0;
                    mini_waves[8].time_before_start_wave=60;
                }
                if (strategy == 2)
                {
                    intencity_this_wave-=cost[8];
                    count[8]++;
                    mini_waves[6].count=0;
                    mini_waves[6].time_between_spawn=0;
                    mini_waves[6].time_after_wave=0;
                    mini_waves[6].time_before_start_wave=60;
                    mini_waves[7].count=0;
                    mini_waves[7].time_between_spawn=0;
                    mini_waves[7].time_after_wave=0;
                    mini_waves[7].time_before_start_wave=60;
                    mini_waves[8].count=count[8];
                    mini_waves[8].time_between_spawn=0;
                    mini_waves[8].time_after_wave=55;
                    mini_waves[8].time_before_start_wave=5;
                }
                while (intencity_this_wave > 0)
                {
                    int chosen=0;
                    int random=Random.Range(0, 101);
                    if (random>25 && random <= 40)
                    {
                        chosen=1;
                    }
                    if (random>40 && random <= 63)
                    {
                        chosen=2;
                    }
                    if (random>63 && random <= 78)
                    {
                        chosen=3;
                    }
                    if (random>78 && random <= 98)
                    {
                        chosen=4;
                    }
                    if (random>98 && random <= 100)
                    {
                        chosen=5;
                    }
                    intencity_this_wave-=cost[chosen];
                    if (intencity_this_wave >= 0)
                    {
                        count[chosen]++;
                    }
                }
                for(int i=0 ; i<6 ; i++)
                {
                    if (strategy == 1 || i==5)
                    {
                        Debug.Log("i == 5");
                        mini_waves[i].count=count[i];
                        mini_waves[i].time_between_spawn=count[i]!=0 ? 50f/count[i] : 0;
                        mini_waves[i].time_after_wave=0;
                        mini_waves[i].time_before_start_wave=count[i]!=0 ? 10 : 50;
                    } else
                    {
                        Debug.Log("i != 5");  
                        mini_waves[i].count=count[i];
                        mini_waves[i].time_between_spawn=count[i]!=0 ? 60f/count[i] : 0;
                        mini_waves[i].time_after_wave=0;
                        mini_waves[i].time_before_start_wave=count[i]!=0 ? 0 : 60;
                    }
                    Debug.Log("i "+i);
                    Debug.Log("count "+mini_waves[i].count);
                    Debug.Log("time_after_wave "+mini_waves[i].time_after_wave);
                    Debug.Log("time_before_start_wave "+mini_waves[i].time_before_start_wave);
                    Debug.Log("time_between_spawn "+mini_waves[i].time_between_spawn);
                    StartCoroutine(spawn_mini_wave(mini_waves[i],ennemis[i]));
                }
                for(int i=6 ; i<9 ; i++)
                {
                    Debug.Log(count[i]);
                    StartCoroutine(spawn_mini_wave(mini_waves[i],ennemis[i]));
                }
            }
            yield return new WaitForSeconds(60f);
            intencity+=500;
        }
    }
    public void start_waves()
    {
        game_Manager=Game_manager.Instance;
        StartCoroutine(spawn_wave());
    }
}
