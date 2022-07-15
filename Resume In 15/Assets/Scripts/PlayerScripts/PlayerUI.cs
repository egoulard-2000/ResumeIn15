using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("PlayerUI GameObjects")]
    [SerializeField]
    private TextMeshProUGUI promptText;
    [SerializeField]
    private RectTransform crosshair;

    private readonly float normalSize = 1f;
    private readonly float maxSize = 8f;
    private readonly float speed = 25f;
    private float currentSize;

    [Header("List of Tasks")]
    [SerializeField]
    private TextMeshProUGUI task1;
    [SerializeField]
    private TextMeshProUGUI task2;
    [SerializeField]
    private TextMeshProUGUI task3;
    [SerializeField]
    private TextMeshProUGUI task4;

    //Checks for completion status
    private readonly float opacityOfCompletion = 0.2f;

    /// <summary>
    /// Updates the Text and the Size of the Crosshair for when Hovering over interactables.
    /// Refer to its use in "PlayerInteraction" Script.
    /// </summary>
    /// <param name="promptString"></param>
    public void UpdateTextAndCrosshair(string promptString)
    {
        promptText.text = promptString;

        //Check if there's currently a prompt on screen
        if (string.IsNullOrEmpty(promptString))
            currentSize = Mathf.Lerp(currentSize, normalSize, speed * Time.deltaTime);
        else
            currentSize = Mathf.Lerp(currentSize, maxSize, speed * Time.deltaTime);

        crosshair.sizeDelta = new Vector2(currentSize, currentSize);
    }

    public bool allTasksComplete()
    {
        if (task1.color.a == opacityOfCompletion && task2.color.a == opacityOfCompletion && task3.color.a == opacityOfCompletion && task4.color.a == opacityOfCompletion)
        {
            return true;
        }

        return false;
    }
}
