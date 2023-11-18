using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class taskManager : MonoBehaviour
{
    public TextMeshProUGUI enunciadoCestasText;
    public TextMeshProUGUI enunciadoHitsText;
    public TextMeshProUGUI enunciadoCajasText;

    public GameObject primeraUI;
    public GameObject urgenteUI;

    public GameObject cuadroCollider;
    public GameObject escritorioCollider;
    public GameObject espejoCollider;


    public GameObject objSnap;
    public GameObject objSnap2;
    public GameObject objSnap3;
    public GameObject objSnap4;


    public AudioSource audioSource;
    public AudioSource audioSourceAlarma;    

    public Light blue;
    public Light red;

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
            CambiarUI();
            Ilum();
            PrenderFinal();
        }
    }

    void ReproducirAlarma()
    {        
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSourceAlarma.enabled = true;
            audioSourceAlarma.Play();
        }
    }

    void CambiarUI()
    {
        primeraUI.SetActive(false);
        urgenteUI.SetActive(true);
    }

    void Ilum()
    {        
        red.enabled = true;
    }

    void PrenderFinal()
    {
        cuadroCollider.SetActive(true);
        escritorioCollider.SetActive(true);
        espejoCollider.SetActive(true);
    }
}
