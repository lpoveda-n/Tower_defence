using UnityEngine;
using System.Collections;

public class Redirect_kayou : MonoBehaviour
{
    public bool final_waypoint;
    public GameObject next_waypoint;
    IEnumerator redirect(Collider2D collider)
    {
        yield return new WaitForSeconds(0.75f);
        if (collider!=null && collider.CompareTag("Kayou"))
        {
            if (final_waypoint)
            {
                Destroy(collider.gameObject);
            } else
            {
                collider.GetComponent<Kayou>().waypoint=next_waypoint;   
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(redirect(collider));
    }
}
