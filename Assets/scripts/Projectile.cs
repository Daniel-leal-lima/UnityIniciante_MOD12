using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    [SerializeField] ParticleSystem effect;
    [SerializeField] Collider projectileCollider;
    //private Camera _gameCamera;
    //private void Awake()
    //{
    //    _gameCamera = Camera.main;   
    //}

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    //void Pool()
    //{
    //    float distFromCamera = Vector3.Distance(transform.position, _gameCamera.transform.position);
    //    if (distFromCamera > 100f)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            effect.Play();
            Destroy(gameObject,1f);
        }
        else if(other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponentInParent<Enemy>();
            enemy.SufferDamage(damage);
            Destroy(gameObject);
        }
    }
}
