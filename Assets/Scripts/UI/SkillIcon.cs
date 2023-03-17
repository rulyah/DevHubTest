using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.FactoryTool;

namespace UI
{
    public class SkillIcon : PoolableMonoBehaviour,IBeginDragHandler, IDragHandler,IEndDragHandler
    {
        [SerializeField] private Button _button;
        [SerializeField] private RectTransform _rect;
        
        public int skillId;
        private Image _image;

        public event Action<int> onSkillClick;

        public void Init()
        {
            _button.onClick.AddListener(Click);
        }
        
        public void SetSprite(Sprite sprite)
        {
            _image = GetComponent<Image>();
            _image.sprite = sprite;
            _rect.anchoredPosition = Vector2.zero;
            _rect.sizeDelta = Vector2.zero;
        }
        
        private void Click()
        {
            onSkillClick?.Invoke(skillId);
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            var parent = transform.parent.GetComponent<Transform>();
            parent.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.localPosition = Vector3.zero;
        }
    }
}