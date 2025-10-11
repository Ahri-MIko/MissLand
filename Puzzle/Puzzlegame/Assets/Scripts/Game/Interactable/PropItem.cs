using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PropItem:InteractableUIBase
{

    [SerializeField]
    private int keyindex;

    public int KeyIndex
    {
        get { return keyindex; }
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        EventManager.Instance.CallBack<PropItem>(GameEvent.H2.Prop.Clicked,this);
    }
}