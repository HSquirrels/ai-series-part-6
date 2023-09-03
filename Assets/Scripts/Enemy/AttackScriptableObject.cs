using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "AttackConfiguration", menuName = "ScriptableObject/Attack Configuration")]
public class AttackScriptableObject : ScriptableObject
{
    public bool isRanged = false;
    public int damage = 5;
    public float attackRadius = 1.5f;
    public float attackDelay = 1.5f;

    //Ranged Configs
    public Bullet bulletPrefab;
    public Vector3 bulletSpawnOffset;
    public LayerMask lineOfSightLayers;

    public void SetupEnemy(Enemy enemy)
    {
        (enemy.AttackRadius.Collider == null ? enemy.AttackRadius.GetComponent<SphereCollider>() : enemy.AttackRadius.Collider).radius = attackRadius;
        enemy.AttackRadius.Collider.radius = attackRadius;
        enemy.AttackRadius.Damage = damage;

        if (isRanged)
        {
            RangedAttackRadius rangedAttackRadius = enemy.AttackRadius.GetComponent<RangedAttackRadius>();

            rangedAttackRadius.BulletPrefab = bulletPrefab;
            rangedAttackRadius.BulletSpawnOffset = bulletSpawnOffset;
            rangedAttackRadius.Mask = lineOfSightLayers;

            rangedAttackRadius.CreateBulletPool();
        }
    }
}
