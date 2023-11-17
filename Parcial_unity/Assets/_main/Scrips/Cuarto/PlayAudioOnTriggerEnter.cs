using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayAudioOnTriggerEnter : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource source;
    public string targetTag;

    public static int totalHits = 0;
    public TextMeshProUGUI hitsText;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void UpdateCounterText()
    {
        if (hitsText != null)
        {
            // Actualizar el texto con el valor actual de totalHits
            hitsText.text = totalHits.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            source.PlayOneShot(clip);
            Debug.Log("Se reprodujo el sonido");

            totalHits++;
            UpdateCounterText();
        }
    }
}
