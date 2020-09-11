using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    //peso, força, agilidade
    private Rigidbody2D playerRigidbody2D;
    public Transform groundCheck;

    private Animator playerAnimator;
    private bool Grounded;
    private int idAnimation;

    private float horizontal, vertical;
    public float velocidade, forcaJump;
    public LayerMask whatIsGround;
    public bool olhandoEsquerda;
    private int countJump;

    //atributos
    //Peso subtrair com a velocidade de movimento  e com addforce de  salto e de empurrão
    //agilidade somar com velocidade de movimento e com salto
    //Forca somar no addForce de empurrão e de salto
    public float agilidade, forca, peso, hp;

    void Start ()
    {
        agilidade /= 10;
        forca /= 10;
        peso /= 10;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        countJump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxis("HP3");
        
        if (horizontal != 0)
        {
            idAnimation = 1;

            if (horizontal > 0 && olhandoEsquerda == true)
            {
                Flip();

            }
            else if (horizontal < 0 && olhandoEsquerda == false)
            {
                Flip();            

            }
        }
        else
        {
            idAnimation = 0;
        }

        if (Input.GetButtonDown("AP3") && countJump > 0)
        {
            if (countJump > 1)
                playerRigidbody2D.velocity = new Vector2(0, 2.7f);// + (forcaJump - peso + agilidade + forca));  //    playerRigidbody2D.AddForce(Vector2.up * (forcaJump - peso + agilidade + forca));
            else if (countJump == 1)
                playerRigidbody2D.velocity = new Vector2(0, 2.7f);// + (forcaJump - peso + agilidade + forca));  //  playerRigidbody2D.AddForce(Vector2.up * (forcaJump + 10 - peso + agilidade + forca));
            countJump--; 
        }

        if(Input.GetButtonDown("XP3"))
        {
            playerAnimator.SetTrigger("attack");
            //subtrair addforce com peso // somar com força // somar com o multiplicador de dano sofrido hp
        }

        playerAnimator.SetBool("grounded", Grounded);
        playerAnimator.SetInteger("idAnimation", idAnimation);
        
    }

    void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatIsGround);
        playerRigidbody2D.velocity = new Vector2(horizontal * (velocidade - peso + agilidade), playerRigidbody2D.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Floor":
                countJump = 2;
                
                break;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "IceFloor":
                
                break;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "IceFloor":
                

                break;
        }
    }


    void Flip()
    {
        olhandoEsquerda = !olhandoEsquerda;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
