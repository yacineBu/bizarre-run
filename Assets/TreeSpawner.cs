using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;
    public MeshRenderer terrainMeshRenderer;
    public int numberOfTrees = 100;
    public float minDistanceToOtherTrees = 10f;
    public HudStatistics stats;
    int currentTour = 0;

    void Start()
    {
        ResetTreeScale();
        GenerateForest();
    }

    private void Update()
    {
        if(currentTour != stats.tour)
        {
            currentTour = stats.tour;
            RemoveAllTreePrefabs();
            IncreaseTreeScale();
            GenerateForest();
        }
    }

    void GenerateForest()
    {
        Bounds bounds = terrainMeshRenderer.bounds;

        for (int i = 0; i < numberOfTrees; i++)
        {
            Vector3 randomPosition = GetRandomPosition(bounds);

            // R�cup�re la hauteur du terrain � la position
            float terrainHeight = GetTerrainHeight(randomPosition);

            // Ajuste la position en fonction de la hauteur du terrain
            randomPosition.y = terrainHeight;

            // Cr�e l'arbre avec rotation ajust�e
            InstantiateTreeAtPosition(treePrefab, randomPosition);
        }
    }

    Vector3 GetRandomPosition(Bounds bounds)
    {
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        return new Vector3(x, 0f, z);
    }

    float GetTerrainHeight(Vector3 position)
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(position.x, 1000f, position.z), Vector3.down, out hit, Mathf.Infinity))
        {
            return hit.point.y;
        }
        return 0f;
    }

    void InstantiateTreeAtPosition(GameObject treePrefab, Vector3 position)
    {
        // V�rifie si la position est suffisamment �loign�e des autres arbres
        GameObject tree = Instantiate(treePrefab, position, Quaternion.Euler(0f, 0f, 0f));
    }


    void RemoveAllTreePrefabs()
    {
        GameObject[] allTrees = GameObject.FindGameObjectsWithTag("Tree");

        foreach (GameObject tree in allTrees)
        {
            Destroy(tree); // D�truit l'arbre
        }
    }

    void IncreaseTreeScale()
    {
        // Augmente l'�chelle en Y du prefab de l'arbre
        Vector3 newScale = treePrefab.transform.localScale;
        newScale.y += 500f; // Augmentation de l'�chelle en Y
        newScale.x += 20f; // Augmentation de l'�chelle en Y
        newScale.z += 20f; // Augmentation de l'�chelle en Y
        treePrefab.transform.localScale = newScale;
    }

    void ResetTreeScale()
    {
        // Augmente l'�chelle en Y du prefab de l'arbre
        Vector3 newScale = treePrefab.transform.localScale;
        newScale.y = 500f; // Augmentation de l'�chelle en Y
        newScale.x = 20f; // Augmentation de l'�chelle en Y
        newScale.z = 20f; // Augmentation de l'�chelle en Y
        treePrefab.transform.localScale = newScale;
    }
}
