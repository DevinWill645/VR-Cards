using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Plan, Draw, Standby }
    public static GameManager Instance { get; private set; }
    public GameState currentState = GameState.Plan;
    public PrefabSpawner prefabSpawner;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        prefabSpawner = FindObjectOfType<PrefabSpawner>();
    }

    public void Draw(bool isFirstDraw)
    {
        Debug.Log("Inside Draw");
        if (currentState == GameState.Draw)
        {
            if (prefabSpawner.initialSpawn)
            {
                prefabSpawner.SpawnPrefabs(isFirstDraw ? 6 : 5);
                prefabSpawner.initialSpawn = false;
            }
            else
            {
                prefabSpawner.SpawnPrefabs(1);
            }

            currentState = GameState.Standby;
        }
    }
}