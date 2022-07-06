using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    [SerializeField]
    private float MovementX;

    [SerializeField]
    private float MovementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    
   public void OnMove(InputValue movementvalue)
    {
        Vector2 movementvector = movementvalue.Get<Vector2>();
        MovementX = movementvector.x;
        MovementY = movementvector.y;
    }

    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();
        if(count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }
    void FixedUpdate()
    {

        Vector3 movement = new Vector3(MovementX, 0.0f, MovementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
               { 
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        
    }
}
