using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.PlayerLoop;

namespace MiniGames.GameEngine
{   
    [RequireComponent(typeof(Animator))]
    public class Card : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
    {
        public const float CardSize = 0.4731f;
        public CardData Data;
        public SpriteRenderer FaceSriteRenderer;
        
        public bool IsOpenCard => _isOpenCard;
        
        private Animator _animator;
        private CardDeck _cardDeck;
        private bool _isOpenCard;
        
        void Start()
        {
            FaceSriteRenderer.sprite = Data.FaceCard;
            FaceSriteRenderer.size = new Vector2(CardSize, CardSize);

            _animator = GetComponent<Animator>();
            _isOpenCard = false;
        }

        public void SetCardDeck(CardDeck cardDeck)
        {
            this._cardDeck = cardDeck;
        }
        
        private void CloseCard()
        {
            _isOpenCard = false;
            AnimationStateCard();
        }

        private void CardDisappears()
        {
            gameObject.SetActive(false);
        }

        private void AnimationStateCard()
        {
            _animator.SetBool("Open", _isOpenCard);
        }

        public void Match(bool isMatch)
        {
            if (isMatch)
            {
                CardDisappears();
            }
            else
            {
                CloseCard();
            }
        }

        IEnumerator DelayOpen()
        {
            yield return new WaitForSeconds(1f);
            while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.5f);
            _cardDeck.OpenCard(this);
        }
        
        #region ImplementInput
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_isOpenCard)
            {
                _isOpenCard = true;
            }
            
            AnimationStateCard();
            StartCoroutine(DelayOpen());
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


