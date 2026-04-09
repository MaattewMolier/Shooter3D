using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartPanel : MonoBehaviour
{
    [SerializeField] private Button restartButton;

    private void Start()
    {
        // Starting game
        restartButton.onClick.AddListener(RestartButtonOnClick);
    }

    private void RestartButtonOnClick()
    {
        // Exiting game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
