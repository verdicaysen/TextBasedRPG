using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class Walrus : Enemy
{
    // Inheriting everything from Character and Enemy classes and then giving it it's own customized stat changes and inventory item.
    void Start()
    {
        Energy  = 15;
        Attack  = 5;
        Defense = 3;
        Gold    = 20;
        Inventory.Add("Sharp Tusk");
    }

   
}
