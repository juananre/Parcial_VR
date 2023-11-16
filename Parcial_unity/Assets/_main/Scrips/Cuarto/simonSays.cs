using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class simonSays : MonoBehaviour
{
    public List<int> simonList, userList;
    public RawImage[] spriteObjects; // Asigna las referencias desde el Inspector
    public TextMeshProUGUI roundText, loserText, retryButtonText;
    public Image retryButtonUI;
    public Button retryButton;

    private int i, randomNum, max = 1, interval = 1, count = 0, y;
    private bool SimonIsPlaying = true, checkValues = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("newRound"); // Inicia la primera ronda
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) // Verde
        {
            userList.Add(0);
            action(0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) // Rojo
        {
            userList.Add(1);
            action(1);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) // Azul
        {
            userList.Add(2);
            action(2);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) // Amarillo
        {
            userList.Add(3);
            action(3);
        }

        if (userList.Count == simonList.Count)
        {
            StartCoroutine("checkLists");

            if (checkValues)
            {
                for (y = 0; y < simonList.Count; y++)
                {
                    if (userList[y] != simonList[y])
                    {
                        count++;
                    }
                    else
                    {
                        Debug.Log("Todas ok");
                    }
                }

                if (count == 0)
                {
                    Debug.Log("Proximo!");
                    roundText.text = max.ToString();
                    SimonIsPlaying = true;
                    StartCoroutine("newRound");
                }
                else if (count > 0)
                {
                    Debug.Log("Perdio!");
                    loserText.enabled = true;
                    retryButtonUI.enabled = true;
                    retryButtonText.enabled = true;
                    retryButton.enabled = true;
                }
            }
        }
    }

    void action(int id)
    {
        StartCoroutine(ShowSprite(id));
    }

    IEnumerator ShowSprite(int id)
    {
        Debug.Log("Mostrar sprite con id: " + id);
        Debug.Log("Longitud de spriteObjects: " + spriteObjects.Length);

        if (id >= 0 && id < spriteObjects.Length)
        {
            RawImage spriteImage = spriteObjects[id];
            spriteImage.enabled = true;
            yield return new WaitForSeconds(1);
            spriteImage.enabled = false;
        }
        else
        {
            Debug.LogError("Índice fuera de los límites: " + id);
        }
    }

    IEnumerator changeBool(int x)
    {
        yield return new WaitForSeconds(2);
        // No estoy seguro de qué hace exactamente este código, ya que no se proporcionó la implementación de los animadores
    }

    IEnumerator newRound()
    {
        if (SimonIsPlaying)
        {
            simonList = new List<int>();
            userList = new List<int>();

            for (i = 0; i < max; i++)
            {
                randomNum = UnityEngine.Random.Range(0, 4);
                simonList.Add(randomNum);
                action(randomNum);

                yield return new WaitForSeconds(interval);
            }

            max++;
            SimonIsPlaying = false;
        }
    }

    IEnumerator checkLists()
    {
        yield return new WaitForSeconds(1);
        checkValues = true;
        yield return new WaitForSeconds(1);
        checkValues = false;
    }
}
