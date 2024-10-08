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
        // 1分間に60回なので、1秒間に1回発射
        fireRate = 1f / 60f;

        transform.Translate(0, 0, -1);
    }

    void Update()
    {
        // 時間が来たら弾を発射
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // 次の発射時間を設定
        }
    }

    void Shoot()
    {
        if (target != null)
        {
            // ターゲットへの方向を計算
            Vector3 direction = (target.position - transform.position).normalized;

            // 弾を生成
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.up = direction; // 弾の向きを設定
        }
    }
}
