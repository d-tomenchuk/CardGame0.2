using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PresetCards : MonoBehaviour
{
    public System.Random ran = new System.Random();
    private Sprite _backSprite = null;
    private List<Sprite> _allSprites = null;
    [SerializeField] private LevelData _levelData = null;
    private readonly ResourcesLoader resourcesLoader = new ResourcesLoader();
    [SerializeField] private UnityEvent _onLoaded = new UnityEvent();



    public void GetSprites()
    {
        Theme theme = resourcesLoader.GetTheme(_levelData.ThemeName);
        _backSprite = theme.BackSprite;
        _allSprites = theme.AllSprites;
    
        _onLoaded.Invoke();
    }

    public Sprite GetBackSprite()
    {
        return _backSprite;  
    }
    public List<Sprite> GetPlayCardsSprite()
    {
        List<Sprite> sprites = new List<Sprite>(_allSprites);

        for (int i = sprites.Count - 1; i >= 1; i--)
        {
           int j = ran.Next(i + 1);
           
           var temp = sprites[j];
           sprites[j] = sprites[i];
           sprites[i] = temp;
        }
        while (_levelData.MaxPlayCards > sprites.Count)
        {
            sprites.RemoveAt(Random.Range(0, sprites.Count));   
        } 
        return sprites;
    }
    public int[] GetCardIndex()
    {
       int[] cardIndex = new int[_levelData.MaxPlayCards];
       for(int i = 0; i < cardIndex.Length;i++)
       {
           cardIndex[i] = i;  
       }
       for(int i = 0; i < cardIndex.Length; i++)
       {
           int temp = cardIndex[i];
           int rdn = Random.Range(0, cardIndex.Length);
           cardIndex[i] = cardIndex[rdn];
           cardIndex[rdn] = temp;
       }
       
       return cardIndex;
    }

    


}
