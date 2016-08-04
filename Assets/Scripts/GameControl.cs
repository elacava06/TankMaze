using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;
    public bool useGameControl;
    private int MAX_HEALTH;
    private float rotationSpeed;
    private bool localRotation;
    private bool allowedToChange;
    private bool destroyByOwnShield;
    private bool destroyWalls;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        control = this;
        if (this.getUseGameControl()) { Load(); };
    }
    
    /*
     * Saves the data in game control to an external serialized file
     */
	public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
        GameData data = new GameData();
        data.setMaxHealth(this.getMaxHealth());
        data.setRotationSpeed(this.getRotationSpeed());
        data.setLocalRotation(this.getLocalRotation());
        data.setAllowedToChange(this.getAllowedToChange());
        data.setDestroyedByOwnShield(this.getDestroyedByOwnShield());
        data.setDestroyWalls(this.getDestroyWalls());
        bf.Serialize(file, data);
        file.Close();
    }

    /*
     * Loads saved data from the serialized game data onto game control
     */
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            GameData data = (GameData) bf.Deserialize(file);
            file.Close();
            this.setMaxHealth(data.getMaxHealth());
            this.setRotationSpeed(data.getRotationSpeed());
            this.setLocalRotation(data.getLocalRotation());
            this.setAllowedToChange(data.getAllowedToChange());
            this.setDestroyedByOwnShield(data.getDestroyedByOwnShield());
            this.setDestroyWalls(data.getDestroyWalls());
        }
    }

    /*
     * Sets the max health
     * @param amount the value that will become the max health
     */
    public void setMaxHealth(int amount)
    {
        MAX_HEALTH = amount;
    }

    /*
     * Gets the max health value
     * @return int max health
     */
    public int getMaxHealth()
    {
        return MAX_HEALTH;
    }

    /*
     * Sets the rotation speed
     * @param amount the value that will become the rotation speed
     */
    public void setRotationSpeed(float amount)
    {
        rotationSpeed = amount;
    }

    /*
     * Gets the rotation speed
     * @return float the rotation speed
     */
    public float getRotationSpeed()
    {
        return rotationSpeed;
    }

    /*
     * Sets whether local rotation will be on or off
     * @param value the value that will become local rotation
     */
    public void setLocalRotation(bool value)
    {
        localRotation = value;
    }

    /*
     * Gets whether local rotation is on or off
     * @return bool true if local rotation is on, false if local rotation is off
     */
    public bool getLocalRotation()
    {
        return localRotation;
    }
    public void setAllowedToChange(bool value)
    {
        allowedToChange = value;
    }

    /*
     * Gets whether local rotation is on or off
     * @return bool true if local rotation is on, false if local rotation is off
     */
    public bool getAllowedToChange()
    {
        return allowedToChange;
    }


    /*
     * Returns whether or not game control will be used
     * @return bool true if game control will be used, otherwise false
     */
    public bool getUseGameControl()
    {
        return useGameControl;
    }

    /*
     * Sets whether shots are destroyed by their tank's shield
     * @param value the value that will determine if shots are destroyed by their own shield
     */
    public void setDestroyedByOwnShield(bool value)
    {
        destroyByOwnShield = value;
    }

    /*
     * Gets whether or not shots are destroyed by their own shield
     * @return bool true if shots are destroyed by their own shield, false otherwise
     */
    public bool getDestroyedByOwnShield()
    {
        return destroyByOwnShield;
    }

    /*
     * Sets whether shots can destroy walls
     * @param value the value that will determine if shots can destroy walls
     */
    public void setDestroyWalls(bool value)
    {
        destroyWalls = value;
    }

    /*
     * Gets whether or not shots destroy walls
     * @return bool true if shots can destroy walls, false otherwise
     */
    public bool getDestroyWalls()
    {
        return destroyWalls;
    }

}

[Serializable]
/*
 * The game data that will be stored as a persistent data file
 */
class GameData
{
    private int MAX_HEALTH;
    private float rotationSpeed;
    private bool localRotation;
    private bool destroyedByOwnShield;
    private bool destroyWalls;
    private bool allowedToChange;
    /*
     * Gets the maximum health data
     * @return int the maximum health
     */

    public void setAllowedToChange(bool value)
    {
        allowedToChange = value;
    }

    public bool getAllowedToChange()
    {
        return allowedToChange;
    }
    public int getMaxHealth()
    {
        return MAX_HEALTH;
    }

    /*
     * Sets the max health data
     * @param amount int that will become the max health data
     */
    public void setMaxHealth(int amount)
    {
        MAX_HEALTH = amount;
    }

    /*
     * Gets the rotation speed data
     * @return float the rotation speed
     */
    public float getRotationSpeed()
    {
        return rotationSpeed;
    }

    /*
     * Sets the rotation speed data
     * @param amount the value that will become the rotation speed data
     */
    public void setRotationSpeed(float amount)
    {
        rotationSpeed = amount;
    }

    /*
     * Gets the local rotation data
     * @return bool the local rotation data
     */
    public bool getLocalRotation()
    {
        return localRotation;
    }

    /*
     * Sets the local rotation data
     * @param value the value that will become the local rotation data
     */
    public void setLocalRotation(bool value)
    {
        localRotation = value;
    }

    /*
     * Gets the destroyed by shield data
     * @return bool the destroyed by shield data
     */
    public bool getDestroyedByOwnShield()
    {
        return destroyedByOwnShield;
    }

    /*
     * Sets the destroyed by shield data
     * @param value the value that will become the destroyed by shield data
     */
    public void setDestroyedByOwnShield(bool value)
    {
        destroyedByOwnShield = value;
    }

    /*
     * Gets the destroy walls data
     * @return bool the destroy walls data
     */
    public bool getDestroyWalls()
    {
        return destroyWalls;
    }

    /*
     * Sets the destroy walls data
     * @param value the bool that will be the new destroy walls data
     */
    public void setDestroyWalls(bool value)
    {
        destroyWalls = value;
    }
}
