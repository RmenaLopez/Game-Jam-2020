using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }


}
