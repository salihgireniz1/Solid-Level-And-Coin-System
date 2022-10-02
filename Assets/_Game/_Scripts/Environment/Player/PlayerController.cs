using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(IHandleInput))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] ForceMode forceMode;
    Rigidbody body;
    IHandleInput inputHandler;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        inputHandler = GetComponent<IHandleInput>();
    }
    private void FixedUpdate()
    {
        // Move character..
        Move(inputHandler.GiveInput());
    }
    public void Move(Vector3 input)
    {
        Vector3 force = input * speed * Time.fixedDeltaTime;
        body.AddForce(force, forceMode);
    }
}
