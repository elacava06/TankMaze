using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Allows the button to change whether or not shots can destroy walls
 */
public class ShotsDestroyWallsChanger : MonoBehaviour {

    private GameObject text;
    private Text textString;
    private bool destroyWalls;

    void Awake()
    {
        text = this.transform.Find("Text").gameObject;
    }

    void Start()
    {
        if (GameControl.control.getUseGameControl())
        {
            destroyWalls = GameControl.control.getDestroyWalls();
        }
        else
        {
            destroyWalls = true;
        }
        textString = text.GetComponent<Text>();
        setText();
    }

    public void OnClick()
    {
        this.setDestroyWalls(!this.getDestroyWalls());
        GameControl.control.setDestroyWalls(this.getDestroyWalls());
        GameControl.control.Save();
        setText();
    }

    /*
     * Gets whether or not shots can destroy walls
     * @return bool true if shots can destroy walls, otherwise false
     */
    public bool getDestroyWalls()
    {
        return destroyWalls;
    }

    /*
     * Sets whether or not shots can destroy walls
     * @param value the bool value that will determine if shots can destroy walls
     */
    public void setDestroyWalls(bool value)
    {
        destroyWalls = value;
    }

    /*
     * Writes the appropriate message as the button text
     */
    private void setText()
    {
        if (this.getDestroyWalls())
        {
            textString.text = "Shots Destroy Walls: On";
        }
        else
        {
            textString.text = "Shots Destroy Walls: Off";
        }
    }

}
