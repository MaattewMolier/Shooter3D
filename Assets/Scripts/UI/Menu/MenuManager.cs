using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Menu Manager settings options
    [SerializeField] private int gameSceneIndex;
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button exitGameButton;

    private void Start()
    {
        // Menu buttons actions
        startGameButton.onClick.AddListener(StartGame);
        exitGameButton.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        // Starting game via GameScene
        SceneManager.LoadScene(gameSceneIndex);
    }

    private void ExitGame()
    {
        // Qutting the game
        Application.Quit();
    }
}
