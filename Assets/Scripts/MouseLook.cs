using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{   

   
    public float mouseSensitivity = 100f;  //Mouse hassasiyeti
    public Transform playerBody;    //Döndürülecek karakteri tutar
    private float xRotation = 0f;
    void Start()
    {   
        //İmleci ekranın ortasına kilitle ve sakla
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {   
        //x-y ekseninde mouse girdilerini tut
        //Dönme hızını kare hızından bağımsız hale getirmek için deltatime ile çarpılır
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;       
        
        //mouseY girdisine göre her bir karede xRotation'ı azalt
        //Artırma yaparsak y-ekseninde ters şekilde dönüş olur
        xRotation -= mouseY;

        //Bakış açısını 180 derece ile sınırla
        xRotation = Mathf.Clamp(xRotation,-90f,90f); 

        //y-ekseninde dönüşü gerçekleştirme
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        //Karakterin tüm vücudunu döndür
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

