using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Source.Game.DragAndDrop
{
    /// <summary>
    /// Script of dragging items.
    /// Part of DragAndDrop feature.
    /// </summary>
    public class DragScript : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
    {
        private RectTransform _rect;
        private Image _image;
        private Color _color;
        private Canvas _canvas;

        public void Init(Canvas c)
        {
            _canvas = c;
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            transform.parent.SetSiblingIndex(-1);
            _color.a=.5f;
            _image.color=_color;
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            transform.position = Camera.main.ScreenToWorldPoint(eventData.position) - 2 * Vector3.back;
            _image.raycastTarget=false;
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            _color.a=1;
            _image.color=_color;
            _image.raycastTarget=true;
            if (gameObject.TryGetComponent(out ItemView view))
            {
                view.UpdatePosition(Vector3.zero);
            }
        }
        
        void Awake()
        {
            _rect=GetComponent<RectTransform>();
            _image=GetComponent<Image>();
            _color=_image.color;
        }
    }
}