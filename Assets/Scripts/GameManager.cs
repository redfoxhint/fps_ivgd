﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject gameOverPanel;
    public Transform playerT;
    public bool beingDetected;
    public bool detected;

    bool gameOver = false;

    LevelFader levelFader;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

        levelFader = FindObjectOfType<LevelFader>();
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
        AudioManager.instance.PlayMusic("Dark");
    }

    private void Update()
    {

    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        InputManager.instance.HandleMovement = false;
        gameOver = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Retry()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        levelFader.FadeToLevel(currentScene);
        Debug.Log("RETRIED");
        //SceneManager.LoadScene(currentScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EndGame()
    {
        Invoke("End", 1f);
    }

    private void End()
    {
        levelFader.FadeToLevel(3);
    }
}
