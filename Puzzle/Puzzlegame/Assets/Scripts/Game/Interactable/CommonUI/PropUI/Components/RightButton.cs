using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : PropUIItemBase
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        controller.RightButtonClicked();
    }
}
