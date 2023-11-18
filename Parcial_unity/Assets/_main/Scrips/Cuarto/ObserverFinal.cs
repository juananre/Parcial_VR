using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObserverFinal : MonoBehaviour
{
    [SerializeField] private UnityEvent escritoro;
    [SerializeField] private UnityEvent espejo;
    [SerializeField] private UnityEvent cuadro;
    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("escritoro"))
        {
            escritoro.Invoke();   
        }
        if (other.CompareTag("espejo"))
        {
            espejo.Invoke();
        }
        if (other.CompareTag("cuadro"))
        {
            cuadro.Invoke();
        }
        
    }

}
