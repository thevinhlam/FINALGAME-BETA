using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] float attackCoolDown;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject[] fireBullet1;
    float coolDownTimer;
    private void Update()
    {
        coolDownTimer += Time.deltaTime;
        if (coolDownTimer >= attackCoolDown)
            Attack();
    }
    void Attack()
    {
        coolDownTimer = 0;
        fireBullet1[FindFireBullet1()].transform.position = firePoint.position;
        fireBullet1[FindFireBullet1()].GetComponent<FireBullet1>().ActivateProjectile();
    }
    int FindFireBullet1()
    {
        for (int i = 0; i < fireBullet1.Length; i++)
        {
            if (!fireBullet1[i].activeInHierarchy)
                return i;

        }
        return 0;
    }
}
