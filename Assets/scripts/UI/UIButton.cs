using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] GameObject startScreen;

    gamemanager gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = FindObjectOfType<gamemanager>().GetComponent<gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playAgain()
    {
        gamemanager.restartGame();
    }
    public void closeStartScreem()
    {
        startScreen.SetActive(false);
        gamemanager.gameStart = true;
    }

}
