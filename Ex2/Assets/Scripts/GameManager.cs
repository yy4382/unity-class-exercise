using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool mouseMode = true;
    public int touchedEnemy = 0;
    public int eggOnScreen = 0;
    public int enemyCount = 0;
    public int enemyKilled = 0;
    public Bounds worldBound;

    public Text gameInfo = null;

    /// <summary>
    /// Generates a new enemy object at a random position within the world bounds. Updates the enemy count.
    /// </summary>
    public void GenerateEnemy()
    {
        GameObject enemy = Instantiate(Resources.Load("Prefabs/Plane"),
            new Vector3(Random.Range(worldBound.min.x * 0.9f, worldBound.max.x * 0.9f),
                Random.Range(worldBound.min.y * 0.9f, worldBound.max.y * 0.9f), 0),
            Quaternion.identity) as GameObject;
        enemyCount++;
    }
    void Start()
    {
        worldBound = Camera.main.GetComponent<CameraSupport>().GetWorldBound();
        for (int i = 0; i < 10; i++)
        {
            GenerateEnemy();
        }
        Debug.Assert(gameInfo != null);
    }

    void Update()
    {
        string heroInfo = "HERO: Drive(" + (mouseMode ? "Mouse" : "Key") + ") Touched Enemy (" + touchedEnemy + ")";
        string eggInfo = "EGG: OnScreen(" + eggOnScreen + ")";
        string enemyInfo = "ENEMY: Count(" + enemyCount + ") Destroyed(" + enemyKilled + ")";
        gameInfo.text = heroInfo + "      " + eggInfo + "      " + enemyInfo;
    }

    /// <summary>
    /// Increases the count of enemy killed and generates a new enemy.
    /// </summary>
    public void EnemyKill()
    {
        enemyKilled++;
        enemyCount--;
        GenerateEnemy();
    }
    public void ChangeMouseMode()
    {
        mouseMode = !mouseMode;
    }
}
