using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public float basicDuration;
    public bool powerUpActive = true;
    public MultiShot multiShot;
    float activeUntilTime = 10;
    public GameObject laser;
    public GameObject burserModeCircle;
    string powerUpType = "multiShot";

    void Start()
    {
        this.burserModeCircle.SetActive(false);
    }

    void FixedUpdate()
    {
        if (powerUpActive && Time.time < this.activeUntilTime)
        {
            if (this.powerUpType == "multiShot")
            {
                this.multiShot.ShootRepeating();
            }
            else if (this.powerUpType == "laser")
            {
                this.laser.SetActive(true);
            }
            else if (this.powerUpType == "burserk")
            {
                this.burserModeCircle.SetActive(true);
            }
        }
        else
        {
            this.powerUpType = null;
            this.powerUpActive = false;
        }
        if (this.powerUpType != "laser")
        {
            this.laser.SetActive(false);
        }else if (this.powerUpType != "burserk")
        {
            this.burserModeCircle.SetActive(false);
        }
    }
    public void ActivateMultiShot()
    {
        this.powerUpActive = true;
        this.powerUpType = "multiShot";
        this.activeUntilTime = Time.time + this.basicDuration;
    }
    public void ActivateLaser()
    {
        this.powerUpActive = true;
        this.powerUpType = "laser";
        this.activeUntilTime= Time.time + this.basicDuration;
    }
    public void ActivateBurserMode()
    {
        this.powerUpActive = true;
        this.powerUpType = "burserk";
        this.activeUntilTime = Time.time + this.basicDuration;
    }
}
