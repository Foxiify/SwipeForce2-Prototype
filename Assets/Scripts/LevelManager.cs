using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public LevelData[] levelDatas;
    public GameObject ballPrefab;
    public Transform ballSpawnPos;

    private int availableCans, availableBalls; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnLevel();
    }

    public void SpawnBall()
    {
        // Spawner ny ball hvis antallet resterende baller er høyere enn 0
        if (availableBalls > 0)
        {
            GameObject ball = Instantiate(ballPrefab, ballSpawnPos.position, Quaternion.identity);
            SwipeController.instance.TargetObj = ball;
            availableBalls--;
        }
    }

    public void SpawnLevel()
    {
        LevelData level = Instantiate(levelDatas[0], new Vector3(0, 2.5f, 8.5f), Quaternion.identity).GetComponent<LevelData>();
        availableCans = level.canCount;
        availableBalls = level.ballCount;

        SpawnBall();
    }
}

