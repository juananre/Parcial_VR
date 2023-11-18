using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class taskManager : MonoBehaviour
{
    public TextMeshProUGUI enunciadoCestasText;
    public TextMeshProUGUI enunciadoHitsText;
    public TextMeshProUGUI enunciadoCajasText;

    public AudioSource audioSource;
    public AudioClip alarmaAudio;

    void Update()
    {
        VerifTachado();
    }

    void VerifTachado()
    {
        bool cestasTachadas = enunciadoCestasText != null && enunciadoCestasText.fontStyle == FontStyles.Strikethrough;
        bool hitsTachados = enunciadoHitsText != null && enunciadoHitsText.fontStyle == FontStyles.Strikethrough;
        bool cajasTachadas = enunciadoCajasText != null && enunciadoCajasText.fontStyle == FontStyles.Strikethrough;

        // Ya cumplió las tres tareas
        if (cestasTachadas && hitsTachados && cajasTachadas)
        {            
            ReproducirAlarma();
        }
    }

    void ReproducirAlarma()
    {        
        if (audioSource != null)
        {
            audioSource.Stop();            
            audioSource.clip = alarmaAudio;            
            audioSource.Play();
        }
    }
}
