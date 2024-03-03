using UnityEngine;
using UnityEngine.EventSystems;

namespace _Source.Game
{
    public class DropOnSlotScript : MonoBehaviour,IDropHandler
    {
        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            /*eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.transform.localPosition = Vector3.zero;*/
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}