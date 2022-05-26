using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller; //Hareket edecek karakter
    public float speed = 12f;       //Hareketin hızını tut
    public float gravity = -9.81f;  //Yer çekimi
    public float jumpHeight = 1f;   //Sıçrama yüksekliği
    public Transform groundCheck;   //Zemin tespiti yapılacak nesne referansı
    public float groundDistance = 0.4f; //Kontrol edilecek nesnenin yarıçapı
    public LayerMask groundMask;    //Zemin katmanının tespiti 
    private Vector3 velocity;   //Sürat
    private bool isGrounded;    //Zemin tespiti
    void Update()
    {   
        //Karakterin zemin tespiti
        //CheckSphere metodu kullanılır
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Karakter zeminde mi, y-eksenindeki hızı 0 mı?
        if(isGrounded && velocity.y < 0){
            //Oyuncuyu zeminde daha sağlam tutmak için negatif değer verilir
            velocity.y = -2f;
        }

        //x ve z eksenlerindeki girdileri tut
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Hareket etmek istenilen doğrultu (sağ-sol-ileri-geri)
        Vector3 move = transform.right * x + transform.forward * z;
        
        //Karakteri belirli hıza göre hareket ettir
        controller.Move(move * speed * Time.deltaTime);

        //Karakter zemindeyse ve zıplama tuşuna basıldıysa ?
        if(Input.GetButtonDown("Jump") && isGrounded){
            //v = kök(h * -2 * g) (Hız formülü)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Sürat yüksekten düşerken artar
        velocity.y += gravity * Time.deltaTime;

        //Karakterin hızına sürati ekle
        //Eklerken bir kere daha zaman ile çarp
        //v = 1/2 * g * t^2 (Serbest Düşme)
        controller.Move(velocity * Time.deltaTime);
    }
}
