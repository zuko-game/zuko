using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    public Flashlight flash;            //Flashlight nesnesi
    public float distance = 5.0f;      //Etkileşim uzaklığı
    void Update()
    {   
        Vector3 forward = transform.TransformDirection(Vector3.forward);    //3D ileri yönde vektör
        RaycastHit hit;         //Başlangıçtan, belirlenen doğrultuda, belirli mesafede bir ışın çizer ve kaydeder.

        //Nesne üzerinde, forward vektörü doğrultusunda, distance mesafesi kadar olan ışını hit'e kaydet
        if(Physics.Raycast(transform.position, forward, out hit, distance)){
            
            //Nesneye olan mesafe, belirtilen mesafeden küçük eşitse ve nesnenin etiketi "Battery" ise?
            if(hit.distance <= distance && hit.collider.gameObject.tag == "Battery"){
                
                //'E' tuşuna basıldıysa ?
                if(Input.GetKeyDown(KeyCode.E)){
                    flash.pickBattery();                //Func call
                    Destroy(hit.collider.gameObject);   //Nesneyi yok et
                }
            } 
        }
       
    }
    
}
