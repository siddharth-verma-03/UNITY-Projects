using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIStateData", menuName = "UI/UIStateData")]
public class UIStateData : ScriptableObject
{
    public List<string> trackedObjects = new List<string>();
    public List<bool> objectStates = new List<bool>();

    public void SaveState(Dictionary<string, bool> uiStates)
    {
        trackedObjects.Clear();
        objectStates.Clear();

        foreach (var entry in uiStates)
        {
            trackedObjects.Add(entry.Key);
            objectStates.Add(entry.Value);
        }
    }

    public Dictionary<string, bool> LoadState()
    {
        Dictionary<string, bool> uiStates = new Dictionary<string, bool>();

        for (int i = 0; i < trackedObjects.Count; i++)
        {
            uiStates[trackedObjects[i]] = objectStates[i];
        }

        return uiStates;
    }
}
