using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class taskManager : MonoBehaviour
{
    public TextMeshProUGUI enunciadoCestasText;
    public TextMeshProUGUI enunciadoHitsText;

    void Update()
    {
        VerificarCondicionesTachado();
    }

    void VerificarCondicionesTachado()
    {        
        if (enunciadoCestasText != null && enunciadoCestasText.fontStyle == FontStyles.Strikethrough)
        {            
            Debug.Log("El texto de las cestas está tachado");
        }
                
        if (enunciadoHitsText != null && enunciadoHitsText.fontStyle == FontStyles.Strikethrough)
        {            
            Debug.Log("El texto de los hits está tachado");
        }
    }
}
