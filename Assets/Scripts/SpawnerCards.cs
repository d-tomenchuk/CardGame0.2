using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerCards : MonoBehaviour
{
    
    [SerializeField] private Grid _grid = null;
    [SerializeField] private PresetCards _presetCards = null;
    [SerializeField] private Card _cardPrefub = null;
    [SerializeField] private UnityEvent _startCollect = new UnityEvent();
    
    

    public void Spawn(){
        
        Transform localTransform = GetComponent<Transform>();
        Card card;
        
        Sprite backSprite = _presetCards.GetBackSprite();
        List<Sprite> playCardsSprites = _presetCards.GetPlayCardsSprite();
        float _positionY = _grid.PositionY;
        for(int i = 0; i < _grid.getCardsRow(); i++){

            int[] playCardsIndex = _presetCards.GetCardIndex();
            float positionX = _grid.GetPositionX();
            for(int j = 0; j < playCardsIndex.Length; j++){
                
                card = Instantiate(_cardPrefub) as Card;
                card.transform.position = new Vector3(positionX,_positionY+localTransform.position.y);
                card.transform.parent = localTransform;
                card.CardsSettings(backSprite,playCardsSprites[playCardsIndex[j]],playCardsIndex[j]);
                positionX += _grid.OffsetX;
                
                
                

            }
            _positionY += -1.55f;
            
            


        }
            
            
        


        
        _startCollect.Invoke();
    }

}
