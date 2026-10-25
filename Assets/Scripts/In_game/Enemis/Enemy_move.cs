using System;
using UnityEngine;

public class Enemy_move : MonoBehaviour
{
    public bool bumped=false;
    public bool gigachonk;
    public bool no_redirect;
    public GameObject next_waypoint;
    public bool tunelier;
    private float speed;
    public float base_speed;
    private float slow_remaning_duation;
    public bool foward;
    public Vector2 foward_vect;
    private Vector2 direction;
    private Vector2 move;
    public GameObject healthbar;
    void Start()
    {
        speed=base_speed;
    }
    void Update()
    {
        if (slow_remaning_duation > 0)
        {
            slow_remaning_duation-=Time.deltaTime;
            if (slow_remaning_duation <= 0)
            {
                speed=base_speed;
                slow_remaning_duation=0;
            }
        }
        if (foward && Time.deltaTime>0)
        {
            transform.Translate(move,Space.World);
        } else
        {
            direction = (next_waypoint.transform.position - transform.position).normalized;
            move=direction * speed * Time.deltaTime;
            if (Vector2.Distance(next_waypoint.transform.position, transform.position) < 0.25)
            {
                Vector2 new_dir;
                new_dir.x=1f;
                new_dir.y=1f;
                move=new_dir;
            }
            transform.Translate(move,Space.World);
            float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
            healthbar.transform.rotation = Quaternion.identity;
        }
    }
    public void Slow(float slow_intencity,float slow_duration)
    {
        if (gigachonk)
        {
            slow_intencity=slow_intencity/4;
        }
        slow_remaning_duation=Math.Max(slow_duration,slow_remaning_duation);
        if (slow_intencity > 0)
        {
            speed=Math.Min(speed,base_speed*(1-slow_intencity/100));
        }
        speed=base_speed*(1-slow_intencity/100);
    }
}
