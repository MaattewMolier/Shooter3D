using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player settings options
    [Header("Components")]
    [SerializeField] private PlayerUI playerUI;

    [Header("Settings")]
    [SerializeField] private int playerHealth;

    private int playerPoints;
    private void Start()
    {
        playerPoints = 0;
    }
    private void Update()
    {
        // Points and health on screen texts
        playerUI.Pointstext.text = "Points: " + playerPoints.ToString();
        playerUI.Healthtext.text = "Health: " + playerHealth.ToString();
    }
    public void addPoints(int points)
    {
        // Adding points
        playerPoints += points;
    }
    public void takeDamage(int damage)
    {
        // Enemy damage on player
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            playerLose();
        }
    }
    public void playerLose()
    {
        // Player defeat
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }
}

