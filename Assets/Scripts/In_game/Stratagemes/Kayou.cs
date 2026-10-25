using UnityEngine;

public class Kayou : MonoBehaviour
{
    public float damage;
    public float speed;
    public GameObject waypoint;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            collider.GetComponent<Enemy_stats>().take_damage(damage);
        }
    }
    void Update()
    {
        Vector2 direction=waypoint.transform.position-transform.position;
        direction=direction.normalized;
        Vector2 move=direction*speed*Time.deltaTime;
        transform.Translate(move,Space.World);
    }
}
