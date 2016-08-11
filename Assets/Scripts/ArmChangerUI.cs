using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Allows the button to change whether or tanks can change attachments in game
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
     * Gets whether or not tanks can change attachments in game
     * @return bool true if tanks can change attachments in game, otherwise false
     */
    public bool getAllowedToChange()
    {
        return allowedToChange;
    }

    /*
     * Sets the whether or not tanks can change attachments in game
     * @param value the bool value that will determine if tanks can change attachments in game
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
