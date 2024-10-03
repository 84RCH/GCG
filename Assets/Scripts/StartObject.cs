using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObject : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform target; // target to Goal
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    void Start()
    {
        // 1•ªŠÔ‚É60‰ñ‚È‚Ì‚ÅA1•bŠÔ‚É1‰ñ”­Ë
        fireRate = 1f / 60f;

        transform.Translate(0, 0, -1);
    }

    void Update()
    {
        // ŠÔ‚ª—ˆ‚½‚ç’e‚ğ”­Ë
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Ÿ‚Ì”­ËŠÔ‚ğİ’è
        }
    }

    void Shoot()
    {
        if (target != null)
        {
            // ƒ^[ƒQƒbƒg‚Ö‚Ì•ûŒü‚ğŒvZ
            Vector3 direction = (target.position - transform.position).normalized;

            // ’e‚ğ¶¬
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.up = direction; // ’e‚ÌŒü‚«‚ğİ’è
        }
    }
}
