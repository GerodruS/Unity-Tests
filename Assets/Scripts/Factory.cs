using System.Collections.Generic;
using UnityEngine;


public class Factory : MonoBehaviour
{
    public GameObject MovingObjectPrefab;

    const int StartCount = 200;
    const int MaxCount = 1000;
    const int Delta = 200;
    Vector2 StartPositionMin = new Vector2(-6.25f, -5.0f);
    Vector2 StartPositionMax = new Vector2(6.25f, 5.0f);

    List<GameObject> MovingObjects = new List<GameObject>();
    
    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        for (var i = 0; i < StartCount; ++i)
        {
            var position = new Vector3(Random.Range(StartPositionMin.x, StartPositionMax.x),
                Random.Range(StartPositionMin.y, StartPositionMax.y),
                0.0f);
            var movingObject = Instantiate(MovingObjectPrefab, position, Quaternion.identity);
            MovingObjects.Add(movingObject);
        }
    }

    public void Increase()
    {
        if (MovingObjects.Count < MaxCount)
        {
            for (int i = 0; i < Delta; ++i)
            {
                var position = new Vector3(Random.Range(StartPositionMin.x, StartPositionMax.x),
                    Random.Range(StartPositionMin.y, StartPositionMax.y),
                    0.0f);
                var movingObject = Instantiate(MovingObjectPrefab, position, Quaternion.identity);
                MovingObjects.Add(movingObject);
            }
        }
    }

    public void Decrease()
    {
        if (Delta <= MovingObjects.Count)
        {
            for (int i = 0; i < Delta; ++i)
            {
                Destroy(MovingObjects[MovingObjects.Count - 1]);
                MovingObjects.RemoveAt(MovingObjects.Count - 1);
            }
        }
    }
}