using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    [SerializeField] float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
}
