using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapsSelector : MonoBehaviour {

	// Use this for initialization
    public void loadMap(int mapNumber)
    {
        SceneManager.LoadScene(mapNumber);
    }
}
