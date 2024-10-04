using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


    public Transform updatecam;
    // Update is called once per frame
    void Update()
    {
       transform.position = updatecam.position; 
    }

}
