using System;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.PlayerLoop;

namespace MiniGames.GameEngine
{   
    [RequireComponent(typeof(Animator))]
    public class Card : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler
    {
        public const float CardSize = 0.4731f;
        
        public CardData Data;
        public SpriteRenderer FaceSriteRenderer;
        public Transform target;

        public bool IsOpenCard => _isOpenCard;
       

        private CardDeck _cardDeck;
        private bool _isOpenCard;

        // Start is called before the first frame update
        void Start()
        {
            FaceSriteRenderer.sprite = Data.FaceCard;
            FaceSriteRenderer.size = new Vector2(CardSize, CardSize);
            
            _isOpenCard = false;
        }

        // Update is called once per frame
        void Update()
        {
            /*if (Input.GetKeyDown(KeyCode.O))
            {
                transform.DOMove(target.position, 5, false);
            }*/
        }
        
        #region ImplementInput

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("<color=blue>" + gameObject.name + "</color>");
            var s = DOTween.Sequence();
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            
        }

        #endregion
    }

    [Serializable]
    public struct CardData
    {
        [SerializeField]
        private Sprite faceCard;
        public int CardId;

        public Sprite FaceCard
        {
            get { return faceCard; }
            set
            {
                faceCard = value;
            }
        }
    }
}


