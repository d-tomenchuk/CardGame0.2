using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer),typeof(BoxCollider2D))]

public class Card : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Sprite _backSprite;
    private Sprite _frontSprite;
    private Animation _animation;
    private bool _isBackSide = true;
    private BoxCollider2D _boxCollider2d;

    public int Index {get; private set;}

    private CardCollector _cardCollector;

    



    private void Awake(){

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animation = GetComponent<Animation>();
        _boxCollider2d = GetComponent<BoxCollider2D>();
        

    }
    private void EnableCollider(){
        _boxCollider2d.enabled = true;
        

    }
    private void ChangeSpriteCard(){

        _spriteRenderer.sprite = _isBackSide == true ? _backSprite : _frontSprite;

    }

    

    private void OnMouseDown()
    {   
        if (_cardCollector.TwoCardsClosed())
        {
            _boxCollider2d.enabled = false;
            CardAnimation();
            _cardCollector.OpenCard(this);
        }
    }
    public void CardAnimation()
    {
        _isBackSide = !_isBackSide;
        _animation.Play(_isBackSide == true ? "ToBack":"ToFront");

    }

    public void CardsSettings(Sprite back , Sprite front, int index)
    {
        _spriteRenderer.sprite = _backSprite = back;
        
        _frontSprite = front;
        Index = index;

        if (!_isBackSide)        
            _spriteRenderer.flipX = true;      
        else     
            _spriteRenderer.flipX = false; 

    }

    public void SetCardCollector(CardCollector cardCollector)
    { 
        _cardCollector = cardCollector;
    }

}
