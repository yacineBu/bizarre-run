using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;
    public MeshRenderer terrainMeshRenderer;
    public int numberOfTrees = 100;
    public float minDistanceToOtherTrees = 10f;

    void Start()
    {
        GenerateForest();
    }

    void GenerateForest()
    {
        Bounds bounds = terrainMeshRenderer.bounds;

        for (int i = 0; i < numberOfTrees; i++)
        {
            Vector3 randomPosition = GetRandomPosition(bounds);

            // Récupère la hauteur du terrain à la position
            float terrainHeight = GetTerrainHeight(randomPosition);

            // Ajuste la position en fonction de la hauteur du terrain
            randomPosition.y = terrainHeight;

            // Crée l'arbre avec rotation ajustée
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
        // Vérifie si la position est suffisamment éloignée des autres arbres
        GameObject tree = Instantiate(treePrefab, position, Quaternion.Euler(-90f, 0f, 0f));
    }

    bool IsPositionValid(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, minDistanceToOtherTrees);
        return colliders.Length == 0;
    }
}
