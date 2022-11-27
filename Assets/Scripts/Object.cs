using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public int points;
    int shelfPositionY, shelfPositionZ;
    bool isRemoved = false;
    Transform objectTransform;

    // Start is called before the first frame update
    void Start()
    {
        objectTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRemoved)
        {
            OutOfScreenDestroy.instance.DestroyFunction(objectTransform);
        }
    }

    public void AddShelfPosition(int positionY, int positionZ)
    {
        shelfPositionY = positionY;
        shelfPositionZ = positionZ;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if(collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log(gameObject.name + " has been hit!");
        }*/

        if (other.gameObject.CompareTag("Floor"))
        {
            if (!isRemoved)
            {
                SpawnManager.instance.ReturnSpawnPoint(shelfPositionY, shelfPositionZ).RemoveObjectHeld();
                SpawnManager.instance.AddOneFreePosition();
                SpawnManager.instance.RemoveObject(gameObject);
                isRemoved = true;

                GameManager.instance.UpdateCounter();
                GameManager.instance.UpdateScore(points);
            }
        }
    }
}
