using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Subsystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using JetBrains.Annotations;

public class bikeController : MonoBehaviour
{
    #region Mouse Look
    public float mouseHspeed = 4.0f;
    public float mouseVspeed = 4.0f;
    #endregion

    #region vSettings
    public float hoverForce = 1000.0f;
    public float hoverHeight = -0.4f;
    public float selfRightForce = 0.5f;
    #endregion

    #region thrust force
    // f = forwards, b = back, l = left, r = right

    public float fThrust = 200.0f;
    public float lThrust = 50.0f;
    public float btmThrust = 200.0f;
    public float topThrust = -200.0f;
    public float rotateForce = 200.0f;
    #endregion

    #region Extera Tools
    public Rigidbody rb;
    #endregion

    #region keybinds and extra thing
    public KeyCode fThrustAdd = KeyCode.W;
    public KeyCode lThrustAdd = KeyCode.A;
    public KeyCode bThrustAdd = KeyCode.S;
    public KeyCode rThrustAdd = KeyCode.D;
    public KeyCode lRoll = KeyCode.Q;
    public KeyCode rRoll = KeyCode.E;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode fallKey = KeyCode.C;
    public KeyCode cutHover = KeyCode.LeftControl;
    #endregion

    #region pressed check
    bool fPressed;
    bool lPressed;
    bool bPressed;
    bool rPressed;
    bool jmpPressed;
    bool qPressed;
    bool ePressed;
    bool fallPressed;
    bool cutHoverKeyDown;
    #endregion

    #region rotationCheck
    bool rotatedLeft;
    bool rotatedRight;
    public float rotationCheck = 0.5f;
    #endregion

    #region Timers and Math
    private float jReTimer = 0;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        #region forward
        if (Input.GetKeyDown(fThrustAdd))
        {
            fPressed = true;
        }
        if (Input.GetKeyUp(fThrustAdd))
        {
            fPressed = false;
        }
        if (fPressed == true)
        {
            rb.AddForce(transform.up * fThrust);
        }
        #endregion
        #region back
        if (Input.GetKeyDown(lThrustAdd))
        {
            lPressed = true;
        }
        if (Input.GetKeyUp(lThrustAdd))
        {
            lPressed = false;
        }
        if (lPressed == true)
        {
            rb.AddForce(transform.right * lThrust);
        }
        #endregion
        #region  Back Thrust
        if (Input.GetKeyDown(bThrustAdd))
        {
            bPressed = true;
        }
        if (Input.GetKeyUp(bThrustAdd))
        {
            bPressed = false;
        }
        if (bPressed == true)
        {
            rb.AddForce(transform.up * -fThrust);
        }
        #endregion
        #region Right Thrust
        if (Input.GetKeyDown(rThrustAdd))
        {
            rPressed = true;
        }
        if (Input.GetKeyUp(rThrustAdd))
        {
            rPressed = false;
        }
        if (rPressed == true)
        {
            rb.AddForce(transform.right * -lThrust);
        }
        #endregion
        #region Roll Left
        if (Input.GetKeyDown(lRoll))
        {
            qPressed = true;
        }
        if (Input.GetKeyUp(lRoll))
        {
            qPressed = false;
        }
        if (qPressed == true)
        {
            transform.Rotate(Vector3.up * rotateForce * Time.deltaTime);
        }
        #endregion
        #region Roll Right
        if (Input.GetKeyDown(rRoll))
        {
            ePressed = true;
        }
        if (Input.GetKeyUp(rRoll))
        {
            ePressed = false;
        }
        if (ePressed == true)
        {
            transform.Rotate(Vector3.up * -rotateForce * Time.deltaTime);
        }
        #endregion

        #region Mouse Look
        float h = mouseHspeed * Input.GetAxis("Mouse X");
        float v = mouseVspeed * Input.GetAxis("Mouse Y");

        v = Mathf.Clamp(v, -1, 90);

        transform.Rotate(v, 0, h);

        Cursor.lockState = CursorLockMode.Locked;
        #endregion

        #region up thrust
        if (Input.GetKeyDown(jumpKey))
        {
            jmpPressed = true;
        }
        if (Input.GetKeyUp(jumpKey))
        {
            jmpPressed = false;
        }
        if (jmpPressed == true)
        {
            rb.AddForce(transform.forward * btmThrust);
        }
        #endregion
        #region down thrust
        if (Input.GetKeyDown(fallKey))
        {
            fallPressed = true;
        }
        if (Input.GetKeyUp(fallKey))
        {
            fallPressed = false;
        }
        if (fallPressed == true)
        {
            rb.AddForce(transform.forward * topThrust);
        }
        #endregion

    }


    private void FixedUpdate()
    {

        #region Constant Hover Thrust
        if (Input.GetKey(cutHover))
        {
            cutHoverKeyDown = true;
        }
        else
        {
            cutHoverKeyDown = false;
        }
        if (rb.position.y <= hoverHeight & cutHoverKeyDown == false)
        {
            rb.AddForce(transform.forward * hoverForce);
        }
        #endregion

        #region Self Right Rotation "zAxis"
        if (rb.rotation.z <= -rotationCheck)
        {
            rotatedLeft = true;
        }
        if (rb.rotation.z >= -rotationCheck)
        {
            rotatedLeft = false;
        }
        if (rb.rotation.z >= rotationCheck)
        {
            rotatedRight = true;
        }
        if (rb.rotation.z >= rotationCheck)
        {
            rotatedRight = false;
        }

        if (rotatedLeft == true)
        {
            /// what to do???
        }
        if (rotatedRight == true)
        {
            ///
        }
        #endregion

        #region Sped
        rbSped = rb.velocity.magnitude;
        #endregion
    }
    float rbSped = 0f;

    public string sped = ("rbSped");

    private void OnGUI()
    {
        sped = GUI.TextField(new Rect(10, 10, 20, 20), sped);
    }
}