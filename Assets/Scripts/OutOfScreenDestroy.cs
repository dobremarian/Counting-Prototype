using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreenDestroy : MonoBehaviour
{
    public static OutOfScreenDestroy instance;

    float limitX1 = -15f;
    float limitX2 = 45f;
    float limitY = -10f;
    float limitZ = 40f;

    void Update()
    {
        instance = this;
    }

    public void DestroyFunction(Transform theObject)
    {
        if (theObject.position.x < limitX1 || theObject.position.x > limitX2 || theObject.position.y < limitY || theObject.position.z > limitZ || theObject.position.z < -limitZ)
        {
            Destroy(theObject.gameObject);
        }
    }
}
