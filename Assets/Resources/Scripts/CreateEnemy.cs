using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public EnemyMovementController movementController;
    public static CreateEnemy GetNewPrimitive()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Enemy"));
        return enemy.GetComponent<CreateEnemy>();
    }
    public static CreateEnemy GetNewSplitter()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Splitter"));
        return enemy.GetComponent<CreateEnemy>();
    }
    public static CreateEnemy GetNewShooter()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Enemy_shooting"));
        return enemy.GetComponent<CreateEnemy>();
    }
}
