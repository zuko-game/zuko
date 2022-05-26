using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayFootstepSound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool IsMoving;
 
    void Start()
    {   
        //Ses kaynağı olan nesneyi tut
        audioSource = gameObject.GetComponent<AudioSource>();
    }
 
    void Update()
    {   
        //İleri-Geri-Sağ-Sol hareketin kontrolü
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) 
            IsMoving = true; 
        else 
            IsMoving = false;

        
        if (IsMoving && !audioSource.isPlaying) 
            audioSource.Play(); // Oyuncu hareket ediyorsa ve ses kaynağı çalmıyorsa başlat
        if (!IsMoving) 
            audioSource.Stop(); // Oyuncu hareket etmiyorsa ve ses kaynağı çalıyorsa bitir

    }
}