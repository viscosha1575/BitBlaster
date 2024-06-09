using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour
{
    public ShootingConroller shooting;
    public PlayerHealth playerHealth;
    public BombController bombController;
    public PowerUpController powerUpController;
    public int ammoAmount;
    public void Collect(GameObject collectable)
    {
        Collectable collectableScript = collectable.GetComponent<Collectable>();
        string collectableType = collectableScript.collectableType;
        if (collectableType == "ammo")
        {
            this.shooting.amountAmmo += ammoAmount;
        }
        else if (collectableType == "shield")
        {
            if(this.playerHealth.ammountShields <= 5)
            {
                this.playerHealth.ammountShields++;
            }
        }
        else if(collectableType == "bomb")
        {
            if (this.bombController.amountBombs <= 5)
            {
                this.bombController.amountBombs++;
            }
        }
        else if (collectableType == "berserk")
        {
            this.powerUpController.ActivateBurserMode();
        }
        else if (collectableType == "multiShot")
        {
            this.powerUpController.ActivateMultiShot();
        }
        else if (collectableType == "laser")
        {
            this.powerUpController.ActivateLaser();
        }
        Destroy(collectable);
    }
}
