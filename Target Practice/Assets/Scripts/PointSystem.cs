using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    public TextMeshProUGUI pointsText; // Reference to your TextMeshProUGUI component
    private int points = 0;

    private void Start()
    {
        UpdatePointsText();
    }

    public void AddPoints(int pointValue)
    {
        points += pointValue;
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        if (pointsText != null)
        {
            pointsText.text = "Points: " + points.ToString();
        }
    }
}



