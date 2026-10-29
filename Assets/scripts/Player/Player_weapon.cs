using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_weapon : MonoBehaviour
{

    //to make thing rotate
    float angle;
    Vector2 LookingDir;
    Vector2 mousePos;
    [SerializeField] Camera cam;
    Rigidbody2D rb;

    [Space(20)]
    //weapon thing
    public bool bow;
    public bool gun;
    public bool bash;
    public GameObject bowObject;
    public GameObject gunObject;
    public GameObject bashObject;
    [SerializeField] GameObject bowBullet;
    [SerializeField] GameObject bowPoint;
    [SerializeField] GameObject GunBullet;
    [SerializeField] GameObject gunPoint;

    [Space(20)]
    //stats
    [SerializeField] float bowAtkRate;
    public float bowDmg;

    [SerializeField] float gunAtkRate;
    public float gunDmg;

    [SerializeField] float bashAtkRate;
    public float bashDmg;


    //player thing
    [Space(20)]
    [SerializeField] GameObject player;
    Rigidbody2D playerRB;

    //other stuff
    float atkNow;
    
    bool canBash = true;
    [SerializeField] float bashPower;
    float bashTimr = 0.2f;

    gamemanager gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRB = player.GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Player_cameraFollow>().GetComponent<Camera>();
        gamemanager = FindObjectOfType<gamemanager>().GetComponent<gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gamemanager.gameStart)
        {
            rotateObject();
            attack();

            if (atkNow > 0)
            {
                atkNow -= Time.deltaTime;
            }
        }
    }

    void attack()
    {
        #region set active stuff
        if (bow)
        {
            bowObject.SetActive(true);
            gunObject.SetActive(false);
            bashObject.SetActive(false);
        }
        if (gun)
        {
            gunObject.SetActive(true);
            bowObject.SetActive(false);
            bashObject.SetActive(false);
        }
        if (bash)
        {
            bashObject.SetActive(true);
            gunObject.SetActive(false);
            bowObject.SetActive(false);
        }
        #endregion
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (bow && atkNow <= 0)
            {
                Instantiate(bowBullet, bowPoint.transform.position, transform.rotation);
                atkNow = bowAtkRate;
            }
            if (gun && atkNow <= 0)
            {
                Instantiate(GunBullet, gunPoint.transform.position, transform.rotation);
                atkNow = gunAtkRate;
            }
            if (bash && canBash)
            {
                StartCoroutine(Dash());
            }
            
        }
    }

    void rotateObject()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        LookingDir = mousePos - rb.position;
        angle = Mathf.Atan2(LookingDir.y, LookingDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private IEnumerator Dash()
    {
        canBash = false;
        playerRB.velocity = LookingDir * bashPower;
        yield return new WaitForSeconds(bashTimr);
        playerRB.velocity = new Vector2(0,0f);
        yield return new WaitForSeconds(bashAtkRate);
        canBash = true;
    }

}
