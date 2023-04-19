using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float life;
    [SerializeField] float speed;
    GameObject target;
    public void SufferDamage(float damage)
    {
        life -= damage;
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        target = GameObject.Find("MainCharacter");
        transform.LookAt(target.transform);
        target.transform.position += target.transform.forward * speed * Time.deltaTime;
    }
}
