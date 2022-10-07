using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float velocity;

    private Vector3 direction;

    public int spriteRotation;

    public void Init(float vel, Vector3 dir)
    {
        velocity = vel;
        direction = dir;
    }

    public void Move()
    {
        transform.position = transform.position + velocity * direction * Time.deltaTime;
    }

    public void Move(float vel, Vector3 dir)
    {
        transform.position = transform.position + vel * dir * Time.deltaTime;
    }

    public void Move(Vector3 dir)
    {
        transform.position = transform.position + velocity * dir * Time.deltaTime;
    }

    public void MoveRB(Vector3 dir)
    {
        GetComponent<Rigidbody2D>().MovePosition(transform.position + velocity * dir * Time.fixedDeltaTime);
    }

    public void RotateDirection(Vector3 dir, float initialRotation)
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - initialRotation);
    }

    public void MoveVelocity(Vector3 dir)
    {
        GetComponent<Rigidbody2D>().velocity = dir;
    }
}
