using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public float mousesensitivity;
    private Transform parent;
    private int FPP;

    void Start()
    {
        parent=transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
        FPP=Switch.switchState;
        if(FPP<0){                //FPP means -1, TPP means +1, default is -1 = FPP
            gameObject.transform.position = new Vector3(-16.4f,1.1f,-1.19f);
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(0, eulerRotation.y, eulerRotation.z);

        }
    }

    void Update()
    {
        Rotate();
    }

    void Rotate(){
        float mousex = Input.GetAxis("Mouse X") * mousesensitivity * Time.deltaTime;        
        parent.Rotate(Vector3.up, mousex);
    }
}