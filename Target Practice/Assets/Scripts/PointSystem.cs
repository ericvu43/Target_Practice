using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public Text pointsText;
    private int points = 0;

    public void AddPoints(int amount)
    {
        points += amount;
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


