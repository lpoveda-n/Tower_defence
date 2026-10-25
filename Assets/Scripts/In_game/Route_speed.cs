using UnityEngine;

public class Route_speed : MonoBehaviour
{
    public bool speed;
    public float duration;
    public float intencity;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        if (speed)
        {
            spriteRenderer.color=new Color32(60,155,70,75);
        }
    }
    void Update()
    {
        if (!speed)
        {
            return;
        }
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,1.5f);
        foreach(Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                collider.GetComponent<Enemy_move>().Slow(-intencity,duration);
            }
        }
    }
}
