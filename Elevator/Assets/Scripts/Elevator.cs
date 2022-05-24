using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    
    public static event System.Action<bool, int> OnFloorArrived;
    private float _speed = 2f;
    private int _currentFloor;
    private int _targetFloor;
    private bool _isMoving;

    private bool _isPhotocellCollided;
    public List<Floor> _floors;
    private float _timeToLaunch = 2f;

    private float _buttonReactDelay;

    private void Awake() 
    {
        _currentFloor = 0;
        _targetFloor = 0;
        _buttonReactDelay = 0;
        _isMoving = false;
        _isPhotocellCollided = false;
        Photocell.OnPhotocellCollided += Photocell_OnPhotocellCollided;
    }

    private void Update() 
    {
        if (_currentFloor != _targetFloor && !_isPhotocellCollided)
        {
            _isMoving = true;
            Move(_floors[_targetFloor].Destination.transform.position);           
        }
        if (_buttonReactDelay > 0)
        {
            _buttonReactDelay -= Time.deltaTime;
        }

    }
    
    public void Move(Vector3 targetPosition) 
    {
        OnFloorArrived?.Invoke(false, _targetFloor);
        
        _timeToLaunch -= Time.deltaTime;

        if (_timeToLaunch <= 0f)
        {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        if (transform.position == targetPosition)
            {
                _currentFloor = _targetFloor;
                _isMoving = false;
                OnFloorArrived?.Invoke(true, _targetFloor);
                _timeToLaunch = 2f;
                _buttonReactDelay = 2f;
            }
        }
    }

    public void SetFloor(int destinationFloor)
    {        
        if (_isMoving == false && _buttonReactDelay <= 0f)
        {
            if (destinationFloor == _currentFloor)
            {
                OnFloorArrived?.Invoke(true, _currentFloor);
            }
            else
            {
                _targetFloor = destinationFloor;
            }
        }
    }

    private void Photocell_OnPhotocellCollided(bool collided, int floor)
    {
        if (collided)
        {
            _isPhotocellCollided = true;
        }
        else
        {
            _isPhotocellCollided = false;
        }
    }

   
  

}
