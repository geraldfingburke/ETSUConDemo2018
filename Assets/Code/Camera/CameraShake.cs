using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Causes a camera shake effect 
/// you can call this object from any objects by saying:
/// "FindObjectOfType<CameraShake>().Shake(Params)"
/// </summary>
public class CameraShake : MonoBehaviour
{

    #region Variables
    public Camera main;
    private float shakeAmout; 
    #endregion

    void Awake()
    {
        //check for null camera
        if (main == null)
        {
            main = Camera.main;
        }
    }

    /// <summary>
    /// Starts the Private methods and shakes the screen.
    /// </summary>
    /// <param name="amt">Amount for shaking. Keep it small, .1f is what I thought looked best</param>
    /// <param name="length">How long to shake for. Also, keep this small</param>
    public void Shake(float amt = 0.1f, float length = .1f)
    {
        shakeAmout = amt;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    #region Private Methods
    /// <summary>
    /// Starts to shake camera and is repeated
    /// </summary>
    void BeginShake()
    {
        if (shakeAmout > 0)
        {
            //get camera pos now
            Vector3 camPOS = main.transform.position;
            //set 2 random offsets
            float offsetX = Random.value * shakeAmout * 2 - shakeAmout;
            float offsetY = Random.value * shakeAmout * 2 - shakeAmout;
            //set the values
            camPOS.x = offsetX;
            camPOS.y = offsetY;
            camPOS.z = 0f;
            main.transform.localPosition = camPOS;
        }
    }

    /// <summary>
    /// Stops the Shaking
    /// </summary>
    void StopShake()
    {
        CancelInvoke("BeginShake");
        //sets the camera back to zero
        //If your camera follows, create a parent object and set your camera follow to that.
        main.transform.localPosition = Vector3.zero;
    } 
    #endregion
}
