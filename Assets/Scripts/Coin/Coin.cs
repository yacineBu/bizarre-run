using UnityEngine;

public class Coin : MonoBehaviour
{
    public float despawnDistance = 1500f;
    public int scoreValue = 10; // Valeur de score � ajouter lorsque le joueur ramasse une �toile

    private Transform playerTransform;
    private CoinSpawner coinSpawner; // R�f�rence au CoinSpawner

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        coinSpawner = FindObjectOfType<CoinSpawner>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer > despawnDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        ScoreManager.Instance.AddScore(scoreValue);
        coinSpawner.RemoveCoin(gameObject);
    }
}
