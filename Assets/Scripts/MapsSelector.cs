using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapsSelector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void loadMap(int mapNumber)
    {
        SceneManager.LoadScene(mapNumber);
    }
}
