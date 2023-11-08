using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ManagerPiezas : ControlTiempo
{
    [SerializeField] int Count = 0;

    [Header("Pistas y mensajes")]
    [SerializeField] GameObject imagen1;
    [SerializeField] GameObject imagen2;
    [SerializeField] GameObject imagen3;


    [Header("puerta")]
    [SerializeField] GameObject lUZ;
    [SerializeField] GameObject Bloqueo;
    public void Piezas()
    {
        Count++;
        
        if (Count == 1)
        {
            print(1);
            imagen1.SetActive(true);
        }
        if (Count == 2)
        {
            print(2);
            imagen2.SetActive(true);    
        }
        if (Count >= 3)
        {
            print(3);
            imagen3.SetActive(true);
            lUZ.SetActive(true);
            Bloqueo.SetActive(false);
            pusartiempo();
        }

    }
}
