using System.Collections;
using System.Collections.Generic;
using MiniGames.GameEngine;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectionCard", menuName = "Create Collection Card", order = 12)]
public class CardsCollection : ScriptableObject
{
    public CardData[] data;
}
