using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingConroller : MonoBehaviour
{
    public float shootingSpeed;
    public float bulletSpeed;
    public int amountAmmo;
    public GameObject playerBulletPfrefab;
    public GameObject bullets;
    public Transform spawnPoint;
    public Text ammoText;
    //public float LifeTime;
    float nextShot = 0;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > this.nextShot && this.amountAmmo > 0)
        {
            this.Shoot();
        }
    }
    private void FixedUpdate()
    {
        this.ammoText.text = this.amountAmmo.ToString();

    }
    void Shoot()
    {
        this.nextShot = Time.time + this.shootingSpeed; // shooting cooldown
        GameObject newBullet = GameObject.Instantiate(this.playerBulletPfrefab);
        newBullet.transform.position = this.spawnPoint.position;
        newBullet.transform.parent = this.bullets.transform;
        Rigidbody2D newBulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
        newBulletRigidbody.AddForce(this.transform.up * this.bulletSpeed);
        this.amountAmmo--;
        //Destroy(this.playerBulletPfrefab, LifeTime);
    }
}
