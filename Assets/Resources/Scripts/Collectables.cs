using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public GameObject powerUpLaser;
    public GameObject powerUpMultiShot;
    public GameObject powerUpBersekMode;

    public GameObject resouceAmmo;
    public GameObject resouceShield;
    public GameObject resouceBomb;

    public float powerUpSpawnChance = 0.1f;
    public void  SpawnRandomCollectable(Transform pos)
    {
        if (Random.value <= this.powerUpSpawnChance)
        {
            this.SpawnRandomPowerUp(pos);
        }
        else
        {
            this.SpawnRandomResource(pos);
        }
    }

    public void SpawnRandomPowerUp(Transform pos)
    {
        float v = Random.value;
        Collectable newCollectable;

        if (v > 0.5f)
        {
            newCollectable = Collectable.CreateMultiShot();
        }
        else if (v < 0.2f)
        {
            newCollectable = Collectable.CreateBersekMode();
        }
        else
        {
            newCollectable = Collectable.CreateLaser();
        }
        newCollectable.gameObject.transform.position = pos.position;
    }
    public void SpawnRandomResource(Transform pos)
    {
        float v = Random.value;
        Collectable newCollectable;

        if (v >= 0.1f)
        {
            newCollectable = Collectable.CreateAmmo();
        }
        else if (v >= 0.05f)
        {
            newCollectable = Collectable.CreateBomb();
        }
        else 
        {
            newCollectable = Collectable.CreateShield();
        }
        newCollectable.gameObject.transform.position = pos.position;
    }
}
