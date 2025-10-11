using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEvent.H2;

public class PropItemManager : MonoBehaviour
{
    [SerializeField]
    private List<PropItem> props = new List<PropItem>();
    [SerializeField]
    private PropItemTable propTabel;

    private PropUIController controller;
    public void Awake()
    {
        
    }

    public void Start()
    {
        InitializeEvent();
        UpdateUIVisible();
    }

    //当玩家点击道具之后,调用该函数
    public void OnPropClicked(PropItem prop)
    {
        int iconIndex = prop.KeyIndex;
        
        // Find the corresponding PropItemElement in propTabel
        PropItemElement foundElement = null;
        foreach (var element in propTabel.PropItems)
        {
            if (element.key == iconIndex)
            {
                foundElement = element;
                break;
            }
        }
        
        // Check if element was found and get propSprite
        if (foundElement != null)
        {
            Sprite propSprite = foundElement.propSprite;
            // TODO: Use propSprite here for further logic
            DevelopmentTool.Print($"Found propSprite for key {iconIndex}", "PropItemManager");
        }
        else
        {
            DevelopmentTool.Print($"No PropItemElement found for key {iconIndex}", "PropItemManager");
        }
    }

    #region
    private void InitializeEvent()
    {
        EventManager.Instance.AddEventListening<PropItem>(GameEvent.H2.Prop.Clicked, OnPropClicked);
    }

    private void UpdateUIVisible()
    {
        if(controller != null && props.Count != 0)
        {

            controller.gameObject.SetActive(true);
        }
        else
        {
            controller.gameObject.SetActive(false);
        }
    }
    #endregion
}
