using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFly : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float attackDistance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float health;
    public float damageAmount;


    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

    }


    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        bool playerIsCloseEnough = distance <= attackDistance;

        if (playerIsCloseEnough)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Random.Range(moveSpeed, maxMoveSpeed) * Time.deltaTime);

        }
        if (transform.position.x < player.transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = Vector3.one;
    }
    public void Die()
    {
        AudioManager.audioManager.PlaySound(AudioManager.audioManager.fireFlyDie);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            health -= 10;
            if (health <= 0)
            {
                Die();
            }
        }
    }
}
