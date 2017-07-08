using UnityEngine;


public class RandomMover : MonoBehaviour
{
    const float MinX = -6.25f;
    const float MaxX = 6.25f;
    const float MinY = -5.0f;
    const float MaxY = 5.0f;
    const float MinVelocity = 1.0f;
    const float MaxVelocity = 3.0f;

    Vector3 CurrentDirection;

    void Start()
    {
        CurrentDirection.x = Random.value - 0.5f;
        CurrentDirection.y = Random.value - 0.5f;
        CurrentDirection = CurrentDirection.normalized * Random.Range(MinVelocity, MaxVelocity);
    }

    void Update()
    {
        var position = transform.localPosition;
        position = position + CurrentDirection * Time.deltaTime;

        if (position.x < MinX && CurrentDirection.x < 0)
            CurrentDirection.x = -CurrentDirection.x;

        if (MaxX < position.x && 0 < CurrentDirection.x)
            CurrentDirection.x = -CurrentDirection.x;

        if (position.y < MinY && CurrentDirection.y < 0)
            CurrentDirection.y = -CurrentDirection.y;

        if (MaxY < position.y && 0 < CurrentDirection.y)
            CurrentDirection.y = -CurrentDirection.y;

        transform.localPosition = position;
    }
}