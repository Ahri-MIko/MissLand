using UnityEngine;

public class PropUIController:MonoBehaviour
{
    public LeftButton leftButton;
    public RightButton rightButton;
    public PropUI propUI;

    private void Awake()
    {
        InitializeUIComponent();
    }

    public void leftButtonClicked()
    {

    }

    public void RightButtonClicked()
    {

    }

    public void PropUIClicked()
    {

    }


    #region ≥ı ºªØ
    public void InitializeUIComponent()
    {
        if (leftButton != null && rightButton != null && propUI != null)
        {
            leftButton.controller = this;
            rightButton.controller = this;
            propUI.controller = this;
        }
        
    }
    #endregion
}