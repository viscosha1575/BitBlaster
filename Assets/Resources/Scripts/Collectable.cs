using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public float duration;
    float Killtime;
    public float blinkingTime;
    bool isBlinking = false;
    public string collectableType;
    SpriteRenderer collectableSprite;

    void Start()
    {
        this.Killtime = Time.time + this.duration;
        this.collectableSprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if ((Time.time > this.Killtime - this.blinkingTime) && !this.isBlinking)
        {
            StartCoroutine(this.Blink());
            this.isBlinking = true;
        }
        if (Time.time > this.Killtime)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator Blink()
    {
        for (int i = 0; i< 4; i++)
        {
            this.collectableSprite.enabled = false;
            yield return new WaitForSeconds(0.25f);
            this.collectableSprite.enabled = true;
            yield return new WaitForSeconds(0.25f);
        }
    }

    public static Collectable CreateAmmo()
    {
        GameObject ammo = (GameObject)Instantiate(Resources.Load("Prefabs/Ammo"));
        return ammo.GetComponent<Collectable>();
    }
    public static Collectable CreateShield()
    {
        GameObject shield = (GameObject)Instantiate(Resources.Load("Prefabs/Shield"));
        return shield.GetComponent<Collectable>();
    }
    public static Collectable CreateLaser()
    {
        GameObject laser = (GameObject)Instantiate(Resources.Load("Prefabs/Laser"));
        return laser.GetComponent<Collectable>();
    }
    public static Collectable CreateBomb()
    {
        GameObject bomb = (GameObject)Instantiate(Resources.Load("Prefabs/Bomb"));
        return bomb.GetComponent<Collectable>();
    }
    public static Collectable CreateBersekMode()
    {
        GameObject bersek = (GameObject)Instantiate(Resources.Load("Prefabs/Bersek"));
        return bersek.GetComponent<Collectable>();
    }
    public static Collectable CreateMultiShot()
    {
        GameObject multiShot = (GameObject)Instantiate(Resources.Load("Prefabs/MultiShot"));
        return multiShot.GetComponent<Collectable>();
    }

}
