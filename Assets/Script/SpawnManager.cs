using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject droneEnemy1, droneEnemy2;

    [SerializeField] Transform _Enemy_Drop1;
    [SerializeField] Transform _Enemy_Drop2;

    private int xPos, yPos;

    [SerializeField] int enemyCount;

    public bool gamveOver = false;

    public static SpawnManager instance;

    float timer;
    float ranTime;


    void Start()
    {
        instance = this;
        ranTime = Random.Range(2, 5);

    }

    private void Update()
    {
        ranTime = Random.Range(5, 12);
        timer += Time.deltaTime;

        if (!gamveOver && timer > ranTime)
        {
            EnemyDrop1();
            EnemyDrop2();
            timer = 0;
        }

    }

    void EnemyDrop1()
    {
        //while (enemyCount < 40)
        {
           //  int range = Random.Range(0, _Enemy_Drop1.Length);

            Instantiate(droneEnemy1, _Enemy_Drop1.position, Quaternion.Euler(0f, 180f, 0f));
            enemyCount += 1;

        }
    }//drone1Spawn

    void EnemyDrop2()
    {
        //while (enemyCount < 20)
        //{
        //int range = Random.Range(0, _Enemy_Drop2.Length);

        Instantiate(droneEnemy2, _Enemy_Drop2.position, Quaternion.Euler(0f, 180f, 0f));

        //yield return new WaitForSeconds(20f);
        enemyCount += 1;
        //}
    }//drone2Spawn
}
