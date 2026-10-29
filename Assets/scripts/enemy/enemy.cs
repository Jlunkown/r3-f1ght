using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Player_weapon weapon;
    GameObject player;

    Rigidbody2D enemyrb;

    [SerializeField] float enemyHp;
    [SerializeField] float stoppingDistance;
    [SerializeField] float speed;
    [SerializeField] float atkRate;
    public float enemyAtk;

    [Space(20)]
    [SerializeField] GameObject enemyBullet;
    [SerializeField] GameObject enemyShootPoint;

    float atkNow;


    // Start is called before the first frame update
    void Start()
    {
        weapon = FindObjectOfType<Player_weapon>().GetComponent<Player_weapon>();
        player = FindObjectOfType<Player>().gameObject;

        enemyrb = GetComponent<Rigidbody2D>();

        atkNow = atkRate;
    }

    // Update is called once per frame
    void Update()
    {
        float playerr = FindObjectsOfType<Player>().Length;
        
        if (playerr > 0)
        {
            player = FindObjectOfType<Player>().gameObject;
            moving();
            die();
        }
        if (playerr <= 0)
        {
            Destroy(gameObject);
        }
    }

     void die()
    {
        if (enemyHp <= 0)
        {
            Destroy(gameObject);
        }
    }
    void moving()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > stoppingDistance)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, player.transform.position) < stoppingDistance && atkNow <= 0)
            {
                Instantiate(enemyBullet, enemyShootPoint.transform.position, transform.rotation);
                atkNow = atkRate;
            }
        }
        if (atkNow > 0)
        {
            atkNow -= Time.deltaTime;
        }

        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        enemyrb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("arrow"))
        {
            enemyHp -= weapon.bowDmg;
        }
        if (collision.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            enemyHp -= weapon.gunDmg;
        }
        if (collision.CompareTag("bash"))
        {
            enemyHp -= weapon.bashDmg;
        }
    }

}
