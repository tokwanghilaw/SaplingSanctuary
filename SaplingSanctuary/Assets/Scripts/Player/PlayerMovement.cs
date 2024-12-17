using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;

    public static bool isInsideBase;

    private Vector3 defaultPos;
    public GameObject saplingPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultPos = transform.position;
    }

    void Update()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Flip the sprite based on movement direction
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Facing right
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing left
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if(VignetteEffect.currIntensity == 1)
        {
            NoAir();
        }

        // planting items
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlantItemFromInventory();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if we hit an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if we left an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Base")) isInsideBase = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Base")) isInsideBase = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Base")) isInsideBase = false;
    } 

    void NoAir(){
        transform.position = defaultPos;
   }

    void PlantItemFromInventory()
    {
        // Check if the player has an item in their inventory
        InventoryManager inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        ItemSlot selectedSlot = null;

        // Check for a seed in the inventory
        foreach (ItemSlot slot in inventoryManager.itemSlot)
        {
            if (slot.itemName == "Seed" && slot.quantity > 0)
            {
                selectedSlot = slot;
                break;
            }
        }

        if (selectedSlot == null)
        {
            Debug.Log("No seeds available in inventory!");
            return;
        }

        // Check if the player is in a plantable area
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f); // Detect nearby colliders
        bool canPlant = false;

        foreach (Collider2D collider in colliders)
        {
            PlantableArea plantableArea = collider.GetComponent<PlantableArea>();
            if (plantableArea != null && plantableArea.playerInPlantableArea)
            {
                canPlant = true;
                break;
            }
        }

        if (!canPlant)
        {
            Debug.Log("Not in a plantable area!");
            return;
        }

        // Plant the seed
        Debug.Log("Planting seed...");
        selectedSlot.quantity -= 1; // Remove one seed from inventory
        if (selectedSlot.quantity == 0)
        {
            selectedSlot.isFull = false; // Mark slot as empty
            selectedSlot.itemName = null;
            selectedSlot.itemSprite = null;
            selectedSlot.itemDescription = null;
            selectedSlot.quantityText.enabled = false;
            selectedSlot.itemImage.enabled = false;
        }
        else
        {
            selectedSlot.quantityText.text = selectedSlot.quantity.ToString();
        }

        // Spawn the sapling prefab at the player's position
        if (saplingPrefab != null)
        {
            Instantiate(saplingPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Sapling prefab is not assigned!");
        }
    }
}
