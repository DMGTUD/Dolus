using UnityEngine;

public class EnemiesActivateNumbers : MonoBehaviour
{
    public int amountToActivate;
    public SaveSO GSO;

    void Start()
    {
        amountToActivate=GSO.gameStatus.enemyCount;
        print("FUCK YOU JHONA! ITS"+GSO.gameStatus.enemyCount);
        print("Activating"+amountToActivate);
    }

    
}
