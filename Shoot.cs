using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject BulletHolePrefab;
    public float MaxDistance;
    private GameObject blackHoleGroup;

    private void Start()
    {
        blackHoleGroup = new GameObject();
        blackHoleGroup.name = "blackHoleGroup";
    }

    private void Update()
    {
        Fire();
    }

    public void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, MaxDistance))
            {
                Instantiate(BulletHolePrefab, hit.point + (hit.normal * 0.01f), Quaternion.LookRotation(hit.normal), blackHoleGroup.transform);
            }
        }
    }
}
