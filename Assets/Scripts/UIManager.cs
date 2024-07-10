using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI xp;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private Slider xpSlider;

    void Start()
    {
        xpSlider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateXp()
    {
        xp.text = GameInfo.Instance.playerXp.ToString();
    }

    public void UpdateLevel()
    {
        level.text = GameInfo.Instance.playerLevel.ToString();
    }

    public void UpdateXpSlider(int currentXp, int xpNeededForNextLevel)
    {
        xpSlider.maxValue = xpNeededForNextLevel;
        xpSlider.value = currentXp;
    }
}
