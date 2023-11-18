using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ManagerPiezas : MonoBehaviour

{
    [Header("tiempo")]

    [SerializeField] int min, seg;

    [Header("estorbos")]

    [SerializeField] GameObject Estorbos1, Estorbos2, Estorbos3, Estorbos4;
    [SerializeField] float EstorboPorcentaje1 = 0.5f, EstorboPorcentaje2 = 0.6f, EstorboPorcentaje3 = 0.7f, EstorboPorcentaje4 = 0.8f;
    private float tiempoPasado = 0f;
    private float tiempoParaEstorbo1, tiempoParaEstorbo2, tiempoParaEstorbo3, tiempoParaEstorbo4;
    private bool eventoOcurrido1 = false, eventoOcurrido2 = false, eventoOcurrido3 = false, eventoOcurrido4 = false;

    [Header("imagenes y puertas")]

    [SerializeField] int Count = 0;
    [SerializeField] GameObject imagen1, imagen2, imagen3;
    [SerializeField] GameObject lUZ, Bloqueo;
    [SerializeField] GameObject puerta;

    [Header("audios")]
    [SerializeField] AudioSource audioSource;
    public AudioClip vallenatico;
    [SerializeField] GameObject tensionMusic;

    void Start()
    {
        tiempoParaEstorbo1 = (min * 60 + seg) * EstorboPorcentaje1;
        tiempoParaEstorbo2 = (min * 60 + seg) * EstorboPorcentaje2;
        tiempoParaEstorbo3 = (min * 60 + seg) * EstorboPorcentaje3;
        tiempoParaEstorbo4 = (min * 60 + seg) * EstorboPorcentaje4;
    }

    void Update()
    {
        tiempoPasado += Time.deltaTime;
        int tempmin = Mathf.FloorToInt(tiempoPasado / 60);
        int tempseg = Mathf.FloorToInt(tiempoPasado % 60);

        if (!eventoOcurrido1 && tiempoPasado >= tiempoParaEstorbo1)
        {
            Estorbos1.SetActive(true);
            eventoOcurrido1 = true;
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
            Estorbos4.SetActive(true);
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

    public void pusartiempo()
    {
        tiempoPasado -= Time.deltaTime;
    }

    void TerminarTemporizador()
    {
        //SceneManager.LoadScene(2);
    }

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
            puerta.SetActive(false);
            audioSource.PlayOneShot(vallenatico);
            tensionMusic.SetActive(false);
        }
    }
}
