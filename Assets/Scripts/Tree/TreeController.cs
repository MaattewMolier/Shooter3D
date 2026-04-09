using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    // Tree settings options
    [SerializeField] private PlayerUI playerUI;
    [SerializeField] private int Health = 5;

    private void Update()
    {
        // Tree health on screen text 
        playerUI.treeHealthtext.text = "Tree Health: " + Health.ToString();
    }
    public void takeDamage(int damage)
    {
        // Enemy damage to tree
        Health -= damage;
        if (Health <= 0)
        {
            TreeDestroy();
        }
    }
    public void TreeDestroy()
    {
        // Destroying tree after enemy hits enough times
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }

    
}
