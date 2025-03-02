using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStateManager : MonoBehaviour
{
    public UIStateData uiStateData; // Assign ScriptableObject in Inspector
    private Dictionary<string, bool> uiStates = new Dictionary<string, bool>();

    private void Awake()  // 🔥 Runs BEFORE Unity applies scene defaults
    {
        LoadUIState();
    }

    private void LoadUIState()
    {
        uiStates = uiStateData.LoadState();

        // Apply saved states to GameObjects
        foreach (GameObject obj in FindObjectsOfType<GameObject>(true))  // 🔥 Include inactive objects
        {
            if (uiStates.ContainsKey(obj.name))
            {
                obj.SetActive(uiStates[obj.name]);  // Apply saved state
            }
        }

        // Apply saved states to Buttons
        foreach (Button button in FindObjectsOfType<Button>(true))  // 🔥 Include inactive buttons
        {
            if (uiStates.ContainsKey(button.gameObject.name))
            {
                button.gameObject.SetActive(uiStates[button.gameObject.name]);
            }
        }
    }

    public void ToggleGameObject(GameObject obj)
    {
        if (obj == null) return;

        // Toggle active state
        bool newState = !obj.activeSelf;
        obj.SetActive(newState);

        // Save new state
        uiStates[obj.name] = newState;
        uiStateData.SaveState(uiStates);
    }

    public void ToggleButtonPair(GameObject counterpartButton)
    {
        // Find the button that was clicked
        GameObject thisButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

        if (thisButton == null || counterpartButton == null) return;

        // Disable the clicked button
        thisButton.SetActive(false);

        // Enable the counterpart button
        counterpartButton.SetActive(true);

        // Save the new states
        uiStates[thisButton.name] = false;
        uiStates[counterpartButton.name] = true;
        uiStateData.SaveState(uiStates);
    }
}
