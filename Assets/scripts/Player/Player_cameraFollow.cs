using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_cameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;   
    }

    
    void Update()
    {

        float playerr = FindObjectsOfType<Player>().Length;

        if (playerr > 0)
        {
            player = FindObjectOfType<Player>().gameObject;
            Vector3 plus = new Vector3(0, 0, -10);
            transform.position = player.transform.position + plus;
        }
    }
}
