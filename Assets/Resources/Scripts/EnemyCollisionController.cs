using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    Enemies2 enemiesScript;
    private void Awake()
    {
        GameObject gaOb = GameObject.FindGameObjectWithTag("EnemySpawnGameObject");
        this.enemiesScript = gaOb.GetComponent<Enemies2>();
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OuterBorder")
        {
            this.enemiesScript.currentEnemiesAmmount--;
            Destroy(this.transform.parent.gameObject);
            Debug.Log("TEST");

        }
    }
}
