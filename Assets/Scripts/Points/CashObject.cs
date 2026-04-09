using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashObject : MonoBehaviour
{
    // Cash object settings options
    [SerializeField] private GameObject objectToDestroy;
    [SerializeField] private int points = 10;

    private void OnTriggerEnter(Collider other)
    {
        // Picking up by Player
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.addPoints(points);
            Destroy(objectToDestroy);
        }
    }
}
