using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionController : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    public CollectionController collectionController;
    void Start()
    {
        this.player = this.transform.parent.gameObject;
        this.playerHealth = this.player.GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "InnerBorder")
        {
            print("destoy player");
            this.playerHealth.DestoyShip();

        }
        else if (collision.gameObject.tag == "EnemyCollider")
        {
            print("Enemy toched");
            this.playerHealth.TakeDamage();
        }
        else if(collision.gameObject.tag == "Collectible")
        {
            this.collectionController.Collect(collision.gameObject);
        }
    }
}
