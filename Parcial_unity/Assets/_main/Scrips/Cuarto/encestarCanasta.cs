using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class encestarCanasta : MonoBehaviour
{
    public TextMeshProUGUI contadorText;
    private int contadorCanastas = 0;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Pelota"))
        {
            contadorCanastas++;
                        
            Debug.Log("¡Canasta! Contador: " + contadorCanastas);
            contadorText.text = contadorCanastas.ToString();
        }
    }
}
