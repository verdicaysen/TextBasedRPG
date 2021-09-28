using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

// We're inheriting from everything in the TextRPG namespace (from character) via using TextRPG; for enemies.
    public class Enemy : Character
    {
    public string Description { get; set; }
    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        Debug.Log("This also happens, but only on enemy! Not other characers.");
    }

    public override void Die()
    {
        
        Debug.Log("Character died, was enemy.");
    }

}


