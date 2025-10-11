using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableUIBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public virtual void Awake()
    {
        
    }
    public virtual void Start()
    {
        
    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        //DevelopmentTool.Print("图像被点击", "InteractableUIBase");
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        //DevelopmentTool.Print("指针悬浮", "InteractableUIBase");
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        //DevelopmentTool.Print("指针离开", "InteractableUIBase");
    }


}
