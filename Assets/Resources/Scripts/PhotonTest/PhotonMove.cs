using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonMove : MonoBehaviour
{
    [SerializeField]
    [Range(0,10)]
    private float Mouse_Sensitivity = 4.5f;

    public float runSpeed = 6.0f;
    public float rotationSpeed = 360.0f;

    CharacterController pcController;
    Vector3 direction;


    void Start()
    {
        pcController = GetComponent<CharacterController>();
    }

    void Update()
    {        
        CharacterControl_Slerp();
        RotateView();
    }

    void CharacterControl_Slerp()
    {
        direction = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            direction = transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {            
            transform.Rotate(0.0f, -1.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0.0f, 1.0f, 0.0f);
        }   
        pcController.Move(runSpeed * Time.deltaTime * direction);
    }

    void RotateView()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0.0f,
                                Input.GetAxisRaw("Mouse X") * Mouse_Sensitivity,
                                0.0f);
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, transform.rotation.eulerAngles.y, 0.0f));
    }    
}
