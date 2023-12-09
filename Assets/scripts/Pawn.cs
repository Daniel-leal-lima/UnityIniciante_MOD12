using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] float life;
    [SerializeField] ParticleSystem damageEffect;
    public void SufferDamage(float damage)
    {
        life -= damage;
        damageEffect.Play();
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
