using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
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
    /* This Method communicates to ArrowShoot to reset score after 9 arrow shots */
    public int GetPoints()
    {
        return points;
    }
}



