using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]private int _enemyhealth = 100;

    [SerializeField] private GameObject _Droneexplosion;

    [SerializeField] private AudioClip enemyExplosion;

    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }


    public void DealDamage(int _damageAmount)
    {
        _enemyhealth -= _damageAmount;

        if (_enemyhealth <= 0)
        {
            

            Instantiate(_Droneexplosion, transform.position, Quaternion.identity);

            _uiManager.UpdateScore();


            AudioSource.PlayClipAtPoint(enemyExplosion, Camera.main.transform.position, 1f);

            Destroy(this.gameObject);
        }
    }

    



}//class
