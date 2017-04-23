using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReset : MonoBehaviour
{
    private GameObject spawnPoint;

    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Player")
        {
            DeathCountController.Instance.OnRespawnPlayer.Invoke();
            col.transform.position = spawnPoint.transform.position;
        }
    }
}
