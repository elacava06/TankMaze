using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Allows the button to change whether or not components move with the tank body or not
 */
public class LocalRotationChanger : MonoBehaviour {

    private GameObject text;
    private Text textString;
    private bool localRotation;

    void Awake()
    {
        text = this.transform.Find("Text").gameObject;
    }

    void Start()
    {
        if (GameControl.control.getUseGameControl())
        {
            localRotation = GameControl.control.getLocalRotation();
        } else
        {
            localRotation = false;
        }
        textString = text.GetComponent<Text>();
        setText();
    }

    public void OnClick()
    {
        this.setLocalRotation(!this.getLocalRotation());
        GameControl.control.setLocalRotation(this.getLocalRotation());
        GameControl.control.Save();
        setText();
    }

    /*
     * Gets the local rotation
     * @return bool true if local rotation is on, false if it is off
     */
    public bool getLocalRotation()
    {
        return localRotation;
    }

    /*
     * Sets the local rotation
     * @param value the bool value that will become the local rotation
     */
    public void setLocalRotation(bool value)
    {
        localRotation = value;
    }

    /*
     * Writes the appropriate message as the button text
     */
    private void setText()
    {
        if (this.getLocalRotation())
        {
            textString.text = "Local Rotation: On";
        } else
        {
            textString.text = "Local Rotation: Off";
        }
    }

}
