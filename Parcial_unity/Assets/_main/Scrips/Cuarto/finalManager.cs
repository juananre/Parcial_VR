using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalManager : MonoBehaviour
{
    [Header("Cambio de escena")]
    [SerializeField] float TiempoParaOtraEscena = 3;

    [Header("txt")]
    [SerializeField] GameObject cuadroTxt;
    [SerializeField] GameObject espejoTxt;
    [SerializeField] GameObject EscritorioTxt;
    [SerializeField] GameObject urgenteUI;

    [Header("elements colliders")]
    public GameObject ultimisUI;
    public GameObject cuadroColli;
    public GameObject escriColli;
    public GameObject espeColli;

    [Header("luces")]
    public GameObject cuadroLight;
    public GameObject escriLight;
    public GameObject espeLight;

    [Header("audio")]
    [SerializeField] GameObject musica;

    private bool active = false;
    private int cout=0;

    private void Update()
    {
        if (cout >= 3)
        {
            musica.SetActive(false);
            StartCoroutine(EsperarYCargarEscenaFinal(TiempoParaOtraEscena));
        }
    }

    public void esopejo()
    {
        espejoTxt.SetActive(true);
        espeLight.SetActive(true);
        espeColli.SetActive(false);
        ActivarUltimisUI();
        urgenteUI.SetActive(false);
        active = true;
        cout++;
    }
    public void cuadro()
    {
        cuadroTxt.SetActive(true);
        cuadroLight.SetActive(true);
        cuadroColli.SetActive(false);
        ActivarUltimisUI();
        urgenteUI.SetActive(false);
        active = true;
        cout++;
    }
    public void escritorio()
    {
        EscritorioTxt.SetActive(true);
        escriLight.SetActive(true);
        escriColli.SetActive(false);
        urgenteUI.SetActive(false);
        ActivarUltimisUI();
        active = true;
        cout++;   
    }
    void ActivarUltimisUI()
    {
        if (active==false)
        {
            ultimisUI.SetActive(true);
        }
       
    }

    IEnumerator EsperarYCargarEscenaFinal(float tiempoEspera)
    {
        yield return new WaitForSeconds(tiempoEspera);
        CargarEscenaFinal();
    }

    void CargarEscenaFinal()
    {
        SceneManager.LoadScene("final");
    }
}
