using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripting : MonoBehaviour
{

    public GameObject target;
    public int health = 100;
    public int dmgAmount;

    public float movementSpeed;
    public float aggroRange;
    public float stoppingDistance;
    public float attackTimer;

    private float distance;
    private float timer;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance <= aggroRange && distance > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2 (target.transform.position.x, transform.position.y), movementSpeed * Time.deltaTime);
        }
    }

 
    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
        Gizmos.DrawLine(transform.position, target.transform.position);
    }
}

