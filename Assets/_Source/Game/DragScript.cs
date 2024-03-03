using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
        tempColor.a=.5f;
        img.color=tempColor;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        rec.anchoredPosition+=eventData.delta / canvas.scaleFactor;
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