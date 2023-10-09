using GameModel;
using UnityEngine;

public class GamePrefabs : MonoBehaviour
{
    public static GamePrefabs I = null;

    public GamePrefabs GetPrefabs => this;
    private void Awake()
    {
        I = this;
    }
}
