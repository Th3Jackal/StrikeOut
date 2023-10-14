using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    Rigidbody2D rig;

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    public void MoveTransform(Vector3 vel)
    {
        transform.position += vel * speed * Time.deltaTime;
    }

    public void MoveRig(Vector3 vel)
    {
        rig.MovePosition(transform.position + (vel * speed * Time.fixedDeltaTime));
    }
}
