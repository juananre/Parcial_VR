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
    [SerializeField] int cambio_estado = 0;
    [SerializeField] int min, seg;

    [Header("estorbos")]
    [SerializeField] GameObject Estorbos1;
    [SerializeField] GameObject Estorbos2;
    [SerializeField] GameObject Estorbos3;
    [SerializeField] GameObject Estorbos4;

    private float tiempoPasado = 0f;
    private float tiempoParaEvento; // 5% del tiempo establecido
    private bool eventoOcurrido = false;

    void Start()
    {
        tiempoParaEvento = (min * 60 + seg) * 0.05f; // Calcula el 5% del tiempo total.
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

        if (!eventoOcurrido && tiempoPasado >= tiempoParaEvento)
        {
            // Realiza la acción que deseas que ocurra en el 5% del tiempo establecido.
            // Puedes colocar aquí el código para manejar el evento.
            Debug.Log("El evento ha ocurrido.");
            eventoOcurrido = true; // Marcar el evento como ocurrido para que no se repita.
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
