using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;

    [SerializeField] private AudioSource _audio;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            _audio.Play();

        }
    }

    private void Shoot()
    {

        // GameObject playerBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        // playerBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.right * 20f * transform.localScale.x, ForceMode2D.Impulse);
        GameObject bullet = BulletPool.bulletPool.GetBulletsFromPool();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.transform.localScale = transform.localScale;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.right * transform.localScale.x * 25, ForceMode2D.Impulse);
        }

    }
}
