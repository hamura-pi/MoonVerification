﻿using System.Collections.Generic;
using MiniGames.GameEngine;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public const int ReqNumberOfOpenCard = 2;

    public Vector2 distBeetweenCard;
    public Vector2 sizeOfField;

    public int CountCards;
    
    public Card[] Cards;
    

    private List<Card> _selectedCard;
    private List<Transform> deckPosition;
    private void Start()
    {
        CreateCardField();
        _selectedCard = new List<Card>();
        
        foreach (var card in Cards)
        {
            card.SetCardDeck(this);
        }
    }

    private void CreateCardField()
    {
        CountCards
    }

    public void OpenCard(Card card)
    {
        _selectedCard.Add(card);
        
        Debug.Log(card.Data.CardId);

        if (_selectedCard.Count >= ReqNumberOfOpenCard)
        {
            var isMatch = CardComparison(_selectedCard[0], _selectedCard[1]);

            foreach (var sc in _selectedCard)
            {
                sc.Match(isMatch);
            }
            
            if (isMatch)
            {
                Debug.Log("Match");
            }
            else
            {
                
            }
            
            _selectedCard.Clear();
        }
    }

    private bool CardComparison(Card card1, Card card2)
    {
        return card1.Data.CardId == card2.Data.CardId;
    }
}
