using UnityEngine;
using System.Collections;

public class Tunel : MonoBehaviour
{
    public bool is_entree;
    public GameObject sortie;
    public GameObject waypoint;
    public int nb_enemis_transeportables;
    private int nb_enemis_restants=5;
    void Start()
    {
        nb_enemis_restants=nb_enemis_transeportables;
    }
    public void fade()
    {
        Destroy(gameObject,0.55f);
    }
    IEnumerator TP(Collider2D collider)
    {
        Enemy_move enemy_Move=collider.GetComponent<Enemy_move>();
        if (enemy_Move.tunelier)
        {
            collider.GetComponent<Create_tunel>().tuneled=true;
        }
        enemy_Move.no_redirect=true;
        yield return new WaitForSeconds(0.5f);
        enemy_Move.no_redirect=false;
        enemy_Move.next_waypoint=waypoint;
        if (collider != null)
        {
            collider.transform.position=sortie.transform.position;   
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (is_entree && collider.CompareTag("Enemy"))
        {
            StartCoroutine(TP(collider));
            nb_enemis_restants--;
            if (nb_enemis_restants <= 0)
            {
                is_entree=false;
                sortie.GetComponent<Tunel>().fade();
                fade();
            }
        }
    }
}
