using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Pawn
{
    [SerializeField] GameObjectRuntimeSet playerRuntimeSet;
    [SerializeField] float speed;
    private Animator anim;
    private GameObject target;
    private EnemyState currentState;
    enum EnemyState { Walk, Attack, idle }

    private void Awake()
    {
        //Get Player
        target = playerRuntimeSet.GetItemIndex(0);
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        UpdateState();
        if (currentState.Equals(EnemyState.idle)) return;
        else if (currentState.Equals(EnemyState.Walk))
        {
            transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
            Vector3 direction = target.transform.position - transform.position;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
            anim.SetTrigger("attack");
        }
    }

    void UpdateState()
    {
        if (target != null)
        {
            float distFromPlayer = Vector3.Distance(transform.position, target.transform.position);
            if (distFromPlayer <= 1.5f)
            {
                currentState = EnemyState.Attack;
            }
            else
            {
                currentState = EnemyState.Walk;
            }
        }
        else
        {
            currentState = EnemyState.idle;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.SufferDamage(25);
        }
    }
}
