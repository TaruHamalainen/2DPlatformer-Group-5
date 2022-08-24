using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // [SerializeField] private float speed;
    // private Rigidbody2D rb;
    // private GameObject player;
    // private int direction;




    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
    }
}
