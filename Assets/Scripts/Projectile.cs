using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Transform projectileTransform;

    void Start()
    {
        projectileTransform = GetComponent<Transform>();
    }

    void Update()
    {
        OutOfScreenDestroy.instance.DestroyFunction(projectileTransform);
    }
}
