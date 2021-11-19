using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;

    private void Start()
    {
        GameOverScreen.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(Input.GetKey(KeyCode.Escape)) Application.Quit();
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }
}
