using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [SerializeField]SpawnPoint[,] spawnPoints = new SpawnPoint[3,7];
    private float leftmostZ = -7.8f;
    private float topmostY = 11.6f;
    private float heightDifference = 3.1f;
    private float nearDifference = 2.6f;
    private float defaultX = 15.25f;
    private int freePositions = 21;
    [SerializeField] List<GameObject> objectsOnShelf;

    public GameObject[] objectToSpawnPrefab;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        SpawnPointAssignment();

    }

    // Update is called once per frame
    void Update()
    { 
        /*if(Input.GetKeyDown(KeyCode.Space) && !GameManager.instance.gameOver)
        {
            SpawnObjects();
        }*/

        
        if((objectsOnShelf.Count <= 0) && (!GameManager.instance.gameOver))
        {
            SpawnObjects();
        }

    }

    void SpawnPointAssignment()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 7; j++)
            {
                float positionY = topmostY - (i * heightDifference);
                float positionZ;
                if (j == 3)
                {
                    positionZ = 0;
                }
                else
                {
                    positionZ = leftmostZ + (j * nearDifference);
                }


                spawnPoints[i, j] = new SpawnPoint(true, positionY, positionZ);

            }
        }
       
    }

    void SpawnObjects()
    {
        
        for(int i = 0; i < objectToSpawnPrefab.Length; i++)
        {
            int index1 = Random.Range(0, 3);
            int index2 = Random.Range(0, 7);
            int randomObject = Random.Range(0, objectToSpawnPrefab.Length);

            while(!spawnPoints[index1, index2].isEmpty && freePositions > 0)
            {
                index1 = Random.Range(0, 3);
                index2 = Random.Range(0, 7);
            }

            if (spawnPoints[index1, index2].isEmpty && spawnPoints[index1, index2].IsObjectNull())
            {
                Vector3 positionToSpawn = new Vector3(defaultX, spawnPoints[index1, index2].positionY, spawnPoints[index1, index2].positionZ) + objectToSpawnPrefab[randomObject].transform.position;

                GameObject clone = Instantiate(objectToSpawnPrefab[randomObject], positionToSpawn, objectToSpawnPrefab[randomObject].transform.rotation);

                clone.gameObject.GetComponent<Object>().AddShelfPosition(index1, index2);

                spawnPoints[index1, index2].AddObjectHeld(clone);

                objectsOnShelf.Add(clone);

                freePositions--;
            }

            if(freePositions == 0)
            {
                i = objectToSpawnPrefab.Length;
            }
        }
    }

    public SpawnPoint ReturnSpawnPoint(int positionY, int positionZ)
    {
        return spawnPoints[positionY, positionZ];
    }

    public void AddOneFreePosition()
    {
        freePositions++;
    }

    public void RemoveObject(GameObject objectToRemove)
    {
        objectsOnShelf.Remove(objectToRemove);
    }
}
