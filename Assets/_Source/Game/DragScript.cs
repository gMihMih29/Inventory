using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
namespace _Source.Game
{
  public class DragScript : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
  {
    RectTransform rec;
    Image img;
    Color tempColor;
    Canvas canvas;

    public void Init(Canvas c)
    {
      canvas = c;
    }
    
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
      transform.parent.SetSiblingIndex(-1);
      tempColor.a=.5f;
      img.color=tempColor;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
      transform.position = Camera.main.ScreenToWorldPoint(eventData.position) - 2 * Vector3.back;
      img.raycastTarget=false;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
      tempColor.a=1;
      img.color=tempColor;
      img.raycastTarget=true;
      if (gameObject.TryGetComponent(out ItemView view))
      {
        view.UpdatePosition(Vector3.zero);
      }
    }

    // Start is called before the first frame update
    void Awake()
    {
      rec=GetComponent<RectTransform>();
      img=GetComponent<Image>();
      tempColor=img.color;
    }
  }
}