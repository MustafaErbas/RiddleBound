using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightingfix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DynamicGI.UpdateEnvironment();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
