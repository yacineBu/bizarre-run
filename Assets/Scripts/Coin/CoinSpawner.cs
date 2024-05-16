using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform playerTransform;
    public float spawnRadius = 800f;
    public float minHeightFromGround = 5f;
    public float maxHeight = 500f;
    public float spawnInterval = 30f; // Intervalle de spawn en secondes
    public int maxConcurrentCoins = 10; // Nombre maximum d'�toiles en simultan�

    private const float OCEANHEIGHT = 0f;
    private List<GameObject> activeCoins = new List<GameObject>();

    private void Start()
    {
        StartSpawningCoins();
    }

    private void StartSpawningCoins()
    {
        StartCoroutine(SpawnCoins());
    }

    private System.Collections.IEnumerator SpawnCoins()
    {
        while (true)
        {
            if (activeCoins.Count < maxConcurrentCoins)
            {
                float randomHeight;
                Vector3 playerPosition = playerTransform.position;
                Vector2 randomCordsInsidePlayerCircle = Random.insideUnitCircle.normalized * spawnRadius;

                // Trouver la hauteur du sol � partir de la position du joueur
                RaycastHit hit;
                if (Physics.Raycast(playerPosition, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Terrain")))
                {
                    float finalMinHeight = hit.point.y + minHeightFromGround;
                    if (finalMinHeight > maxHeight)             // peut arriver dans les endroits tr�s haut de la map
                    {
                        randomHeight = finalMinHeight;
                    }
                    else
                    {
                        randomHeight = Random.Range(finalMinHeight, maxHeight);
                        randomHeight = Mathf.Max(randomHeight, OCEANHEIGHT + minHeightFromGround);      // g�re le cas o� l'eau est au dessus du terrain
                    }
                }
                else
                {
                    randomHeight = Random.Range(OCEANHEIGHT + minHeightFromGround, maxHeight);
                }

                Vector3 spawnPosition = new Vector3(playerPosition.x + randomCordsInsidePlayerCircle.x, randomHeight, playerPosition.z + randomCordsInsidePlayerCircle.y);
                GameObject newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.AngleAxis(90, new Vector3(1, 0, 0)));
                activeCoins.Add(newCoin);

                yield return new WaitForSeconds(spawnInterval);
            }
            else
            {
                // Attendre avant de v�rifier � nouveau si le nombre d'�toiles actives est inf�rieur au maximum
                yield return null;
            }
        }
    }

    // Fonction pour enlever une �toile de la liste des �toiles actives (agit uniquement sur la liste)
    public void RemoveCoin(GameObject coin)
    {
        activeCoins.Remove(coin);
    }
}
