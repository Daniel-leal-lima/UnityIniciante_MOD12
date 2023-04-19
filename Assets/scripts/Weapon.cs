using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon",menuName ="ScriptableObject/Weapon",order =1)]
public class Weapon : ScriptableObject
{
    public ProjectileType projectyleType;
    public float damage;
    public float speed;
    public float fireRate;
    
}
