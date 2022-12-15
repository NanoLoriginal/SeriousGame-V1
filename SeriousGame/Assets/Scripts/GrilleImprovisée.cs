using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleImprovisée : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField] int sizeX = 40;
    [SerializeField] int sizeY = 40;
    [SerializeField] Vector3 position;

    [SerializeField] GameObject[,] grid = new GameObject[100, 100];
    [SerializeField] LayerMask layerMaskTile;

    private void Start()
    {
        for (int x = 0; x < sizeX; x += 10)
        {
            for (int y = 0; y < sizeY; y += 10)
            {
                GameObject tile = GameObject.Instantiate(tilePrefab);
                tile.transform.position = position + new Vector3(x,0,y);

                tile.transform.Translate(-(float)sizeX / 2 + 0.5f, 0, -(float)sizeY / 2 + 0.5f);
                tile.name = "Tile_" + x + "_" + y;
                grid[x, y] = tile;
            }
        }
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100, layerMaskTile))
        {
            Vector3 pos3d = hit.point - transform.position;
            Debug.Log(hit.collider.gameObject.name);

            infos_puzzle tile = hit.collider.gameObject.GetComponent<infos_puzzle>();


        }
    }
}
