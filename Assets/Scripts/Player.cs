using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private Animator anim;
    private float currentSpeed;
    private float lastMoveY;
    private Vector2 lastMoveDirection;
    private bool isMoving;
    private bool isSprinting;
    private bool isInteracting;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    
    [SerializeField] private List<QuestSO> questList = new List<QuestSO>();
    [SerializeField] private List<ItemSO> itemList = new List<ItemSO>();

    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }

    private void Awake() 
    {
        Instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        if(dialogueUI.IsOpen) return;
        ProcessInputs();
        Interact();
        Move();
        Animate();
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(QuestLogUIController.Instance.gameObject.activeInHierarchy) QuestLogUIController.Instance.Hide();
            else QuestLogUIController.Instance.Show();
        }
    }

    void FixedUpdate() 
    {
        if(dialogueUI.IsOpen) return;
        Move();
        Animate();
    }

    void ProcessInputs()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        isInteracting = Input.GetKeyDown(KeyCode.E);
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        moveDirection = new Vector2 (horizontalMove, verticalMove).normalized;

        if(verticalMove != 0 || horizontalMove != 0)
        {
            isMoving = true;
        }

        else
        {
            isMoving = false;
        }

        if(verticalMove != 0)
        {
            lastMoveY = verticalMove;
        }
    }

    void Move()
    {   
        if(isMoving && !isSprinting)
        {
            currentSpeed = walkSpeed;
        }

        else if(isMoving && isSprinting)
        {
            currentSpeed = sprintSpeed;
        }

        else
        {
            currentSpeed = 0;
        }
        
        rb.velocity = (moveDirection * currentSpeed);
    }

    void Animate()
    {
        anim.SetFloat("AnimMoveX", moveDirection.x);
        anim.SetFloat("AnimMoveY", moveDirection.y);
        anim.SetFloat("AnimMoveSpeed", currentSpeed);
        anim.SetFloat("AnimLastMoveY", lastMoveY);
    }

    void Interact()
    {
        if(isInteracting)
        {
            Interactable?.Interact(this);
        }
    }

    public List<QuestSO> GetQuestList() => questList;
    


    /*
    if(Player.Instance.GetQuestList().Contains(QuestSO quest))
    {

    }
    */
}
