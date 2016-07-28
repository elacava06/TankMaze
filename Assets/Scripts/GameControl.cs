using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;
    public bool useGameControl;
    private int MAX_HEALTH;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        control = this;
        if (useGameControl) { Load(); };
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
        }
    }

    /*
     * Sets the max health
     * @param int the value that will become the max health
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
     * Returns whether or not game control will be used
     * @return bool true if game control will be used, otherwise false
     */
    public bool getUseGameControl()
    {
        return useGameControl;
    }

}

[Serializable]
class GameData
{
    private int MAX_HEALTH;

    /*
     * Gets the maximum health data
     * @return int the maximum health
     */
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
}
