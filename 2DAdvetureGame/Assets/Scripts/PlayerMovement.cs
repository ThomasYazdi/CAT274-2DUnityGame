using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    public GameObject player;
    public float Speed = 1f;

    public List<string> myInventory;

    public bool InventoryFull = false;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("W Pressed");
            player.transform.position += Vector3.up * Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("S Pressed");
            player.transform.position += Vector3.down * Speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A Pressed");
            player.transform.position += Vector3.left * Speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D Pressed");
            player.transform.position += Vector3.right * Speed;
        }

        if (myInventory.Count >= 3)
        {
            InventoryFull = true;
        }

        if (myInventory.Count < 3)
        {
            InventoryFull = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(player);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered trigger");
    }

    public void addItem(string item)
    {
        myInventory.Add(item);
    }
}
