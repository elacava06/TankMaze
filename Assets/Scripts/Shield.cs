using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
    /// <summary>
    /// This script is no longer in use for movement.  it contains only sheild health
    /// </summary>
    /// 
    public int teamNumber;
    public float maxShieldHealth;
    public float shieldHealth;
    public float regenTime;
    public float damageFromShot;
    private SpriteRenderer shieldImage;

    // Use this for initialization
    void Start() {
        shieldImage = GetComponentInChildren<SpriteRenderer>();
        shieldHealth = maxShieldHealth;
        StartCoroutine(regenerate());
        teamNumber = GetComponentInParent<TankInfo>().teamNumber;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void takeDamage()
    {
        shieldHealth -= damageFromShot;
        if(shieldHealth < 0)
        {
            shieldHealth = 0;
        }
        updateColor();
    }

    //destroys bullet when it collides with shield
    
    private IEnumerator regenerate()
    {
        while (true)
        {
            if (shieldHealth < maxShieldHealth)
            {
                shieldHealth++;
                updateColor();
            }
            yield return new WaitForSeconds(regenTime);
        }
    }
    void updateColor()
    {
        Color tmp = shieldImage.color;
        tmp.a = shieldHealth / maxShieldHealth;
        shieldImage.color = tmp;
    }

}

