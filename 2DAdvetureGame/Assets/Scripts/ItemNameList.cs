using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNameList : MonoBehaviour
{

    public string itemName;
    public PlayerMovement myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myPlayer.InventoryFull == false)
        {
            myPlayer.addItem(itemName);
            Destroy(gameObject);
        }
    }
}
