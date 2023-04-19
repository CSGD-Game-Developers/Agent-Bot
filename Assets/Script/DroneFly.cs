using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DroneFly : MonoBehaviour
{
    private GameObject Player;
    private float Currentdistance;
    public float _distanceRange;

    [SerializeField] private float _droneSpeed = 10f;
    [SerializeField]private GameObject _drone;

    private Animator animator;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        animator = _drone.GetComponent<Animator>();
        animator.SetTrigger("isFower"); 
    }

    private void Update()
    {
        if (Player != null && transform.position.z > 1f)
        {
            chase();  
            
        }
    }

    private void chase()
    {
        
        
       // animator.SetBool("isFower",false); 
        Currentdistance = Vector3.Distance(transform.position, Player.transform.position);

        if (Currentdistance > _distanceRange)
        {   
             transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 2f * _droneSpeed * Time.deltaTime);
            //animator.SetBool("isFower", true);
    
        }
        else
        {
            animator.SetTrigger("ForwerBreak");
            
        }
        
       
    }

}
