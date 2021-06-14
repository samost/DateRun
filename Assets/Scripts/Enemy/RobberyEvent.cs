using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberyEvent : MonoBehaviour
{
    public static RobberyEvent Instance;
    
    private GameObject _walkingGirl;
    

    private GameObject _man;
    
    public static bool isRobbery = false;

    [SerializeField] private float timeUpBar;

    private void Start()
    {
        Instance = this;
        
        _walkingGirl = GameObject.FindGameObjectWithTag("Girl");
        _man = GameObject.FindGameObjectWithTag("Man");
        
        var o = GameObject.FindGameObjectWithTag("GirlOnEnemy");
    }

    public IEnumerator ActivateRobe(MeshRenderer _girlOnEnemy)
    {
        _walkingGirl.SetActive(false);
        _girlOnEnemy.enabled = true;
        isRobbery = true;
        
        while (!isRobbery)
        {
            yield return new WaitForSeconds(timeUpBar);
            BarController.Instance.DeBuff();
        }
    }
}
