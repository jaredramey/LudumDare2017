using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelCompleeted : MonoBehaviour
{
    private static LevelCompleeted instance = null;

    public bool gameCompelete = false;
    public GameObject Victory, Escape;
    public GameObject FinalTime, FinalDeath;

    public static LevelCompleeted Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (LevelCompleeted)FindObjectOfType(typeof(LevelCompleeted));
                if (instance == null)
                {
                    instance = (new GameObject("VictoryPlatform")).AddComponent<LevelCompleeted>();
                }
            }
            return instance;
        }
    }

    void Start()
    {
        User_InputManager.Instance.OnEscape.AddListener(HandleOnEscape);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameCompelete)
        {
            Victory.gameObject.SetActive(true);
            FinalTime.gameObject.SetActive(true);
            FinalDeath.gameObject.SetActive(true);
            Escape.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            gameCompelete = true;
        }
    }

    void HandleOnEscape()
    {
        SceneManager.LoadScene("Menu_Main");
    }
}
