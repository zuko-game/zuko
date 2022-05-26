using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    
    public AudioSource source;      //Ses kaynağı
    public AudioClip screamSound;   //Oynatılacak ses

   
    void Start() {

        source = GetComponent<AudioSource>();
        source.clip = screamSound;

    }

    //Çarpışma alanına girdiğinde çalışır
    void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Player"){
            //playSound() çağrısı
           StartCoroutine(playSound());
        }

    }

    //Trigger'ın yok edilmesini OnTriggerEnter'da yapınca ses oynatılamadan nesne yok ediliyor.
    //Bunun önüne geçmek için IEnumerator tanımlanır
    IEnumerator playSound(){
        //Ses kaynağına bağlı sesi oynat
        source.Play();

        //Bekleme süresi
        yield return new WaitForSeconds(5.5f);

        //Sesin devamlı olarak oynatılmaması için oyun nesnesini yok et
        Destroy(gameObject);
    }

}
