using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalSalida : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.layer == LayerMask.NameToLayer("Manos"))
        {            
            Salir();
        }
    }

    void Salir()
    {
        // Salir de la aplicación
        Application.Quit();

        //Código únicamente pa si se está probando en Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

