using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zinnia.Data.Operation.Extraction;

public class PlayAudioOnTriggerEnter : MonoBehaviour
{
    public AudioClip clip;
    
    public string targetTag;
    [Header("audios")]
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip tom;
    [SerializeField] AudioClip lowtom;
    [SerializeField] AudioClip snare;
    [SerializeField] AudioClip hihat;
    [SerializeField] AudioClip cymbal;

    public static int totalHits = 0;
    public TextMeshProUGUI hitsText;
    void Start()
    {
        
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
        if (other.CompareTag("drumstick"))
        {
            source.PlayOneShot(clip);
            Debug.Log("Se reprodujo el sonido");

            totalHits++;
            UpdateCounterText();
        }
    }

    public void Tom()
    {
        totalHits++;
        source.PlayOneShot(tom);
        UpdateCounterText();
        Debug.Log("si prende tom");
    }
    public void Lowtom()
    {
        totalHits++;
        source.PlayOneShot(lowtom);
        UpdateCounterText();
        Debug.Log("si prende lowtom");
    }
    public void Snare()
    {
        totalHits++;
        source.PlayOneShot(snare);
        UpdateCounterText();
        Debug.Log("si prende Snare");
    }
    public void Hihat()
    {
        totalHits++;
        source.PlayOneShot(hihat);
        UpdateCounterText();
        Debug.Log("si prende Hihat");
    }
    public void Cymbal()
    {
        totalHits++;
        source.PlayOneShot(cymbal);
        UpdateCounterText();
        Debug.Log("si prende Cymbal");
    }

}
