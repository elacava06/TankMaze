using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Allows the button to change whether or not components move with the tank body or not
 */
public class ArmChangerUI : MonoBehaviour
{

    private GameObject text;
    private Text textString;
    private bool allowedToChange;

    void Awake()
    {
        text = this.transform.Find("Text").gameObject;
    }

    void Start()
    {
        if (GameControl.control.getUseGameControl())
        {
            allowedToChange = GameControl.control.getAllowedToChange();
        }
        else
        {
            allowedToChange = false;
        }
        textString = text.GetComponent<Text>();
        setText();
    }

    public void OnClick()
    {
        setAllowedToChange(!getAllowedToChange());
        GameControl.control.setAllowedToChange(getAllowedToChange());
        GameControl.control.Save();
        setText();
    }

    /*
     * Gets the local rotation
     * @return bool true if local rotation is on, false if it is off
     */
    public bool getAllowedToChange()
    {
        return allowedToChange;
    }

    /*
     * Sets the local rotation
     * @param value the bool value that will become the local rotation
     */
    public void setAllowedToChange(bool value)
    {
        allowedToChange = value;
    }

    /*
     * Writes the appropriate message as the button text
     */
    private void setText()
    {
        if (getAllowedToChange())
        {
            textString.text = "Changing is Allowed";
        }
        else
        {
            textString.text = "Changing is not Allowed";
        }
    }

}
