using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    [SerializeField] private Floor _floor;
    private bool _collided;
    private float _openDoorsTimer = 2.5f;

    private void Awake() 
    {
        Elevator.OnFloorArrived += Elevator_OnFloorArrived;    
        Photocell.OnPhotocellCollided += Photocell_OnPhotocellCollided;
        _collided = false;
    }

    private void Update() 
    {
        if (_animator.GetBool("isOpen") == true && _collided == false)
        {
            _openDoorsTimer -= Time.deltaTime;
            if (_openDoorsTimer <= 0f)
            {
                _animator.SetBool("isOpen", false);
                _openDoorsTimer = 4.5f;
            }
        }
        if (_collided)
        {
            _openDoorsTimer = 4.5f;
        }    
    }

    private void Elevator_OnFloorArrived(bool arrived, int floor)
    {
        if(arrived && floor == _floor.FloorNumber)
        {
            _animator.SetBool("isOpen", true);
        }
        else
        {
            _animator.SetBool("isOpen", false);
        }
    }

    private void Photocell_OnPhotocellCollided(bool collided, int floor)
    {
        if(collided && floor == _floor.FloorNumber)
        {
            _collided = true;
            _animator.SetBool("isOpen", true);
        }
        else
        {
            _collided = false;
        }
    }
 
}
