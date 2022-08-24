
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject bullet;
    private float shootingTimeCounter;
    private float distance;
    [SerializeField] Transform firePoint;
    [SerializeField] float maxShootingTime;
    [SerializeField] float minAttackRange;
    private int direction;
    public int damageAmount;
    [SerializeField] private float health;



    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // if (transform.position.x < target.transform.position.x)
        // {
        direction = 1;
        transform.localScale = new Vector3(1, 1, 1);
        // }
        // else

        // direction = -1;
        // transform.localScale = new Vector3(-1, 1, 1);

        distance = Vector3.Distance(transform.position, target.transform.position);

        if (shootingTimeCounter > maxShootingTime && distance < minAttackRange)
        {
            shootingTimeCounter = 0;
            maxShootingTime = Random.Range(3, 5);
            Shoot();
        }
        else
        {
            shootingTimeCounter += Time.deltaTime;
        }

    }
    private void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, firePoint.position, firePoint.rotation);
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(-transform.right * direction * 10, ForceMode2D.Impulse);
        bulletInstance.transform.localScale = Vector3.one;

        Destroy(bulletInstance, 4);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            health -= 10;
            if (health <= 0)
            {
                AudioManager.audioManager.PlaySound(AudioManager.audioManager.shootingEnemy);
                Destroy(gameObject);
            }
        }
    }
}
