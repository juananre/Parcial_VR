using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Observer : MonoBehaviour
{
    [SerializeField] private UnityEvent myTrigerr;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Objetec"))
        {
            myTrigerr.Invoke();
            other.gameObject.SetActive(false);
        }
    }
}
