using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base PowerUp to be Inherited From.
/// Adds a time it lasts, and its name.
/// Each powerup will need a prefab and a script that inherits from this one 
/// ~Allen Oliver 2018
/// </summary>
/// 
public class BasePowerUp {

    #region Private Variables
    private string name;
    private string actionText;
    private float timeTillExpire;
    #endregion

    #region Getters / Setters
    public string Name { get; set; }
    public string ActionText { get; set; }
    public float TimeTillExpire { get; set; }
    #endregion

}
