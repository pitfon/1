using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBag : ItemObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Health health = other.GetComponent<Health>();
            if (health.CurrentHealth < health.MaxHealth)
            {
                health.Heal((int)item.Value);

                Destroy(gameObject);
            }
        }
    }


}
public class ItemObject : MonoBehaviour{
    public Item item;

}
