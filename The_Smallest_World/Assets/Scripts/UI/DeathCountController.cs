using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DeathCountController : MonoBehaviour
{
    private static DeathCountController instance = null;

    [SerializeField]
    private int deathCount = 0;
    [SerializeField]
    private int finalDeathCount = 0;

    [HideInInspector]
    public UnityEvent OnRespawnPlayer = new UnityEvent();

    public static DeathCountController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (DeathCountController)FindObjectOfType(typeof(DeathCountController));
                if (instance == null)
                {
                    instance = (new GameObject("DeathCounter")).AddComponent<DeathCountController>();
                }
            }
            return instance;
        }
    }

    void Start()
    {
        Instance.OnRespawnPlayer.AddListener(OnHandleRespawnPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelCompleeted.Instance.gameCompelete)
        {
            gameObject.GetComponent<Text>().text = "Death Count: " + deathCount.ToString();
        }
        else
        {
            finalDeathCount = deathCount;
            LevelCompleeted.Instance.FinalDeath.GetComponent<Text>().text = "Total Deaths: " + finalDeathCount.ToString();
        }
    }

    private void OnHandleRespawnPlayer()
    {
        deathCount++;
        GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
