using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photocell : MonoBehaviour
{
    public static event System.Action<bool, int> OnPhotocellCollided;
    [SerializeField] private Floor _floor;

    private void OnTriggerStay(Collider other) 
    {
        OnPhotocellCollided?.Invoke(true, _floor.FloorNumber);    
    }

    private void OnTriggerExit(Collider other) 
    {
        OnPhotocellCollided?.Invoke(false, _floor.FloorNumber);    
    }
}
