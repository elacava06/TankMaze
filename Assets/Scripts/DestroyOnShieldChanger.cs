using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Allows the button to change whether or not shots are destroyed on their own shield
 */
public class DestroyOnShieldChanger : MonoBehaviour {

    private GameObject text;
    private Text textString;
    private bool destroyedByOwnShield;

    void Awake()
    {
        text = this.transform.Find("Text").gameObject;
    }

    void Start()
    {
        if (GameControl.control.getUseGameControl())
        {
            destroyedByOwnShield = GameControl.control.getDestroyedByOwnShield();
        }
        else
        {
            destroyedByOwnShield = true;
        }
        textString = text.GetComponent<Text>();
        setText();
    }

    public void OnClick()
    {
        this.setDestroyedByOwnShield(!this.getDestroyedByOwnShield());
        GameControl.control.setDestroyedByOwnShield(this.getDestroyedByOwnShield());
        GameControl.control.Save();
        setText();
    }

    /*
     * Gets whether or not shots are destroyed on their tank's shield
     * @return bool true if shots are destroyed on own shield, false otherwise
     */
    public bool getDestroyedByOwnShield()
    {
        return destroyedByOwnShield;
    }

    /*
     * Sets whether or not shots are destroyed on their tank's shield
     * @param value the value that will determine if shots are destroyed by their own shield
     */
    public void setDestroyedByOwnShield(bool value)
    {
        destroyedByOwnShield = value;
    }

    /*
     * Writes the appropriate message as the button text
     */
    private void setText()
    {
        if (this.getDestroyedByOwnShield())
        {
            textString.text = "Shots Destroyed On Own Shield: On";
        }
        else
        {
            textString.text = "Shots Destroyed On Own Shield: Off";
        }
    }

}
