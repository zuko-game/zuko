using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{

    public Light flashLight;                //Light nesnesi
    public bool flashLightIsOpen = false;   //El feneri kontrolü
    public AudioSource audioSource;         //AudioSource nesnesi
    public AudioClip flashLigthSound;       //El feneri sesi 
    public float batteryEnergy;             //El feneri bataryası
    public Slider batteryIndicator;


    void Start(){
        audioSource = GetComponent<AudioSource>();  //AudioSource nesnesini tut
        audioSource.clip = flashLigthSound;         //Fener açma/kapama sesi
    }

    void Update()
    {   
        //F tuşu: El feneri açma/kapama
        if(Input.GetKeyDown(KeyCode.F)){
            flashLightIsOpen = !flashLightIsOpen;   //Fener açma/kapama
            audioSource.Play();                     //Fener açma/kapama sesini oynat
        }
        //Fener açıldı mı?
        if(flashLightIsOpen){
            flashLight.enabled = true;
            batteryEnergy -= 0.5f * Time.deltaTime; //Her saniye el fenerinden 0.5br enerji tükensin
        }
        //Fener kapandı mı?
        else{
            flashLight.enabled = false;
        }

        //El fenerinin pili bitti mi?
        if(batteryEnergy <= 0){
            flashLight.enabled = false;
            batteryEnergy = 0;
        }
        //Fenerin enerjisi 100'ün üstüne çıkamaz!
        else if(batteryEnergy >= 100){
            batteryEnergy = 100;
        }

        //El feneri pil göstergesinde pilin enerjisini göster
        batteryIndicator.value = batteryEnergy;
        
    }
    //Yerden batarya alınınca fenere enerji ekle
    public void pickBattery(){
        batteryEnergy += 20.0f;
    }
}
