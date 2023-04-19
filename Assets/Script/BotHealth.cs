using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotHealth : MonoBehaviour
{
    [SerializeField]private int _botHealth = 100;

    [SerializeField] private GameObject _botExplosion;

    [SerializeField] private AudioClip botExplosionSound;

    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }


    public void BotDealDamage(int _damageAmount)
    {
        _botHealth -= _damageAmount;

        if (_botHealth == 0)
        {
            

            Instantiate(_botExplosion, transform.position, Quaternion.Euler(-90,0,0));

           _uiManager.UpdateScore();


            AudioSource.PlayClipAtPoint(botExplosionSound, Camera.main.transform.position, 1f);

            Destroy(this.gameObject);
        }
    }

    



}//class
