using UnityEngine;
using Pathfinding;


public class Supply_cat_AI : MonoBehaviour
{
    public bool cat_bank;
    public bool supply_repair;
    public bool supply_ammunition;
    public int supply_amount;
    public Transform target;
    public float speed = 120f;
    public float nextWpDistance = 1f;
    public Path path;
    int currWp = 0;
    public Seeker seeker;    public Rigidbody2D rb;

    void Start()
    {
        Sound_manager.Instance.play_sound(transform.position,"Cat_spawn");
        // Met à jour le chemin toutes les 0,5 secondes pour suivre la position du joueur
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    // Méthode appelée lorsque le Seeker a terminé de calculer un chemin
    void OnPathComplete(Path p)
    {
        // Si le calcul a réussi (pas d'erreur), met à jour le chemin et réinitialise l'indice du waypoint
        if (!p.error)
        {
            path = p;
            currWp = 0;
        }
    }

    // Méthode appelée à chaque frame fixe pour gérer les mouvements physiques
    void FixedUpdate()
    {
        // Si aucun chemin n'a été calculé ou si tous les waypoints ont été atteints, ne fait rien
        if (path == null || currWp >= path.vectorPath.Count)
        {
            return;
        }
        // Calcule la distance a la cible
        float Distance_target = Vector2.Distance(target.transform.position, transform.position);
        if (Distance_target >= 3.5f)
        {
            // Calcule la direction vers le prochain waypoint
            Vector2 direction = ((Vector2)path.vectorPath[currWp] - rb.position).normalized;
            // Calcule la vitesse en fonction de la direction et de la vitesse spécifiée
            Vector2 velocity = direction * speed * Time.fixedDeltaTime;
            // Applique la vitesse calculée au Rigidbody2D
            rb.linearVelocity = velocity;
            // Calcule la distance du waypoint actuel
            float distance = Vector2.Distance(rb.position, path.vectorPath[currWp]);
            // Si on est suffisamment proche du waypoint, passe au suivant
            if (distance < nextWpDistance)
            {
                currWp++;
            }
        } else
        {
            if (supply_repair)
            {
                target.gameObject.GetComponent<Invade>().restore_turret();
            }
            if (supply_ammunition)
            {
                target.gameObject.GetComponent<Turret>().restore_ammunition();
            }
            if (cat_bank)
            {
                Player_stats.Instance.change_supply(supply_amount);
            }
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Sound_manager.Instance.play_sound(transform.position,"Cat_die");
            Destroy(gameObject);
        }
    }
}

