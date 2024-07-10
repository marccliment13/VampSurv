using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickUpSystem : MonoBehaviour
{
    [SerializeField] int xp;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameInfo gameInfo = GameInfo.Instance;
            gameInfo.IncreaseXp(xp);
            Destroy(gameObject);
        }
       
        
    }


}
