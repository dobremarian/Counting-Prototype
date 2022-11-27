using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnPoint
{
    public float positionY, positionZ;
    public bool isEmpty;
    GameObject objectHeld;

    public SpawnPoint()
    {

    }

    public SpawnPoint(bool isEmpty, float positionY, float positionZ)
    {
        this.isEmpty = isEmpty;
        this.positionY = positionY;
        this.positionZ = positionZ;
    }


    public void AddObjectHeld(GameObject theObject)
    {
        objectHeld = theObject;
        isEmpty = false;
    }

    public void RemoveObjectHeld()
    {
        objectHeld = null;
        isEmpty = true;
    }

    public bool IsObjectNull()
    {
        return objectHeld == null;
    }


}
