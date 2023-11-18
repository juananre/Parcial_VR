using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class encestarCanasta : MonoBehaviour
{
    public TextMeshProUGUI contadorText;
    public TextMeshProUGUI tareaCestaText;
    private int contadorCanastas = 0;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Pelota"))
        {
            contadorCanastas++;
                        
            Debug.Log("¡Canasta! Contador: " + contadorCanastas);
            contadorText.text = "Cestas: " + contadorCanastas.ToString();

            if (contadorCanastas >= 5)
            {                
                tareaCestaText.fontStyle = FontStyles.Strikethrough;
            }
        }
    }
}
