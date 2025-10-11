using UnityEngine.EventSystems;

public class RightArrow:InteractableUIBase
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        EventManager.Instance.CallBack<InteractableUIBase>(GameEvent.H1.SceneChange.Clicked,this);
    }
}