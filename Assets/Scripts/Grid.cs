using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public readonly float OffsetX = 1.75f;
    public readonly float PositionY = 1.5f;
    public readonly float OffsetY = 1.5f;

    public GameObject gameManeger;
    [SerializeField] private LevelData _levelData = null;


    public int GetColumsCount()
    {
        return _levelData.MaxPlayCards;
    }

    public float GetPositionX()
    {
       float x = 1f;
       x -= OffsetX * (GetColumsCount() / 2f);
       return x;
    }
    public int getCardsRow()
    {
        if(_levelData.MaxPlayCards % 2 == 1)
            return _levelData.MaxPlayCards - 1;
        else
            return _levelData.MaxPlayCards;
        
    }
    public void positionGameManeger()
    {
        if(_levelData.MaxPlayCards == 4 )
            gameManeger.transform.position = new Vector3(-0.25f, 0.8f, 0);
        else if(_levelData.MaxPlayCards == 7)
            gameManeger.transform.position = new Vector3(0, 1.95f, 0);
        else if(_levelData.MaxPlayCards == 2)
            gameManeger.transform.position = new Vector3(0, 1.95f, 0);
    }
private void Update() {
    positionGameManeger();
}
}