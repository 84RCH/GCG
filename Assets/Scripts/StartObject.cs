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
        // 1���Ԃ�60��Ȃ̂ŁA1�b�Ԃ�1�񔭎�
        fireRate = 1f / 60f;

        transform.Translate(0, 0, -1);
    }

    void Update()
    {
        // ���Ԃ�������e�𔭎�
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // ���̔��ˎ��Ԃ�ݒ�
        }
    }

    void Shoot()
    {
        if (target != null)
        {
            // �^�[�Q�b�g�ւ̕������v�Z
            Vector3 direction = (target.position - transform.position).normalized;

            // �e�𐶐�
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.up = direction; // �e�̌�����ݒ�
        }
    }
}
