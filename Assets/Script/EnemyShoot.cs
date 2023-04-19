using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulatprefabs;
    public Transform BolatPoint;
    public float bulatSpeed;

    public GameObject Playar;

    [SerializeField]private float timer;

    private void Start()
    {
        Playar = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        if(!SpawnManager.instance.gamveOver)
            Shoot();
    }

    private void Shoot()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            

            GameObject bulat = Instantiate(bulatprefabs, BolatPoint.position, Quaternion.Euler(0, -90f, 0));
            timer = 0;
            bulat.GetComponent<Rigidbody>().velocity = BolatPoint.forward * bulatSpeed;

            Destroy(bulat.gameObject, 9f);
        }
        

        if (Playar != null)
        {
            BolatPoint.LookAt(Playar.transform.position);
        }
    }
}