using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{

    public Transform groundCheck;
    private bool movingRight = true;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float health;
    public float damageAmount;




    private void Update()
    {

        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 1);


        if (groundInfo.collider == false)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;

            }
        }


    }
    public void Die()
    {
        AudioManager.audioManager.PlaySound(AudioManager.audioManager.spiderDie);
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
