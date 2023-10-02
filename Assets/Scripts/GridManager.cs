using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private int gridDimension;
    [SerializeField] private float distance;
    private GameObject[,] grid;

    void Start()
    {
        grid = new GameObject[gridDimension, gridDimension];
        InitGrid();
    }


    void Update()
    {
        
    }

    void InitGrid()
    {
        Vector3 positionOffset = transform.position - new Vector3(gridDimension * distance / 2.0f, gridDimension * distance / 2.0f, 0);
        for (int row = 0; row < gridDimension; row++)
        {

            for (int column = 0; column < gridDimension; column++)
            {
                GameObject newTile = Instantiate(tilePrefab);
                SpriteRenderer renderer = newTile.GetComponent<SpriteRenderer>();
                renderer.sprite = sprites[Random.Range(0, sprites.Count)];
                newTile.transform.parent = transform;
                newTile.transform.position = new Vector3(column * distance, row * distance, 0) + positionOffset;

                grid[column, row] = newTile;
            }
        }
    }
}
