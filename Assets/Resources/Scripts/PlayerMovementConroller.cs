using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementConroller : MonoBehaviour
{
    public float defaultMovementSpeed;
    public float extraAccelerationSpeed;
    public float breakingFactor;
    public float defaultTurnSpeed;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void FixedUpdate()
    {
        float movementSpeed = this.defaultMovementSpeed;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // accselorate
        {
            movementSpeed += this.extraAccelerationSpeed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) //beak
        {
            movementSpeed *= this.breakingFactor;
        }
        this.transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // turn left
        {
            this.transform.Rotate(Vector3.forward, this.defaultTurnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // turn right
        {
            this.transform.Rotate(-Vector3.forward, this.defaultTurnSpeed * Time.deltaTime);
        }
    }
}
