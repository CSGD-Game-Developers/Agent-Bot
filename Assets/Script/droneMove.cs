using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneMove : MonoBehaviour
{
    [SerializeField] float moveSpeed =5f;

    private GameObject Player;
    private float Currentdistance;
    public float _distanceRange = 0f;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        chase();
    }

    private void chase()
    {
        Currentdistance = Vector3.Distance(transform.position, Player.transform.position);

        if (Currentdistance > _distanceRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 2f * moveSpeed * Time.deltaTime);

        }
    }
}
