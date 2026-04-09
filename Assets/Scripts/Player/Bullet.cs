using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Bullet settings options
    private Rigidbody rb;
    [SerializeField] private float speed = 30f;

    private int BulletDamage;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Sets damage of the bullets
    public void SetDamage(int damage)
    {
        BulletDamage = damage;
    }

    // Shooting bullets
    public void Shoot(Vector3 direction)
    {
        rb.velocity = direction * speed;
        Destroy(gameObject, 5f);
    }

    // Reciving damege from bullet
    public int GetDamage()
    {
        return BulletDamage;
    }
}
