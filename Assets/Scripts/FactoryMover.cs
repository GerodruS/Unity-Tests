using System.Collections.Generic;
using UnityEngine;


public class FactoryMover : MonoBehaviour
{
    public GameObject MovingObjectPrefab;

    const int StartCount = 100;
    const int MaxCount = 1000;
    const int Delta = 100;
    Vector2 StartPositionMin = new Vector2(-6.25f, -5.0f);
    Vector2 StartPositionMax = new Vector2(6.25f, 5.0f);

    const float MinX = -6.25f;
    const float MaxX = 6.25f;
    const float MinY = -5.0f;
    const float MaxY = 5.0f;
    const float MinVelocity = 1.0f;
    const float MaxVelocity = 3.0f;

    class MovedObjectData
    {
        public GameObject GameObject;
        public Vector3 Direction;
    }

    List<MovedObjectData> MovingObjects = new List<MovedObjectData>();

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
            var direction = new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0.0f);
            direction = direction.normalized * Random.Range(MinVelocity, MaxVelocity);
            MovingObjects.Add(new MovedObjectData
            {
                GameObject = movingObject,
                Direction = direction
            });
        }
    }

    void Update()
    {
        for (int i = 0, n = MovingObjects.Count; i < n; i++)
        {
            var movedObject = MovingObjects[i];
            Move(movedObject.GameObject.transform, ref movedObject.Direction);
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
                var direction = new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0.0f);
                direction = direction.normalized * Random.Range(MinVelocity, MaxVelocity);
                MovingObjects.Add(new MovedObjectData
                {
                    GameObject = movingObject,
                    Direction = direction
                });
            }
        }
    }

    public void Decrease()
    {
        if (Delta <= MovingObjects.Count)
        {
            for (int i = 0; i < Delta; ++i)
            {
                Destroy(MovingObjects[MovingObjects.Count - 1].GameObject);
                MovingObjects.RemoveAt(MovingObjects.Count - 1);
            }
        }
    }

    void Move(Transform movedTransform, ref Vector3 direction)
    {
        var position = movedTransform.localPosition;
        position = position + direction * Time.deltaTime;

        if (position.x < MinX && direction.x < 0)
            direction.x = -direction.x;

        if (MaxX < position.x && 0 < direction.x)
            direction.x = -direction.x;

        if (position.y < MinY && direction.y < 0)
            direction.y = -direction.y;

        if (MaxY < position.y && 0 < direction.y)
            direction.y = -direction.y;

        movedTransform.localPosition = position;
    }
}