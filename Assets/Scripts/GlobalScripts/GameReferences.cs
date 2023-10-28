using GameModel;
using Items;
using UnityEngine;

public class GameReferences : MonoBehaviour
{
    [SerializeField] private PlayerInstance player;
    [SerializeField] private ItemsStorage items;
    //[SerializeField] private PlayerInstance player;

    public PlayerInstance GetPlayer => player;
    public ItemsStorage GetItemsStorage => items;
    
    
    public static GameReferences I = null;
    public GameReferences GetReferences => this;
    private void Awake()
    {
        I = this;
    }
}
