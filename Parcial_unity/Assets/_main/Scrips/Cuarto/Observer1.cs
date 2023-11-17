using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Observer1 : MonoBehaviour
{
    [SerializeField] private UnityEvent tom;
    [SerializeField] private UnityEvent lowtom;
    [SerializeField] private UnityEvent snare;
    [SerializeField] private UnityEvent hihat;
    [SerializeField] private UnityEvent cymbal;
    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Tom"))
        {
            tom.Invoke();   
        }
        if (other.CompareTag("lowtom"))
        {
            lowtom.Invoke();
        }
        if (other.CompareTag("snare"))
        {
            snare.Invoke();
        }
        if (other.CompareTag("hihat"))
        {
            hihat.Invoke();
        }
        if (other.CompareTag("cymbal"))
        {
            cymbal.Invoke();
        }
    }

}
