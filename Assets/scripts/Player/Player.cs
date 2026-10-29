using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum playerState
{
    land,
    water,
    air
}

public class Player : MonoBehaviour
{
    //stats
    public int speed;
    public int waterSpeed;
    public int flightSpeed;
    public float health;

    [Space(20)]
    //component
    Rigidbody2D playerrb;
    BoxCollider2D playerFeetCollider;
    SpriteRenderer sprite;

    //scripts
    enemy enemy;
    gamemanager gameManager;

    [Space(20)]
    //grab gameobjects
    [SerializeField] Camera cam;

    [Space(20)]
    //vector
    Vector2 movement;
    Vector2 mousePos;

    [Space(20)]
    //other stuff
    [HideInInspector] public playerState state;

    //art
    [Space(20)]
    [SerializeField] Sprite land;
    [SerializeField] Sprite air;
    [SerializeField] Sprite water;

    void Start()
    {
        #region get stuff at start
        playerrb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        cam = FindObjectOfType<Camera>().GetComponent<Camera>();
        gameManager = FindObjectOfType<gamemanager>().GetComponent<gamemanager>();
        #endregion

        #region random stuff

        #endregion

    }

    void Update()
    {
        if (gameManager.gameStart)
        {
            playerMovement();
            die();
        }
    }

    //function
    void playerMovement()
    {
        #region land
        if(state == playerState.land)
        {
            //change sprite
            sprite.sprite = land;
            flightSpeed = 14;

            playerrb.gravityScale = 0;
            //player movement left and right
            //movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            transform.Translate(movement * speed * Time.deltaTime);

            //rotating player
            //transform.rotation = Quaternion.Euler(0,0,0);
        }
        #endregion

        #region water
        if(state == playerState.water)
        {
            //change sprite
            sprite.sprite = water;
            flightSpeed = 14;

            playerrb.gravityScale = 0;
            if (Input.GetKey(KeyCode.W))
            {
                playerrb.AddForce(transform.up * waterSpeed);
            }
        }
        #endregion

        #region air
        if(state == playerState.air)
        {
            //change sprite
            sprite.sprite = air;

            playerrb.gravityScale = 0;
            transform.Translate(Vector2.up * flightSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                flightSpeed /= 4;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                flightSpeed = 14;
            }
        }
        #endregion

        #region player rotating
        if(state == playerState.water || state == playerState.air || state == playerState.land)
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            Vector2 LookingDir = mousePos - playerrb.position;
            float angle = Mathf.Atan2(LookingDir.y, LookingDir.x) * Mathf.Rad2Deg - 90f;
            playerrb.rotation = angle;
        }
        #endregion
    }
    void die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemyBullet"))
        {
            health -= 100;
            Destroy(collision.gameObject);
        }
    }

}
