using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum MoveStrategy
{
    Straight,
    Loop,
    Chain,
    Random
}

public class Movable : MonoBehaviour
{
    private const float Epsilon = 0.01f;
    
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private MoveStrategy moveStrategy;
    [SerializeField, Range(0, 10)] private float speed;
    [SerializeField, Range(0, 10)] private float stayDelay;

    private bool forward;
    private bool onTheWay = true;
    private int nextWaypointIndex;
    private float timeRemaining;

    private void FixedUpdate()
    {
        if (nextWaypointIndex == -1)
            return;
        if (onTheWay)
        {
            Vector3 direction = (waypoints[nextWaypointIndex].localPosition - transform.position).normalized;
            transform.position += speed * Time.fixedDeltaTime * direction;
            if (Vector3.Distance(waypoints[nextWaypointIndex].localPosition, transform.position) < Epsilon * speed)
            {
                transform.position = waypoints[nextWaypointIndex].localPosition;
                OnWaypointReached();
            }
        }
        else
        {
            timeRemaining -= Time.fixedDeltaTime;
            if (timeRemaining <= 0)
            {
                OnNextStep();
            }
        }
    }

    private void OnNextStep()
    {
        switch (moveStrategy)
        {
            case MoveStrategy.Straight:
                nextWaypointIndex++;
                if (nextWaypointIndex >= waypoints.Count)
                    nextWaypointIndex = -1;
                break;
            case MoveStrategy.Loop:
                nextWaypointIndex++;
                if (nextWaypointIndex >= waypoints.Count)
                    nextWaypointIndex = 0;
                break;
            case MoveStrategy.Chain:
                if (forward)
                {
                    nextWaypointIndex++;
                    if (nextWaypointIndex >= waypoints.Count)
                    {
                        forward = !forward;
                        nextWaypointIndex--;
                    }
                }
                else
                {
                    nextWaypointIndex--;
                    if (nextWaypointIndex < 0)
                    {
                        forward = !forward;
                        nextWaypointIndex++;
                    }
                }
                break;
            case MoveStrategy.Random:
                nextWaypointIndex = UnityEngine.Random.Range(0, waypoints.Count);
                break;
        }
        onTheWay = true;
    }

    private void OnWaypointReached()
    {
        timeRemaining = stayDelay;
        onTheWay = false;
    }
}
