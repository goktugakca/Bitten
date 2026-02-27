using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public LevelManager levelManager;
    public Player player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            RestartLevel();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            LoadPreviousLevel();
        }
    }
    void Start()
    {
        RestartLevel();
    }
    private void LoadNextLevel()
    {
        levelManager.currentLevelNo++;
        if(levelManager.currentLevelNo >= levelManager.levelPrefabs.Count)
        {
            levelManager.currentLevelNo = levelManager.levelPrefabs.Count;
        }
        RestartLevel();
    }

    private void LoadPreviousLevel()
    {
        levelManager.currentLevelNo--;
        if(levelManager.currentLevelNo < 1)
        {
            levelManager.currentLevelNo=1;
        }
        RestartLevel();
    }

    public void RestartLevel()
    {
        levelManager.RestartLevel();
        player.RestartPlayer();
    }
}
