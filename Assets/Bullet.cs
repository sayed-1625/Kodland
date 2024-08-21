using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 3;
    Vector3 direction;

    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }

    void FixedUpdate()
    {
        // Mover la bala
        transform.position += direction * speed * Time.deltaTime;
        speed += 1f;

        // Detectar colisiones con enemigos
        Collider[] targets = Physics.OverlapSphere(transform.position, 1f);
        foreach (var item in targets)
        {
            if (item.CompareTag("Enemy")) // Verifica si el objeto tiene el tag "Enemy"
            {
                Debug.Log("Enemy hit: " + item.name);
                Destroy(item.gameObject); // Destruye el alien
                Destroy(gameObject); // Destruye la bala también
                break; // Termina el loop después de destruir el enemigo y la bala
            }
        }
    }

    // Alternativamente, usando OnTriggerEnter si prefieres
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit: " + other.name);
            Destroy(other.gameObject); // Destruye el enemigo
            Destroy(gameObject); // Destruye la bala
        }
    }
}
