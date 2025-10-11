public class SceneH2:Scenebase
{
    public override void Start()
    {
        EventManager.Instance.AddEventListening<InteractableUIBase>(GameEvent.H2.SceneChange.Clicked, OnSceneChangeIconClicked);
    }


}