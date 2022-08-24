using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] private GameObject collectableItem;
    [SerializeField] private Transform firePoint;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GameObject item = Instantiate(collectableItem, firePoint.position, Quaternion.identity);
            // item.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 4, ForceMode2D.Impulse);
            Destroy(gameObject);
        }
    }



}
