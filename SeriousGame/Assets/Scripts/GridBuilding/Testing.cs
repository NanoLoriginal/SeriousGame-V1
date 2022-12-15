using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    [SerializeField] Transform MouseVisualTransform;
    [SerializeField] LayerMask MouseLayer;


    private void Start()
    {
        
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, MouseLayer))
        {

            MouseVisualTransform.position = raycastHit.point;
        }
    }
}
