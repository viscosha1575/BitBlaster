using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : MonoBehaviour
{
    float nextShot = 0f;
    public float shootingSpeed;
    public float bulletSpeed;
    //public int amountAmmo;
    public GameObject playerBulletPfrefab;
    public GameObject bullets;
    public GameObject[] multiShotSpawnPoints;
    public void ShootRepeating()
    {
        if (Time.time > this.nextShot + this.shootingSpeed)
        {
            this.nextShot = Time.time;

            foreach (GameObject spawnPoint in this.multiShotSpawnPoints)
            {
                GameObject newBullet = GameObject.Instantiate(this.playerBulletPfrefab);
                newBullet.transform.position = spawnPoint.transform.position;
                newBullet.transform.parent = this.bullets.transform;
                Rigidbody2D newBulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
                Vector3 dir = (spawnPoint.transform.position - this.gameObject.transform.position).normalized;
                newBulletRigidbody.AddForce(dir * this.bulletSpeed);
            }
        }


    }
}
