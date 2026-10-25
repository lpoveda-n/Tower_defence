using UnityEngine;

public class Sheild : MonoBehaviour
{
    public CircleCollider2D circleCollider2D;
    public float range;
    void Start()
    {
        Vector2 scale;
        scale.x=2*range;
        scale.y=2*range;
        gameObject.transform.localScale=scale;
        circleCollider2D.radius=0.5f+0.35f/range;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Balle") && Vector2.Distance(transform.position,collider.transform.position)>range-0.65)
        {
            Balle balle=collider.gameObject.GetComponent<Balle>();
            if (balle.radius > 0)
            {
                balle.explode();
            } else
            {
                Destroy(collider.gameObject);   
            }
        }
    }
}
