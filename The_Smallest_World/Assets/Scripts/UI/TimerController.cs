using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    private float secondSingle = 0;
    [SerializeField]
    private int secondTen = 0;
    [SerializeField]
    private int minuteSingle = 0;
    [SerializeField]
    private int minuteTen = 0;
    [HideInInspector]
    private bool wayTooLong = false;

    // Update is called once per frame
    void Update()
    {
        if (!LevelCompleeted.Instance.gameCompelete)
        {
            secondSingle += Time.deltaTime;

            if (secondSingle >= 10)
            {
                secondSingle = 0;
                secondTen++;
            }
            if (secondTen >= 6)
            {
                secondTen = 0;
                minuteSingle++;
            }
            if (minuteSingle >= 10)
            {
                minuteSingle = 0;
                minuteTen++;
            }
            if (minuteTen >= 6)
            {
                wayTooLong = true;
            }
        }

        if (!wayTooLong && !LevelCompleeted.Instance.gameCompelete)
        {
            gameObject.GetComponent<Text>().text = minuteTen.ToString() + minuteSingle.ToString() + ":" + secondTen.ToString() + secondSingle.ToString();
        }
        else if(LevelCompleeted.Instance.gameCompelete)
        {
            LevelCompleeted.Instance.FinalTime.GetComponent<Text>().text = "Total Time: " + minuteTen.ToString() + minuteSingle.ToString() + ":" + secondTen.ToString() + secondSingle.ToString();
        }
        else
        {
            gameObject.GetComponent<Text>().text = "How did this take you an hour?";
        }
    }
}
