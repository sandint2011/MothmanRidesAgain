﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    public GameObject pausePanel;
    private bool paused = false;

    public CinemachineVirtualCameraBase cam;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        cam.Follow = player.transform;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        if (!paused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
    }
}