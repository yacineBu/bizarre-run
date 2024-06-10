using UnityEngine;

public class Coin : MonoBehaviour
{
    public float despawnDistance = 1500f;
    public int scoreValue = 10; // Valeur de score à ajouter lorsque le joueur ramasse une étoile

    private Transform playerTransform;
    private CoinSpawner coinSpawner; // Référence au CoinSpawner
    public GameManager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        Debug.Log(FindInActiveObjectByName("Plane").activeInHierarchy);
        if (FindInActiveObjectByName("Plane").activeInHierarchy) playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        coinSpawner = FindObjectOfType<CoinSpawner>();
    }

    private void Update()
    {
        if (manager.alive == true) {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            if (distanceToPlayer > despawnDistance)
            {
                Destroy(gameObject);
                coinSpawner.RemoveCoin(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        coinSpawner.RemoveCoin(gameObject);
        ScoreManager.Instance.AddScore(scoreValue);
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
