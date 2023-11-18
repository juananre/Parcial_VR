using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalManager : MonoBehaviour
{
    [Header("txt")]
    [SerializeField] GameObject cuadroTxt;
    [SerializeField] GameObject espejoTxt;
    [SerializeField] GameObject EscritorioTxt;

    [Header("elements colliders")]
    public GameObject ultimisUI;
    public GameObject cuadroColli;
    public GameObject escriColli;
    public GameObject espeColli;

    [Header("luces")]
    public GameObject cuadroLight;
    public GameObject escriLight;
    public GameObject espeLight;

    private bool active = false;
    private bool cuadroInteractuado = false;
    private bool escriInteractuado = false;
    private bool espeInteractuado = false;


    private void Update()
    {
        
    }

    void esopejo()
    {
        espejoTxt.SetActive(true);
        espeLight.SetActive(true);
        espeColli.SetActive(false);
        ActivarUltimisUI();
        active = true;
    }
    void cuadro()
    {
        cuadroTxt.SetActive(true);
        cuadroLight.SetActive(true);
        cuadroColli.SetActive(false);
        ActivarUltimisUI();
        active = true;
    }
    void escritorio()
    {
        EscritorioTxt.SetActive(true);
        escriLight.SetActive(true);
        escriColli.SetActive(false);
        ActivarUltimisUI();
        active = true;
    }
    void ActivarUltimisUI()
    {
        if (active==false)
        {
            ultimisUI.SetActive(true);
        }
       
    }

    void CargarEscenaFinal()
    {
        SceneManager.LoadScene("final");
    }
}
