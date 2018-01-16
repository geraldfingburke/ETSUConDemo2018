using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : MonoBehaviour {

    /// <summary>
    /// Add a name, actiontext, timeTillDisappear, and timetillexpire to ALL powerups
    /// ~ Allen Oliver 2018
    /// </summary>
    #region Attributes
    [Header("Power Up Name")]
    public string Name = "Rapid Fire";
    [Header("Power Up Text For Gui")]
    public string ActionText = "Rapid Fire!";
    [Header("Power Up Duration After Activation")]
    public float TimeTillExpire = 7f;
    [Header("Power Up time till disappear on map")]
    public float TimeTillDisappear = 20f;
    #endregion

    /// <summary>
    /// Starts the disappear function
    /// ~Allen Oliver 2018
    /// </summary>
    private void Start()
    {
        StartCoroutine(RapidFireTimeLimit());
    }

    #region Coroutines
    /// <summary>
    /// waits for time, the subtracts added speed 
    /// Used for player one
    /// ~Allen Oliver 2018 
    /// </summary>
    /// <param name="obj">Player that has speed altered</param>
    /// <returns>Wait for Seconds (float TimeTillExpire)</returns>
    public IEnumerator RapidFirePlayerOne(GameObject obj)
    {
        obj.GetComponent<Player>().rapidFireActive = true;
        yield return new WaitForSeconds(TimeTillExpire);
        obj.GetComponent<Player>().rapidFireActive = false;
    }

    /// <summary>
    /// waits for time, the subtracts added speed
    /// used for player 2
    /// ~Allen Oliver 2018 
    /// </summary>
    /// <param name="obj">Player that has speed altered</param>
    /// <returns>Wait for Seconds (float TimeTillExpire)</returns>
    public IEnumerator RapidFirePlayerTwo(GameObject obj)
    {
        obj.GetComponent<Player2>().rapidFireActive= true;
        yield return new WaitForSeconds(TimeTillExpire);
        obj.GetComponent<Player2>().rapidFireActive = false;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerator RapidFireTimeLimit()
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
