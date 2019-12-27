using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAPI : MonoBehaviour
{
    

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("測試");
        Debug.LogWarning("警告");
        Debug.LogError("危險");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
