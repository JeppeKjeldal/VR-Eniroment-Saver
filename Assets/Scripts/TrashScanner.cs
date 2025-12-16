using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashScanner : MonoBehaviour
{
    [SerializeField] private Transform trashParent;
    [SerializeField] private List<GameObject> allTrash;
    [SerializeField] private List<GameObject> collectedTrash;

    private float appleCoreValueInYears = 0.17f;
    private float canValueInYears = 500;
    private float glassBottleValueInYears = 4000;
    private float totalYearsSaved = 0;

    public TMP_Text yearsSavedText;

    public static TrashScanner Instance { get; private set; }

    private void Awake()
    {
        Debug.Log($"TrashScanner Awake on object: {gameObject.name}", this);

        Instance = this;

        foreach (Transform child in trashParent)
        {
            allTrash.Add(child.gameObject);
        }
    }

    public void CalculateYearsSaved(string tag)
    {
        if (tag == "Can")
        {
            totalYearsSaved += canValueInYears;
        }
        else if (tag == "Bottle")
        {
            totalYearsSaved += glassBottleValueInYears;
        }
        else
        {
            totalYearsSaved += appleCoreValueInYears;
        }

        UpdateYearsSavedUI();
    }

    private void UpdateYearsSavedUI()
    {
        yearsSavedText.text = "Years Saved: " + totalYearsSaved.ToString();
    }
}
