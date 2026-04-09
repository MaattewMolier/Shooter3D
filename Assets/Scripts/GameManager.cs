using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class GameManager : MonoBehaviour
{
    //Game Manager settings options
    [SerializeField] private RestartPanel restartPanel;
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private StarterAssetsInputs playerInput;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Rest panel will not be show during gameplay
        restartPanel.gameObject.SetActive(false);
    }
    public void GameOver()
    {
        // Showing reset panel after game over
        restartPanel.gameObject.SetActive(true);
        spawner.turnOff();
        playerInput.cursorLocked = false;
        playerInput.SetCursorState(playerInput.cursorLocked);
    }
}
