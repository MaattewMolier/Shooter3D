using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Enemy attack settings options
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        // Enemy attacking either Player or Tree
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            player.takeDamage(damage);
            Destroy(gameObject);
        }

        TreeController tree = other.GetComponent<TreeController>();
        if(tree != null)
        {
            tree.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
