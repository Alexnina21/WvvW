using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public List<Transform> RoutePoints = new List<Transform>();
    public int ActualPoint;
    public bool Boomerang;
    public bool GoBack;
    public float Velocity;
    private float StoredVelocity;

    void Start()
    {
        if(RoutePoints.Count > 0)
        {
            transform.position = RoutePoints[ActualPoint].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(RoutePoints.Count > 0)
        {
            if(Vector2.Distance(transform.position, RoutePoints[ActualPoint].position) < 0.01f)
            {
                UpdateActualPoint();
            }
            transform.position = Vector2.MoveTowards(transform.position, RoutePoints[ActualPoint].position, Velocity * Time.deltaTime);
        }
    }

    public void UpdateActualPoint()
    {
        ActualPoint++;
        if(ActualPoint == RoutePoints.Count)
        {
            ActualPoint = 0;
        }
    }

    public void SetVelocity(float vel)
    {
        StoredVelocity = Velocity;
        Velocity = vel;
    }

    public void RestoreVelocity()
    {
        Velocity = StoredVelocity;
        StoredVelocity = 0;
    }

}
