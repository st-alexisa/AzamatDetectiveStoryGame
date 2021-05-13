using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{
    public GameObject cam;
    Quaternion startingRotation;
    float vertical, horizontal;
    float rotationVer, rotationHor;
    float jump;
    public float Speed = 2, JumpSpeed = 200, Sensitivity = 5;
    bool isGround;

    private void Start()
    {
        startingRotation = transform.rotation;
    }

    private void OnCollisionStay(Collision anotherObject)
    {
        if (anotherObject.gameObject.tag == "ground")
            isGround = true;
    }

    private void OnCollisionExit(Collision anotherObject)
    {
        if (anotherObject.gameObject.tag == "ground")
            isGround = false;
    }

    void FixedUpdate()
    {
        rotationHor += Input.GetAxis("Mouse X") * Sensitivity;
        rotationVer += Input.GetAxis("Mouse Y") * Sensitivity;

        rotationVer = Mathf.Clamp(rotationVer, -60, 60);

        Quaternion rotationY = Quaternion.AngleAxis(rotationHor, Vector3.up);
        Quaternion rotationX = Quaternion.AngleAxis(-rotationVer, Vector3.right);

        cam.transform.rotation = startingRotation * transform.rotation * rotationX;
        transform.rotation = startingRotation * rotationY;

        if (isGround)
        {
            vertical = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
            horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            jump = Input.GetAxis("Jump") * Time.deltaTime * JumpSpeed;
            GetComponent<Rigidbody>().AddForce(transform.up * jump, ForceMode.Impulse);
        }
        transform.Translate(new Vector3(horizontal, 0, vertical));
    }
}
