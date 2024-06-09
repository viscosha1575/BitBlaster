using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
    public int pointOnPlayerDestruction;
    public bool isSplitter = false;
    Score score;
    Collectables collectables;
    Enemies2 enemiesScript;
    private void Awake()
    {
        GameObject gaOb = GameObject.FindGameObjectWithTag("EnemySpawnGameObject");
        this.enemiesScript = gaOb.GetComponent<Enemies2>();
        this.collectables = GameObject.FindGameObjectWithTag("Collectables").GetComponent<Collectables>();
        this.score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }
    public void DestroyByPlayer()
    {

        score.RaiseScore(this.pointOnPlayerDestruction);
        this.collectables.SpawnRandomCollectable(this.transform);
        this.enemiesScript.currentEnemiesAmmount--;
        Destroy(this.gameObject);
    }
}
