using UnityEngine;
using System.Collections;

public class setTargetFrameRate : MonoBehaviour {

    void Awake()
    {
        Application.targetFrameRate = 120;
    }
}
