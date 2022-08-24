using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPool;
    [SerializeField] private List<GameObject> bullets;
    private int amountToPool = 40;
    [SerializeField] private GameObject bulletPrefab;


    private void Awake()
    {
        if (bulletPool == null)
        {
            bulletPool = this;
        }
    }
    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
    }
    public GameObject GetBulletsFromPool()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }
        return null;
    }
}
