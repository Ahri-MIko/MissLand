using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : PropUIItemBase
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        controller.leftButtonClicked();
    }
}
