using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    bool isPaused;  //Oyunun durduğunun kontrolü
    public GameObject Pause_Menu;   //PauseMenu nesnesi


    // Update is called once per frame
    void Update()
    {   
        //ESC tuşuna basıldığında isPaused ters duruma geçirilir
        if(Input.GetKeyDown(KeyCode.Escape)){
            isPaused = !isPaused;
        }
        //Oyun durdurulduysa?
        if(isPaused == true){
            Pause_Menu.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        //Oyuna devam ediliyorsa?
        else{
            Pause_Menu.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
        }


    }
    public void ResumeGame(){
        isPaused = false;
    }
}
