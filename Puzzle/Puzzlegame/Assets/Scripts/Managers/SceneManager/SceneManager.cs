using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private List<Scenebase> scenes = new List<Scenebase>();

    public Image SceneChangeBackground;
    public IReadOnlyList<Scenebase> Scenes => scenes;

    public int CurrentSceneIndex = 0;

    public Scenebase CurrentScene;

    private bool isTransitioning = false;
    private void Awake()
    {
        InitializeScenes();
        InitializeCurrentScene();
        InitializeEvent();
        InitialzeCurtain();
    }

    public void ChangeToTargerScene(Scenebase targetScene)
    {
        if (!isTransitioning)
        {
            StartCoroutine(ChangeSceneWithTransition(targetScene));
        }
    }

    private IEnumerator ChangeSceneWithTransition(Scenebase targetScene)
    {
        isTransitioning = true;


        //Curtain透明度变化
        float fadeInDuration = 0.5f;
        float elapsedTime = 0f;

        Color bgColor = SceneChangeBackground.color;
        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            SceneChangeBackground.color = new Color(bgColor.r, bgColor.g, bgColor.b, alpha);
            yield return null;
        }

        // Ensure alpha is exactly 1
        SceneChangeBackground.color = new Color(bgColor.r, bgColor.g, bgColor.b, 1f);

        // Switch scenes
        CurrentScene.gameObject.SetActive(false);
        targetScene.gameObject.SetActive(true);

        // Set initial scale to 1.1
        targetScene.transform.localScale = Vector3.one * 1.1f;

        // Phase 2: Fade out (1 to 0 alpha) and scale down (1.1 to 1) over 0.5 seconds
        float fadeOutDuration = 0.5f;
        elapsedTime = 0f;

        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeOutDuration;

            // Fade out background
            float alpha = Mathf.Lerp(1f, 0f, t);
            SceneChangeBackground.color = new Color(bgColor.r, bgColor.g, bgColor.b, alpha);

            // Scale down target scene
            float scale = Mathf.Lerp(1.1f, 1f, t);
            targetScene.transform.localScale = Vector3.one * scale;

            yield return null;
        }

        // Ensure final values
        SceneChangeBackground.color = new Color(bgColor.r, bgColor.g, bgColor.b, 0f);
        targetScene.transform.localScale = Vector3.one;

        // Update current scene
        CurrentScene = targetScene;


        isTransitioning = false;
    }

    #region
    private void InitializeScenes()
    {
        scenes.Clear();
        Scenebase[] childScenes = GetComponentsInChildren<Scenebase>(true);
        
        foreach (var scene in childScenes)
        {
            scenes.Add(scene);
        }

        DevelopmentTool.Print($"SceneManager initialized with {scenes.Count} scenes", "SceneManager");
    }

    private void InitializeCurrentScene()
    {
        CurrentScene = scenes[CurrentSceneIndex];

        for (int i = 0; i < scenes.Count; i++)
        {
            scenes[i].gameObject.SetActive(i == CurrentSceneIndex);
        }
    }

    private void InitializeEvent()
    {
        EventManager.Instance.AddEventListening<Scenebase>(GameEvent.Global.SceneChange, ChangeToTargerScene);
    }

    private void InitialzeCurtain()
    {
        if(SceneChangeBackground != null)
        {
            SceneChangeBackground.color = new Color(
            SceneChangeBackground.color.r,
            SceneChangeBackground.color.g,
            SceneChangeBackground.color.b,
            0.0f  // alphaֵ����Χ0-1
            );
        }
    }
    #endregion
}
