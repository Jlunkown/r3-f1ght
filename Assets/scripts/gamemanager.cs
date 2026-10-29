using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamemanager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] GameObject gameOverScreen;

    [Space(20)]
    Player player;
    Player_weapon weapon;
    float randomeNoMovement;
    float randomNoWeapon;

    float noEmemy;
    float noSpawner;
    float noPlayer;
    public int wave = 1;
    int hwave;

    [Space(20)]
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject playerObject;

    public bool gameStart;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        weapon = FindObjectOfType<Player_weapon>().GetComponent<Player_weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            noEmemy = FindObjectsOfType<enemy>().Length;
            noSpawner = FindObjectsOfType<enemySpawner>().Length;
            noPlayer = FindObjectsOfType<Player>().Length;

            if (noEmemy <= 0 && noSpawner <= 0 && noPlayer > 0)
            {
                wave++;
                chooseRandomPlayStyle();
                roundStart(wave);
            }
            if (noPlayer > 0)
            {
                player = FindObjectOfType<Player>().GetComponent<Player>();
                weapon = FindObjectOfType<Player_weapon>().GetComponent<Player_weapon>();
            }

            if (noPlayer == 0)
            {
                gameOverScreen.SetActive(true);
                score.text = "Score: " + wave;
                if (wave >= hwave)
                {
                    hwave = wave;
                }
                highScore.text = "High score: " + hwave;
                wave = 0;
            }
        }
    }

    public void restartGame()
    {
        Instantiate(playerObject, transform.position, transform.rotation);
        for (float i = 0; i < noEmemy; i++)
        {
            Destroy(FindObjectOfType<enemy>().gameObject);
            
        }
        gameOverScreen.SetActive(false);
        chooseRandomPlayStyle();
        wave = 0;
    }

    #region spawn enemy
    public void roundStart(int enemySpawn)
    {
        for (int i = 0; i < enemySpawn; i++)
        {
            Instantiate(spawner, SpawnRandomPos(), transform.rotation);
        }
    }
    private Vector3 SpawnRandomPos()
    {
        float randomPosX = Random.Range(-11, 11);
        float randomPosY = Random.Range(-4, 17);

        Vector2 randomPos = new Vector2(randomPosX, randomPosY);

        return randomPos;
    }
    #endregion

    void chooseRandomPlayStyle()
    {
        randomeNoMovement = Random.Range(0, 3);
        randomNoWeapon = Random.Range(0, 3);

        #region weapon
        if (randomNoWeapon == 0)
        {
            weapon.bash = true;
            weapon.gun = false;
            weapon.bow = false;
        }
        if (randomNoWeapon == 1)
        {
            weapon.bash = false;
            weapon.gun = true;
            weapon.bow = false;
        }
        if (randomNoWeapon == 2)
        {
            weapon.bash = false;
            weapon.gun = false;
            weapon.bow = true;
        }
        #endregion

        #region movement
        if (randomeNoMovement == 0)
        {
            player.state = playerState.land;
        }
        if (randomeNoMovement == 1)
        {
            player.state = playerState.water;
        }
        if (randomeNoMovement == 2)
        {
            player.state = playerState.air;
        }
        #endregion
    }
}
