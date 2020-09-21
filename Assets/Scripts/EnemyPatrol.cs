using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;                                 // Vitesse de l'élement ici l'enemy
    public Transform[] waypoints;                       // une array qui contiendra les waypoints.

    public int damageOnCollision = 20;

    public SpriteRenderer graphics;
    private Transform target;                           // La cible vers laquelle l'ennemi va se déplacer, cible dynamique
    private int destPoint = 0;                              // Le point de destination.

    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;                                 // Direction vers lequel l'ennemi va se déplacer. On prend la position de la cible 
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);           // Translate -> méthode de déplacement d'un GameObject forme la plus basique (car on utilise pas de rigidBody)
                                                                                            // normalized méthode de normalisation d'un vecteur (mettre la magnitude à 1)*
        // Si l'ennemi est quasiment arrivé à sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision) // Detection du box collider 2d du player avec l'ennemi
    {
        if(collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
