using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovementDict : MonoBehaviour
{
    public static PlayerMovementDict Instance;

    public DialogueManager DialogueManager;

    public GameObject player;
    public float Speed = 1f;

    public Dictionary<string, int> myInventoryDict = new Dictionary<string, int>();

    public TextMeshProUGUI inventoryDisplay;

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

    // Start is called before the first frame update
    void Start()
    {
        DisplayInventory();
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(player);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.tag == "Key")
        {
            DisplayInventory();
            DialogueManager.currentIndex = 1;
            Destroy(gameObject);
        }
    }

    public void DisplayInventory()
    {
        inventoryDisplay.text = "";
        foreach (var item in myInventoryDict)
        {
            inventoryDisplay.text += item.Key + ", Quantity: " + item.Value + "\n";
        }
    }
}
