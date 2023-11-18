using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalManager : MonoBehaviour
{
    public TextMeshProUGUI amanText;
    public TextMeshProUGUI tuText;
    public TextMeshProUGUI hacesText;

    public GameObject ultimisUI;
    public GameObject cuadroColli;
    public GameObject escriColli;
    public GameObject espeColli;

    public GameObject cuadroLight;
    public GameObject escriLight;
    public GameObject espeLight;

    private bool cuadroInteractuado = false;
    private bool escriInteractuado = false;
    private bool espeInteractuado = false;

    void OnTriggerEnter(Collider other)
    {
        // Verificar si la colisión es de las mano
        if (other.gameObject.layer == LayerMask.NameToLayer("Manos"))
        {
            if (other.gameObject == cuadroColli && !cuadroInteractuado)
            {
                amanText.gameObject.SetActive(true);
                cuadroLight.SetActive(true);
                cuadroInteractuado = true;
                ActivarUltimisUI();
            }
            else if (other.gameObject == escriColli && !escriInteractuado)
            {
                hacesText.gameObject.SetActive(true);
                escriLight.SetActive(true);
                escriInteractuado = true;
                ActivarUltimisUI();
            }
            else if (other.gameObject == espeColli && !espeInteractuado)
            {
                tuText.gameObject.SetActive(true);
                espeLight.SetActive(true);
                espeInteractuado = true;
                ActivarUltimisUI();
            }

            //Si se activan los 3 textos
            if (cuadroInteractuado && escriInteractuado && espeInteractuado)
            {
                CargarEscenaFinal();
            }
        }
    }

    void ActivarUltimisUI()
    {
        ultimisUI.SetActive(true);
    }

    void CargarEscenaFinal()
    {
        SceneManager.LoadScene("final");
    }
}
