using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int currentLevel = 1;
    public int currentXP = 0;
    public int xpToNextLevel = 100;

    public static event System.Action OnVictory;
    public static event System.Action<float> OnXPUpdated;

    public void AddXP(int amount)
    {
        currentXP += amount;
        Debug.Log("XP added: " + amount + ", total: " + currentXP);

        if (currentXP >= xpToNextLevel)
        {
            currentXP = xpToNextLevel;
            OnVictory?.Invoke();
            return;
        }

        OnXPUpdated?.Invoke((float)currentXP / xpToNextLevel);
    }

    void LevelUp()
    {
        currentLevel++;
        currentXP = 0;
        xpToNextLevel += 50;
        Debug.Log("Level Up! New level: " + currentLevel);
    }
}