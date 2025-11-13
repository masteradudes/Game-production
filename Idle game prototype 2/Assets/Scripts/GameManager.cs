using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int dough = 0;
    public int bread = 0;

    private void Awake()
    {
        // Singleton pattern so everything can access this
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Add dough
    public void AddDough(int amount)
    {
        dough += amount;
    }

    // Spend dough
    public bool UseDough(int amount)
    {
        if (dough >= amount)
        {
            dough -= amount;
            return true;
        }
        return false;
    }

    // Add bread
    public void AddBread(int amount)
    {
        bread += amount;
    }
}

