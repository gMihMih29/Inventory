using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour
{
    void Start()
    {
        //Fetch the Event Trigger component from your GameObject
        EventTrigger trigger = GetComponent<EventTrigger>();
        //Create a new entry for the Event Trigger
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //Add a Drag type event to the Event Trigger
        entry.eventID = EventTriggerType.Drag;
        //call the OnDragDelegate function when the Event System detects dragging
        entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
        //Add the trigger entry
        trigger.triggers.Add(entry);
    }

    public void OnDragDelegate(PointerEventData data)
    {
        Debug.Log("123");
        //Create a ray going from the camera through the mouse position
        UnityEngine.Ray ray = Camera.main.ScreenPointToRay(data.position);
        //Calculate the distance between the Camera and the GameObject, and go this distance along the ray
        Vector3 rayPoint = ray.GetPoint(Vector3.Distance(transform.position, Camera.main.transform.position));
        //Move the GameObject when you drag it
        transform.position = rayPoint;
    }
}
