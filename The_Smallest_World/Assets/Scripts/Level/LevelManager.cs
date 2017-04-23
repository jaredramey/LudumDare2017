using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//TODO: work on level manager
public class LevelManager : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject QuitButton;
    
    void Start()
    {
        StartButton.GetComponent<Button>().onClick.AddListener(OnStartGame);
        QuitButton.GetComponent<Button>().onClick.AddListener(OnQuitGame);
    }

    private void OnStartGame()
    {
        SceneManager.LoadScene("World_Test");
    }

    private void OnQuitGame()
    {
        Application.Quit();
    }
}
