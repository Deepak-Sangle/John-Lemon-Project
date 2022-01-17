using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    public float displayImageDuration=1f;
    float m_timer;
    public CanvasGroup ExitImage;
    public CanvasGroup CaughtImage;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;
    public GameObject player;
    bool is_collision;
    bool is_caught;
    bool is_audio=true;
    void OnTriggerEnter (Collider other){
        if(other.gameObject==player){
            is_collision=true;
        }
    }

    public void CaughtPlayer(){
        is_caught = true;
    }
    
    void Update(){
        if(is_collision){
            EndLevel(ExitImage, false, exitAudio);
        }
        else if(is_caught){
            EndLevel(CaughtImage, true, caughtAudio);
        }
    }

    void EndLevel(CanvasGroup image, bool is_Restart, AudioSource audio){
        if(is_audio){
            audio.Play();
            is_audio=false;
        }
        m_timer+=Time.deltaTime;
        image.alpha=m_timer/fadeDuration;
        if(m_timer>fadeDuration + displayImageDuration){
            Cursor.visible = true;
            Screen.lockCursor = false;
            if(!(is_Restart)){                                 //Won
                SceneManager.LoadScene(0);
            }
            else{
                
                SceneManager.LoadScene(2);
            }
        }
    }
    
}
