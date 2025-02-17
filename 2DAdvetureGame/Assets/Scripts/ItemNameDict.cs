using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNameDict : MonoBehaviour
{

    public string itemName;
    public int itemIndex;
    public DialogueManager dialogueManager;
    public PlayerMovementDict myPlayer;
    public int itemNumber = 1;



    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<PlayerMovementDict>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D Collision)
    {
        Interact();
        AddItem();
        Destroy(gameObject);
    }

    public void AddItem()
    {
        if (myPlayer.myInventoryDict.ContainsKey(itemName))
        {
            myPlayer.myInventoryDict[itemName]++;
        } 
        else
        {
            myPlayer.myInventoryDict.Add(itemName, itemNumber);
        }

        myPlayer.DisplayInventory();
    }

    public void Interact()
    {
        dialogueManager.currentIndex = itemIndex;
    }
}
