using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Handles Pickups for the Speed Power up
/// ~Allen Oliver 2018
/// </summary>
public class SpeedPowerUpPickup : MonoBehaviour {



    #region trigger
    /// <summary>
    /// 
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case ("Player1"):
                Debug.Log("collision happened");
                var speedUp = new SpeedPowerUp();
                StartCoroutine(speedUp.SpeedUpPlayerOne(col.gameObject));
                Destroy(gameObject);
                break;
            case ("Player2"):
                var speedUp2 = new SpeedPowerUp();
                StartCoroutine(speedUp2.SpeedUpPlayerTwo(col.gameObject));
                Destroy(gameObject);
                break;
        }
    }
    #endregion


}
