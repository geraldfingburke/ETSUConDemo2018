using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles box destruction here checking for the "projectile" tag
/// 
/// Updated to instantiate random powerups
///  ~Allen Oliver
/// </summary>
public class BreakableBlock : MonoBehaviour {

    #region variables
        [Header("Add the powerup prefabs here for random selection")]
        public GameObject[] powerUps;
    private GameObject PowerUp;
    private int length;
    #endregion

    private void Start()
    {
        length = powerUps.Length;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case("Projectile"):
                CreateRandomPowerUp(col);
                Destroy(gameObject, .00125f); //destroys this block after.5 float
                break;
            case ("ProjectilePlayer1"):
                CreateRandomPowerUp(col);
                Destroy(gameObject, .00125f); //destroys this block after.5 float
                break;
            case ("ProjectilePlayer2"):
                CreateRandomPowerUp(col);
                Destroy(gameObject, .00125f); //destroys this block after.5 float
                break;
        }
    }

    /// <summary>
    /// Creates a random powerup if it passes a random seed
    /// 20% chance for a random powerup for each block broken
    /// ~ Allen Oliver 2018
    /// </summary>
    private void CreateRandomPowerUp(Collider2D col)
    {
        Debug.Log(powerUps.Length);
        var randomSeed1 = Random.Range(0,100);
        var randomSeed2 = Random.Range(0, 100);
        var randomIndex = Random.Range(0, length);
        if(randomSeed1 > 90)
        {
            if(randomSeed2 > 75)
            {
                Debug.Log("Made a powerup!");
                Instantiate(powerUps[randomIndex], new Vector3(Mathf.RoundToInt(col.transform.localPosition.x),
                col.transform.position.y, Mathf.RoundToInt(col.transform.position.z)), Quaternion.identity);
            }
        }
    }


}
