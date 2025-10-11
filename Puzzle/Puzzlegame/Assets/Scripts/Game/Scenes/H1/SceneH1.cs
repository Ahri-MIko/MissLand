public class SceneH1:Scenebase
{
    public override void Start()
    {
        EventManager.Instance.AddEventListening<InteractableUIBase>(GameEvent.H1.SceneChange.Clicked, OnSceneChangeIconClicked);
    }
}