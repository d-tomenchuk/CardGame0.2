using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUI : MonoBehaviour
{

[SerializeField] private LevelData _levelData = null;

public void SetDifficult(int value)
{
    _levelData.MaxPlayCards = value;
}

public void SetTheme(string name)
{
    _levelData.ThemeName = name;
}



}
