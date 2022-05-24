using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private int _floorNumber;
    public int FloorNumber => _floorNumber;

    [SerializeField] private ElevatorDestination _elevatorDestination;

    public ElevatorDestination Destination => _elevatorDestination;
}
