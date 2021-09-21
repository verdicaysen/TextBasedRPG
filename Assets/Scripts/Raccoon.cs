using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class Raccoon : Enemy
{
    public Enemy Enemy { get; set; }
    public Player Player {  get; set; }
    public Walrus Walrus {  get; set; }
    
        
        // Inheriting everything from Character and Enemy classes and then giving it it's own customized stat changes and inventory item.
    void Start()
    {
        Energy = 10;
        Attack = 5;
        Defense = 3;
        Gold = 20;
        Inventory.Add("Stick.");
       
    }

    

   
}
