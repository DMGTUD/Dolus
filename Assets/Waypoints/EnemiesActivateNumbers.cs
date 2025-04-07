using UnityEngine;

public class EnemiesActivateNumbers : MonoBehaviour
{
    int amountToActivate;
    public GameStatus_SO GSO;

    void Wake()
    {
        amountToActivate=GSO.enemyCount;
        print("FUCK YOU JHONA! ITS"+GSO.enemyCount);
        print("Activating"+amountToActivate);
    }

    
}
