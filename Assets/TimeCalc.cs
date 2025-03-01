using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TimeCalc : MonoBehaviour
{
   public TextMeshProUGUI textMeshProUGUI;
    private float score = 0f;
    private float scoreSpeed = 25f;
    public void Reseto()
    {
        textMeshProUGUI.text = "0";
    }
    // Update is called once per frame
    void OnEnable()
    {
        score = int.Parse(textMeshProUGUI.text.Split(" ")[0]);  // Initialize score from UI
    }

    void FixedUpdate()
    {
        score += Time.fixedDeltaTime * scoreSpeed;  // Accumulate fractional values
        textMeshProUGUI.text = ((int)score).ToString();  // Only update integer value
    }
}
