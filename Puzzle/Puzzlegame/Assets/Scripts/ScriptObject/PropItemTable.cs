using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PropItemElement
{
    public int key;
    public Sprite sceneSprite;
    public Sprite propSprite;
}

[CreateAssetMenu(fileName = "PropItemTable", menuName = "ScriptableObjects/PropItemTable")]
public class PropItemTable : ScriptableObject
{
    [SerializeField]
    private List<PropItemElement> propItems = new List<PropItemElement>();

    public IReadOnlyList<PropItemElement> PropItems => propItems;
}
