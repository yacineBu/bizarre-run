using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("ScoreManager");
                    instance = go.AddComponent<ScoreManager>();
                }
            }
            return instance;
        }
    }

    private int score = 0;

    public int Score
    {
        get { return score; }
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Nouveau score : " + score);
    }
}
