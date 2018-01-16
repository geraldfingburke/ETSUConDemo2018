using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Speed Powerup logic
/// ~ Allen Oliver 2018
/// </summary>
public class SpeedPowerUp : MonoBehaviour {
    /// <summary>
    /// Add a name, actiontext, and timetillexpire to ALL powerups
    /// ~ Allen Oliver 2018
    /// </summary>
    #region Attributes
    [Header("Power Up Name")]
    public string Name = "Speed Power Up";
    [Header("Power Up Text For Gui")]
    public string ActionText = "Speed Up!";
    [Header("Power Up Duration After Activation")]
    public float TimeTillExpire = 15f;
    [Header("Poower Up time till disappear on map")]
    public float TimeTillDisappear = 20f;
    #endregion

    /// <summary>
    /// Starts the disappear function
    /// ~Allen Oliver 2018
    /// </summary>
    private void Start()
    {
        StartCoroutine(SpeedUpTimeLimit());
    }

    #region Coroutines
    /// <summary>
    /// waits for time, the subtracts added speed 
    /// Used for player one
    /// ~Allen Oliver 2018 
    /// </summary>
    /// <param name="obj">Player that has speed altered</param>
    /// <returns>Wait for Seconds (float TimeTillExpire)</returns>
    public IEnumerator SpeedUpPlayerOne(GameObject obj)
    {
        obj.GetComponent<Player>().moveSpeed += 5;
        yield return new WaitForSeconds(TimeTillExpire);
        obj.GetComponent<Player>().moveSpeed -= 5;
    }

    /// <summary>
    /// waits for time, the subtracts added speed
    /// used for player 2
    /// ~Allen Oliver 2018 
    /// </summary>
    /// <param name="obj">Player that has speed altered</param>
    /// <returns>Wait for Seconds (float TimeTillExpire)</returns>
    public IEnumerator SpeedUpPlayerTwo(GameObject obj)
    {
        obj.GetComponent<Player2>().moveSpeed += 5;
        yield return new WaitForSeconds(TimeTillExpire);
        obj.GetComponent<Player2>().moveSpeed -= 5;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerator SpeedUpTimeLimit()
    {
        /**
         * >TODO
         * Maybe do some blinking effects here?
         */
        yield return new WaitForSeconds(TimeTillDisappear);
        Destroy(gameObject);
    }
    #endregion
}
