using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PropUI : PropUIItemBase
{

    public Image item;
    public override void OnPointerClick(PointerEventData eventData)
    {
        controller.PropUIClicked();
    }
}
