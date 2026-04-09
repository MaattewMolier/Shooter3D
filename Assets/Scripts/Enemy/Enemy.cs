using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy settings options
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private int Health = 2;

    public EnemyMovement movement;
    public void takeDamage(int damage)
    {
        // Enemy takes damage if Player shoots him
        Health -= damage;
        if (Health <= 0)
        {
            enemyLose();
        }
    }
    public void enemyLose()
    {
        // Enemy gets destroyed
        Instantiate(pointPrefab, transform.position + Vector3.up, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Bullet damage collision with enemy
        Bullet bullet = other.GetComponent<Bullet>();
        if(bullet != null)
        {
            takeDamage(bullet.GetDamage());
            Destroy(bullet.gameObject);
        }
    }
}
