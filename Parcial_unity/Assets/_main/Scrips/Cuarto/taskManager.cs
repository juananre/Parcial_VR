using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class taskManager : MonoBehaviour
{
    [Header("txt")]
    public TextMeshProUGUI enunciadoCestasText;
    public TextMeshProUGUI enunciadoHitsText;
    public TextMeshProUGUI enunciadoCajasText;


    [Header("ui")]
    public GameObject primeraUI;
    public GameObject urgenteUI;

    [Header("final")]
    public GameObject cuadroCollider;
    public GameObject escritorioCollider;
    public GameObject espejoCollider;

    [Header("snapzones")]
    public GameObject objSnap;
    public GameObject objSnap2;
    public GameObject objSnap3;
    public GameObject objSnap4;

    [Header("audios")]
    [SerializeField] AudioSource audioSource;
    public AudioClip Alarma;
    [SerializeField] GameObject lolli;

    [Header("luces")]
    [SerializeField] GameObject Lired;
    [SerializeField] GameObject LiBlue;

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
       audioSource.PlayOneShot(Alarma);
       lolli.SetActive(false);
    }

    void CambiarUI()
    {
        primeraUI.SetActive(false);
        urgenteUI.SetActive(true);
    }

    void Ilum()
    {        
        LiBlue.SetActive(false);
        Lired.SetActive(true);
    }

    void PrenderFinal()
    {
        cuadroCollider.SetActive(true);
        escritorioCollider.SetActive(true);
        espejoCollider.SetActive(true);
    }
}
