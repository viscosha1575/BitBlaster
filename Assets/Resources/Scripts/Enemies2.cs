using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies2 : MonoBehaviour
{
    public GameObject[] spawnAreas;
    public int maxEnemiesOnStart;
    public int xtraEnemiesPerTotal;
    public int currentEnemiesAmmount = 0;
    public int totalEnemiesAmmount = 0;
    int maxEnemies;
    void Update()
    {
        this.maxEnemies = this.maxEnemiesOnStart + this.totalEnemiesAmmount / this.xtraEnemiesPerTotal;
        if (this.currentEnemiesAmmount < this.maxEnemies)
        {
            this.SpawnRndEnemy();
        }
    }
    void Start()
    {
        InvokeRepeating("SpawnRndEnemy", 0f, 2f);
    }
    public void SpawnRndEnemy()
    {

        GameObject spawnArea = spawnAreas[Random.Range(0, spawnAreas.Length)];      // Случайно выбираем область спавна из массива spawnAreas
        GameObject enemyObject = Instantiate(Resources.Load("Prefabs/Enemy"), GetSpawnPos(spawnArea), Quaternion.identity) as GameObject;     // Создаем экземпляр префаба врага

        CreateEnemy enemy = enemyObject.GetComponent<CreateEnemy>();      // Получаем скрипт CreateEnemy из созданного префаба
        float v = Random.value;
        if (v >= 0.5f)
        {
            enemy = CreateEnemy.GetNewPrimitive();
        }
        else if (v >= 0.2f)
        {
            enemy = CreateEnemy.GetNewSplitter();
        }
        else
        {
            enemy = CreateEnemy.GetNewShooter();
        }
        SetupNewEnemy(enemy, spawnArea);      // Настройка параметров врага
        currentEnemiesAmmount++;       // Увеличиваем счетчики
        totalEnemiesAmmount++;
    }
    public void SetupNewEnemy(CreateEnemy enemy, GameObject spawnArea = null)
    {
       if (spawnArea == null)
        {
            int i = Random.Range(0, this.spawnAreas.Length);
            spawnArea = this.spawnAreas[i];
        }
        Vector3 spawnPos = GetSpawnPos(spawnArea);
        enemy.transform.position = spawnPos;
        enemy.transform.parent = this.transform;
        EnemyMovementController enemyMovementController = enemy.movementController;
        if (spawnArea.name == "Left")
        {
            enemyMovementController.movementDirection = Vector3.right;
        }
        else if (spawnArea.name == "Right")
        {
            enemyMovementController.movementDirection = Vector3.left;
        }
        else if (spawnArea.name == "Top")
        {
            enemyMovementController.movementDirection = Vector3.down;
        }
        else if (spawnArea.name == "Bottom")
        {
            enemyMovementController.movementDirection = Vector3.up;
        }
    }
    Vector3 GetSpawnPos(GameObject spawnArea)
    {
         Vector3 scale = spawnArea.transform.localScale;
        float x = spawnArea.transform.position.x + Random.Range(-scale.x / 2, scale.x / 2);
        float y = spawnArea.transform.position.y + Random.Range(-scale.y / 2, scale.y / 2);
        Vector3 location = new Vector3 (x, y, 0);
        return location;
    }
}
