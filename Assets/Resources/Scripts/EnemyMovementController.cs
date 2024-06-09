using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public Vector3 movementDirection;
    public float movementSpeed;
    public float lifeTime;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void FixedUpdate()
    {
        this.transform.Translate(this.movementDirection * movementSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("OuterBorder"))
        {
            Destroy(this.gameObject);
            Debug.Log("TEST");
        }
    }
}
