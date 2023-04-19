using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] List<Weapon> inventoryWeapon;
    Weapon equippedWeapon;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject projectileHitscanPrefab;
    float lastShotTime;
    private void Start()
    {
        equippedWeapon = inventoryWeapon[0];
    }
    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            equippedWeapon = inventoryWeapon[0];
        }
        if (Input.GetKeyDown("2"))
        {
            equippedWeapon = inventoryWeapon[1];
        }
        if (Input.GetKeyDown("3"))
        {
            equippedWeapon = inventoryWeapon[3];
        }

        if (Input.GetKeyDown("space") && lastShotTime + equippedWeapon.fireRate < Time.time)
        {
            lastShotTime = Time.time;
            if (equippedWeapon.projectyleType.Equals(ProjectileType.Travel))
            {
                GameObject prefab = Instantiate(projectilePrefab,transform.position,transform.rotation);
                InitializeProjectile(prefab);
            }
            if (equippedWeapon.projectyleType.Equals(ProjectileType.Hitscan))
            {
                GameObject prefab = Instantiate(projectileHitscanPrefab, transform.position, transform.rotation);
                InitializeProjectile(prefab);
                if (Physics.Raycast(transform.position,transform.forward,out RaycastHit hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                        enemy.SufferDamage(equippedWeapon.damage);
                    }
                }
            }
        }
    }

    private void InitializeProjectile(GameObject prefab)
    {
        Projectile projectile = prefab.GetComponent<Projectile>();
        projectile.speed = equippedWeapon.speed;
        projectile.damage = equippedWeapon.damage;
    }
}