using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGunScript : MonoBehaviour
{
    [SerializeField] private Camera _fpCamera;

    public int currentAmmo = 0;
    public int maxAmmo = 100;
    public float reloadTime = 2f;
    private bool isReloading = false;


    private int lives = 5;
    public bool isFiring;
    public bool isGameOver;//new

    [SerializeField] private Text _ammoCountDisplay;
    [SerializeField] private float _range = 200f;

    [SerializeField] private ParticleSystem _muzzelFlashLeft, _muzzelFlashRight;
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private GameObject _bulletPrefab;

    //[SerializeField] private AudioSource _fireSound;
    [SerializeField] private AudioClip _bulletHitSound,_fireSound,_reloadSound;
    [SerializeField] private GameObject _bloodOverLay;

    private UIManager _uiManager;
    private AudioSource _audioSource;


    private void Awake()
    {
        Cursor.visible = false;
        isGameOver = false;//new
        // GameOverScreen.SetActive(false);
        _audioSource = GetComponent<AudioSource>();

    }

    private void Start()
    {
        if (currentAmmo == 0)
        {
            currentAmmo = maxAmmo;
        }

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
       // _uiManager.UpdateLives(lives);

    }//Start

    private void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo == 0 && !SpawnManager.instance.gamveOver)
        {
            StartCoroutine(Reload());
            return;
        }

        _ammoCountDisplay.text = currentAmmo.ToString();

        if (Input.GetMouseButtonDown(0) && !isFiring && currentAmmo > 0)
        {
            GunShooting();
        }
    }//Update

    IEnumerator Reload()
    {
        _audioSource.PlayOneShot(_reloadSound);
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;

    }//Reload

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "bulat")
        {
            AudioSource.PlayClipAtPoint(_bulletHitSound, _fpCamera.transform.position, 1f);
            StartCoroutine(PlayerDamage());

        }
        if (target.gameObject.tag == "bot1")
        {
            StartCoroutine(PlayerDamage());
            Destroy(target.gameObject, 3f);
        }
    }


    public IEnumerator PlayerDamage()
    {
        _bloodOverLay.SetActive(true);


        lives--;
        print("reduce lives" + lives);

        _uiManager.UpdateLives(lives);


        if (lives == 0)
        {
            isGameOver = true;//new
            _uiManager.SetGameOver();



            Cursor.visible = true;

        }
        yield return new WaitForSeconds(0.25f);

        _bloodOverLay.SetActive(false);

    }//Player Damage

    private void GunShooting()
    {
        isFiring = true;
        currentAmmo--;
        isFiring = false;
        _muzzelFlashLeft.Play();
        _muzzelFlashRight.Play();
        //_fireSound.Play();
        _audioSource.PlayOneShot(_fireSound);

        RaycastHit _hit;

        if (Physics.Raycast(_fpCamera.transform.position, _fpCamera.transform.forward, out _hit, _range))
        {
            CreateHitImpact(_hit);

            EnemyHealth _target = _hit.transform.gameObject.GetComponent<EnemyHealth>();
            BotHealth _target2 = _hit.transform.gameObject.GetComponent<BotHealth>();

            if (_target != null)
            {
                _target.DealDamage(50);
            }
            else if (_target2 != null)
            {
                _target2.BotDealDamage(100);

            }



        }
    }//Gun Shoot

    private void CreateHitImpact(RaycastHit _hit)
    {
        GameObject _hitImpact = Instantiate(_hitEffect, _hit.point, Quaternion.LookRotation(_hit.normal));
        Destroy(_hitImpact, 0.5f);

    }

}//class
