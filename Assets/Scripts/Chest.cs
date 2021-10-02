using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TextRPG
{

    public class Chest : MonoBehaviour
    {
        // The database for Chests.
        public string Item { get; set; }
        public int Gold { get; set; }
        public bool Trap { get; set; }
        public bool Heal { get; set; }
        public Enemy Enemy { get; set; }

        // Constructing the innate behavior of a chest and what it pulls from the database.
        public Chest()
        {
            /*Enemy = Random.Range(0, 5) == 2 ? EnemyDatabase.Instance.GetRandomEnemy() : null;  //Ternary Operator ?  and creating  inline conditional checks. 
            Trap = Random.Range(0, 7) == 2; */

            if (Random.Range(0, 7) == 2)
            {
                Trap = true;
            }
            else if (Random.Range(0, 5) == 2)
            {
                Heal = true;
            }
            else if (Random.Range(0, 4) == 2)
            {
                Enemy = EnemyDatabase.Instance.GetRandomEnemy();
            }
            else
            {
                int itemToAdd = Random.Range(0, ItemDatabase.Instance.Items.Count);
                Item = ItemDatabase.Instance.Items[itemToAdd];
                Gold = Random.Range(20, 200);
            }
        }

    }
}
