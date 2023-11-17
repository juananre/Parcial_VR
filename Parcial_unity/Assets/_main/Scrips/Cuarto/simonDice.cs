using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class simonDice : MonoBehaviour
{
    public RawImage[] simonImages;
    public Button[] simonButtons;
    public int currentLevel = 1;
    public int sequenceLength = 1;

    private int[] sequence;
    private int playerIndex;

    public Color[] colors;
    public float colorDuration = 1f;

    void Start()
    {
        // Asigna los métodos a los botones
        for (int i = 0; i < simonButtons.Length; i++)
        {
            int buttonIndex = i; // Necesario para evitar el cierre sobre la variable incorrecta
            simonButtons[i].onClick.AddListener(() => OnButtonClick(buttonIndex));
        }

        StartGame();
    }

    void StartGame()
    {
        sequence = new int[sequenceLength];
        playerIndex = 0;
        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        // Genera la secuencia aleatoria
        for (int i = 0; i < sequenceLength; i++)
        {
            sequence[i] = Random.Range(0, simonImages.Length);
            yield return new WaitForSeconds(1f);
            StartCoroutine(ActivateElement(sequence[i]));
        }

        // Aquí podrías proporcionar algún feedback adicional cuando se completa la secuencia.
        Debug.Log("¡Has completado la secuencia!");
    }

    IEnumerator ActivateElement(int index)
    {
        // Activa el elemento
        simonImages[index].color = colors[index];
        simonImages[index].enabled = true;
        yield return new WaitForSeconds(colorDuration);
        // Restaura el color original
        simonImages[index].color = Color.white;
        // Desactiva el elemento
        simonImages[index].enabled = false;
    }

    void OnButtonClick(int buttonIndex)
    {
        // Comprueba si el botón presionado es el correcto
        if (buttonIndex == sequence[playerIndex])
        {
            playerIndex++;
            // Comprueba si ha completado la secuencia
            if (playerIndex == sequenceLength)
            {
                playerIndex = 0;
                currentLevel++;
                if (currentLevel > 10)
                {
                    Debug.Log("¡Has ganado!");
                    // Aquí puedes reiniciar el juego o ejecutar alguna acción de victoria.
                }
                else
                {
                    sequenceLength++;
                    StartCoroutine(PlaySequence());
                }
            }
        }
        else
        {
            Debug.Log("¡Has perdido!");
            // Aquí puedes reiniciar el juego o ejecutar alguna acción de derrota.
        }
    }
}
