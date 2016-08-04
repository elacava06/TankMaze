using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapsSelector : MonoBehaviour {
    
    public void loadMap(int mapNumber)
    {
        SceneManager.LoadScene(mapNumber);
    }
}
