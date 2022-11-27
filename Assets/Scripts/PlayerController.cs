using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    public float launchForce;


    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit target))
        {
            worldPosition = target.point;

            if (Input.GetMouseButtonDown(0) && !GameManager.instance.gameOver)
            {
                GameObject clone = Instantiate(projectilePrefab, projectilePrefab.transform.position, projectilePrefab.transform.rotation);

                clone.GetComponent<Rigidbody>().AddForce((worldPosition - projectilePrefab.transform.position) * launchForce, ForceMode.Impulse);

                //cloneProjectile.Shoot(worldPosition);
            }
        }
    }
}
