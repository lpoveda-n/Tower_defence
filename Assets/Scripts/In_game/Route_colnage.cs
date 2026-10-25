using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class Route_colnage : MonoBehaviour
{
    public bool colnage;
    public SpriteRenderer spriteRenderer;
    public float cooldown;
    private float current_cooldown=0;
    void Start()
    {
        if (colnage)
        {
            spriteRenderer.color=new Color32(0,255,255,75);
        }
    }
    IEnumerator clone_enemy(GameObject enemy)
    {
        for(int i = 1; i < 26; i++)
        {
            spriteRenderer.color=new Color32(0,255,255,(byte)(75+3*i));
            yield return new WaitForSeconds(0.01f);
        }
        Instantiate(enemy,transform.position,transform.rotation);
        for(int i = 1; i < 26; i++)
        {
            spriteRenderer.color=new Color32(0,255,255,(byte)(150-3*i));
            yield return new WaitForSeconds(0.01f);
        }
    }
    void Update()
    {
        if (!colnage)
        {
            return;
        }
        if (current_cooldown != 0)
        {
            current_cooldown-=Time.deltaTime;
            if (current_cooldown <= 0)
            {
                current_cooldown=0;
            }
        }
        if (current_cooldown == 0)
        {
            bool found=false;
            Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,1.5f);
            foreach(Collider2D collider in colliders)
            {
                if (collider.tag == "Enemy" && !found && !collider.gameObject.GetComponent<Enemy_move>().gigachonk && !collider.gameObject.GetComponent<Enemy_stats>().transeporteur)
                {
                    found=true;
                    current_cooldown=cooldown;  
                    Game_manager.Instance.nb_enemis_alive++;    
                    StartCoroutine(clone_enemy(collider.gameObject));
                }
            }
        }
    }
}
