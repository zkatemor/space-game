using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject scoreLabel, startButton, menu;
    private int score = 0;
    private bool isStarted = false;

    public void incScore(int increment)
    {
        score += increment;
        scoreLabel.GetComponent<UnityEngine.UI.Text>().text = "Score:" + " " + score;
    }

    public bool isStartedAlready()
    {
        return isStarted;
    }

    // Start is called before the first frame update
    void Start()
    {
        startButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        {
            menu.SetActive(false);
            isStarted = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
