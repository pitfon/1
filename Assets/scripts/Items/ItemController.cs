using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemController : MonoBehaviour
{
    [SerializeField] private List<Item> items;
    public static ItemController Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void Respawn(Vector3 ItemSpawnPoint)
    {
        if (Random.value < 0.1f)
        {
            Item item = items.Random();
            GameObject newHealBag = Instantiate(item.Prefab) as GameObject;
            newHealBag.transform.position = ItemSpawnPoint;
            newHealBag.GetComponent<ItemObject>().item = item;
        }
    }
}
