using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

/*
 * Allows the button to change the tank rotation speed
 */
public class RotationSpeedChanger : MonoBehaviour {

    private GameObject text;
    private GameObject inputField;
    private InputField inputText;
    private Text textString;

    void Awake()
    {
        text = this.transform.Find("Text").gameObject;
        inputField = this.transform.Find("InputField").gameObject;
        inputText = inputField.GetComponent<InputField>();
    }

    void Start()
    {
        textString = text.GetComponent<Text>();
        setText();
    }

    public void OnClick()
    {
        inputField.SetActive(true);
    }

    public void OnEndEdit()
    {
        GameControl.control.setRotationSpeed(Convert.ToSingle(inputText.text));
        GameControl.control.Save();
        setText();
        inputField.SetActive(false);
    }

    /*
     * Writes the appropriate message as the button text
     */
    private void setText()
    {
        textString.text = "Rotation Speed: " + GameControl.control.getRotationSpeed();
    }

}
