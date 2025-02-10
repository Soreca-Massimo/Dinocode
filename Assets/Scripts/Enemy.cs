using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float acceleration = 6f;
    public float maxSpeed = 8f;
    public Vector2 velocity;
    public Vector2 direction;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = target.position - this.transform.position;
        direction.Normalize();

        velocity += acceleration * Time.deltaTime * direction;
        velocity = Vector2.ClampMagnitude(velocity, maxSpeed);

        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
