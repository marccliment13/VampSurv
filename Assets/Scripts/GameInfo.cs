using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    // Singleton instance
    private static GameInfo instance;
    [SerializeField] private UIManager uiManager;

    // Properties
    public int playerXp;
    public int playerLevel;
    public int playerKills;
    public List<Weapon> playerWeapons;
    public int playerCoins;

    // Public property to access the instance
    public static GameInfo Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameInfo>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("GameInfo");
                    instance = singletonObject.AddComponent<GameInfo>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }

    // Awake method to initialize the singleton instance
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        playerLevel = 1;
        uiManager.UpdateLevel();
        uiManager.UpdateXpSlider(playerXp, CalculateXPNeededForNextLevel());
    }
    public void IncreaseXp(int amount)
    {
        playerXp += amount;
        uiManager.UpdateXp();
        CheckLevelUp();
        uiManager.UpdateXpSlider(playerXp, CalculateXPNeededForNextLevel());
    }

    private int CalculateXPNeededForNextLevel()
    {
        return playerLevel * 10 - 5;
    }

    private void CheckLevelUp()
    {
        int xpNeededForNextLevel = CalculateXPNeededForNextLevel();

        while (playerXp >= xpNeededForNextLevel)
        {
            playerXp -= xpNeededForNextLevel;
            playerLevel++;
            uiManager.UpdateLevel();

            xpNeededForNextLevel = CalculateXPNeededForNextLevel();
        }

        uiManager.UpdateXpSlider(playerXp, xpNeededForNextLevel);
    }

    // Use this for initialization
    void Start()
    {
        // Initialization code if needed
    }

    // Update is called once per frame
    void Update()
    {
    }
}
