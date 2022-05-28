using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private Vector2 movement;
    private GameObject target;
    public Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        target = GameObject.Find("Player");
    }
    void FixedUpdate()
    { 
        body.velocity = Vector2.zero;
        Vector3 dir = target.transform.position - transform.position;
        transform.position += dir.normalized * moveSpeed * Time.fixedDeltaTime;
    }
}
