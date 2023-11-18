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
        // Salir de la aplicaci�n
        Application.Quit();

        //C�digo �nicamente pa si se est� probando en Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

