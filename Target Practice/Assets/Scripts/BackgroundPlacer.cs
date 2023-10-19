using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPlacer : MonoBehaviour
{
    [SerializeField] private List<GameObject> forestPrefabs;

    [SerializeField] private List<GameObject> forests;

    [SerializeField] private float scaleWidth, scaleHeight, distance;

    [ContextMenu("CreateBackground")]
    // Start is called before the first frame update
    private void CreateBackground()
    {
        foreach (var forest in forests)
        {
            DestroyImmediate(forest);
        }

        forests = new List<GameObject>();

        int prefabIndex = 0;
        float angle = 0f;

        for (int i = 0; i < 8; i++)
        {
            forests.Add(Instantiate(forestPrefabs[prefabIndex], transform));

            forests[i].transform.Rotate(new Vector3(0f, angle, 0f));

            angle += 45f;

            prefabIndex++;
            if (prefabIndex >= forests.Count)
            {
                prefabIndex = 0;
            }
        }

    }

    [ContextMenu("SetForestScale")]
    private void SetForestScale()
    {
        foreach (var fs in forests)
        {
            fs.transform.localScale = new Vector3(scaleWidth, scaleHeight, 1f);
            float spriteLength = forests[0].GetComponent<SpriteRenderer>().bounds.size.x;
            distance = spriteLength / 2f + (Mathf.Sqrt(2) / 2) * spriteLength;
            fs.transform.position = distance * fs.transform.forward;
        }
    }






}
