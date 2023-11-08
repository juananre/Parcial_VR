using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;



public class ControlTiempo : MonoBehaviour
{
    [SerializeField] TMP_Text txt_contador_Tiempo;
    [SerializeField] int min, seg;

    [Header("estorbos")]
    [SerializeField] GameObject Estorbos1;
    [SerializeField] GameObject Estorbos2;
    [SerializeField] GameObject Estorbos3;
    [SerializeField] GameObject Estorbos4;

    [Header("Porcentaje de aparicion")]
    [SerializeField] float EstorboPorcentaje1 = 0.5f;
    [SerializeField] float EstorboPorcentaje2 = 0.6f;
    [SerializeField] float EstorboPorcentaje3 = 0.7f;
    [SerializeField] float EstorboPorcentaje4 = 0.8f;

    private float tiempoPasado = 0f;
    private float tiempoParaEstorbo1;
    private float tiempoParaEstorbo2;
    private float tiempoParaEstorbo3;
    private float tiempoParaEstorbo4;// 5% del tiempo establecido

    private bool eventoOcurrido1 = false;
    private bool eventoOcurrido2 = false;
    private bool eventoOcurrido3 = false;
    private bool eventoOcurrido4 = false;


    void Start()
    {
        tiempoParaEstorbo1 = (min * 60 + seg) * EstorboPorcentaje1; // Calcula el 50% del tiempo total.
        tiempoParaEstorbo2 = (min * 60 + seg) * EstorboPorcentaje2;
        tiempoParaEstorbo3 = (min * 60 + seg) * EstorboPorcentaje3;
        tiempoParaEstorbo4 = (min * 60 + seg) * EstorboPorcentaje4;
    }

    void TerminarTemporizador()
    {
        SceneManager.LoadScene(2);
    }

    void Update()
    {
        tiempoPasado += Time.deltaTime;
        int tempmin = Mathf.FloorToInt(tiempoPasado / 60);
        int tempseg = Mathf.FloorToInt(tiempoPasado % 60);
        txt_contador_Tiempo.text = string.Format("{00:00}:{01:00}", tempmin, tempseg);

        if (!eventoOcurrido1 && tiempoPasado >= tiempoParaEstorbo1)
        {
            Estorbos1.SetActive(true);
            eventoOcurrido1 = true; // Marcar el evento como ocurrido para que no se repita.
        }
        if (!eventoOcurrido2 && tiempoPasado >= tiempoParaEstorbo2)
        {
            Estorbos2.SetActive(true);
            eventoOcurrido2 = true; 
        }
        if (!eventoOcurrido3 && tiempoPasado >= tiempoParaEstorbo3)
        {
            Estorbos3.SetActive(true);
            eventoOcurrido3 = true;
        }
        if (!eventoOcurrido4 && tiempoPasado >= tiempoParaEstorbo4)
        {
            Estorbos2.SetActive(true);
            eventoOcurrido4 = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) || tiempoPasado >= (min * 60 + seg))
        {
            TerminarTemporizador();
        }
    }

    public void Awake()
    {
        tiempoPasado = 0f;
    }
}
