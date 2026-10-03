using UnityEngine;
using System.Collections.Generic;

public class AudioController : MonoBehaviour
{
    // La bocina que reproduce los sonidos
    public AudioSource audioSource;

    // Lista de sonidos (audio clips) que se van a reproducir
    public List<AudioClip> listAudioClips;

    // Posición del sonido actual dentro de la lista
    int posicion = 0;

    // Lo llama el botón Next Sound
    public void PlayAudioClip()
    {
        audioSource.Stop();                              // 1. si hay un sonido sonando, lo detiene
        audioSource.clip = listAudioClips[posicion];     // 2. le asigna el clip de la posición actual
        audioSource.Play();                              // 3. lo reproduce

        // Ejemplo de sonido aleatorio (no se usa por ahora):
        //listAudioClips[Random.Range(0, listAudioClips.Count)]

        // PlayOneShot superpone los sonidos, por eso ya no se usa:
        //audioSource.PlayOneShot(listAudioClips[posicion]);

        posicion++;
        if (posicion >= listAudioClips.Count)
        {
            posicion = 0; // vuelve al primer sonido
        }
    }
}
