using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour {

    /**
     * <summary>
     * Handles box destruction here checking for the "projectile" tag
     * ~Allen Oliver
     * </summary>
     */

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case("Projectile"):
                Destroy(gameObject, .5f); //destroys this block after.5 float
                break;
        }
    }
}
