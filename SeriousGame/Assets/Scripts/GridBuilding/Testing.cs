using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private GridXZ grid;

    [SerializeField] LayerMask mouseLayer;
    [SerializeField] private Transform mouseVisualTransform;

    private void Start()
    {
        grid = new GridXZ(4, 2, 10f, new Vector3(0, 0));
    }

    private void Update()
    {

        Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, mouseLayer))
        {
            mouseVisualTransform.position = raycastHit.point;
        }


        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(mouseVisualTransform.position, 56);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(mouseVisualTransform.position));
        }
    }
}
