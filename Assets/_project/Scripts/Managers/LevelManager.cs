using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> levelPrefabs;
    public int currentLevelNo;
    private Level _currentLevel;
    public void RestartLevel()
    {
        DeleteCurrentLevel();
        CreateNewLevel();
    }

    private void DeleteCurrentLevel()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
        }
    }

    private void CreateNewLevel()
    {
        _currentLevel = Instantiate(levelPrefabs[currentLevelNo -1 ]);
        _currentLevel.transform.position = Vector3.zero;
        _currentLevel.StartLevel();
    }
}
