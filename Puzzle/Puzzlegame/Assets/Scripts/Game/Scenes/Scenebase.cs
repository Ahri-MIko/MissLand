using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Scenebase:MonoBehaviour
{
   public List<TransPair> pairs = new List<TransPair>();
   public Dictionary<InteractableUIBase,Scenebase> UIDictionary = new Dictionary<InteractableUIBase, Scenebase> ();

    public void Awake()
    {
        InitDictionary();
    }
    public virtual void Start()
    {
       
    }

    public virtual void OnSceneChangeIconClicked(InteractableUIBase ClickedUI)
    {
       if(UIDictionary.ContainsKey(ClickedUI))
       {
            EventManager.Instance.CallBack<Scenebase>(GameEvent.Global.SceneChange, UIDictionary[ClickedUI]);
       }
       else
        {
            DevelopmentTool.WTF("没有找到对应的UI");
        }
    }

    #region 初始化相关
    public void InitDictionary()
    {
        for (int i = 0; i < pairs.Count; i++)
        {
            UIDictionary.Add(pairs[i].InteractableUIBase, pairs[i].Scenebase);
        }
    }

    #endregion
}