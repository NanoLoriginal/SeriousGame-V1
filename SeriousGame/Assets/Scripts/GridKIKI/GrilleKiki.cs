using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleKiki : MonoBehaviour
{
    [SerializeField] Transform MouseVisualTransform;
    [SerializeField] LayerMask MouseLayer;


    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, MouseLayer)){

            MouseVisualTransform.position = raycastHit.point;
        }
    }

    public GrilleKiki(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                Debug.Log(x + " " + z);
                debugTextArray[x,z] = gridUtils.CreateWorldText(gridArray[x, z].ToString(), null, GetWorldPosition(x, z) + new Vector3(cellSize, 0, cellSize) * .5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.white, 100f);
                

            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

        setValue(2, 1, 56);
    }


    private Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize;
    }

    public void setValue(int x, int z, int value)
    {
        if (x>= 0 && z>=0 && x < width && z < height)
        {
            gridArray[x, z] = value;
            debugTextArray[x, z].text = gridArray[x, z].ToString();
        }
        
    }

}
