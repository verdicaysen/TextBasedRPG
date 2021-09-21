using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Character : MonoBehaviour
    {
        // Stats a character can have using lists.
        public int Energy { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Gold { get; set; }
        public Vector2 RoomIndex { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();

        // Basic take damage and die functions.
       public virtual void TakeDamage(int amount)
        {
            Energy -= amount;
            if (Energy <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            Debug.Log("Character has died.");
        }


    }

}
