using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    private Rigidbody2D playerRigidbody2D;
    private float horizontal, vertical, posicaoSaltoIni, posicaoSaltoFim, dif;
    public float velocidade, forcaJump;
    public Transform groundCheck, mao;
    private bool grounded, gelo, colidiu;
    public LayerMask whatIsGround;
    public bool olhandoEsquerda, direita = true, direcao = true, teste;
    public float forca;

    // Use this for initialization
    void Start ()
    {
        gelo = false;
//        forca = 300f;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        horizontal = Input.GetAxis("Horizontal");//Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
            // walk = true;

            if (horizontal > 0 && olhandoEsquerda == true)
            {
                Flip();
                //        forca = 300f;

            }
            else if (horizontal < 0 && olhandoEsquerda == false)
            {
                Flip();
                //   forca = -300f;               

            }

            if(horizontal > 0)
            {
                direcao = true;
            }
            else if(horizontal < 0)
            {
                direcao = false;
            }

        }
        else
        {
            //walk = false; habilita a animação parado
        }
        
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            posicaoSaltoIni = playerRigidbody2D.transform.position.x;
            playerRigidbody2D.AddForce(new Vector2(0, forcaJump));
            grounded = false;

            //pra tirar um único pulo e quiser fazer ele ter pulo maior ou menor tira isso do if de cima
            if (playerRigidbody2D.velocity.y < 0)
            {
                playerRigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (3.5f - 1) * Time.deltaTime; //2.5f
            }
            else if (playerRigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                playerRigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (3f - 1) * Time.deltaTime; //2f
            }
        }
        //playerAnimator.SetBool("WalkAnimator", walk);
        //playerAnimator.SetBool("Grounded", grounded);
    }

    void FixedUpdate() 
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatIsGround);
        playerRigidbody2D.velocity = new Vector2(horizontal * velocidade, playerRigidbody2D.velocity.y);
        //print(horizontal);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {            
            case "IceFloor":
                gelo = true;
                posicaoSaltoFim = playerRigidbody2D.position.x;
                dif = Mathf.Abs(posicaoSaltoFim - posicaoSaltoIni);
                colidiu = true;
                teste = olhandoEsquerda;
                print("direcao: " + direcao + " direita: " + direita + " teste: " + teste);
                
                //olhandoEsquerda
                //direita  -- olhou antes de sair-- true == direita /////// false == esquerda
                //direcao parabola  --- true == direita //////  false == esquerda
                //1
                if (direcao == true && direita == true && teste == false)
                {
                    print("caso 1-a");
                    forca = 300f;
                }
                else if(direcao == false && direita == false && teste == true)
                {
                    print("caso 1-b");
                    forca = -300f;
                }
                
                //2
                if(direcao == false && direita == true && teste == true)
                {
                    print("caso 2-a");
                    forca = 300f;
                }
                else if(direcao == false && direita == false && teste == false)
                {
                    print("caso 2-b");
                    forca = -300f;
                }
                //3
                if (direcao == true && direita == false && teste == false)
                {
                    print("caso 3-a");
                    forca = 300f;
                }
                else if (direcao == false && direita == true && teste == true)
                {
                    print("caso 3-b");
                    forca = -300f;
                }
                /*if (dif > 0.5f && dif < 2.5f)
                {
                    print("opa1");
                    if (forca > 0)
                        forca -= 160f;
                    else if (forca < 0)
                        forca += 160f;
                    playerRigidbody2D.AddForce(new Vector2(forca, 0));
                }
                else if (dif > 2.5f)
                {
                    print("opa2");
                    if (forca > 0)
                        forca -= 80;
                    else if (forca < 0)
                        forca += 80;
                    playerRigidbody2D.AddForce(new Vector2(forca, 0));
                }
                else
                {
                    print("opa3");
                    playerRigidbody2D.AddForce(new Vector2(0, 0));
                    forca = 0;
                }*/
                break;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "IceFloor":
                gelo = true;
                //andando no gelo física
                if (gelo == true)
                {
                    if(forca >= 0)
                    {
                        forca -= 2f;
                        playerRigidbody2D.AddForce(new Vector2(forca, 0));
                    }
                    else if(forca <= 0)
                    {
                        forca += 2f;
                        playerRigidbody2D.AddForce(new Vector2(forca, 0));
                    }
                }
                break; 
        }
    }

    void OnCollisionExit2D(Collision2D col) 
    {
        switch (col.gameObject.tag)
        {
            case "IceFloor":
                gelo = false;

                if (olhandoEsquerda == true)
                {
                    direita = false;
                    colidiu = false;
                }
                else if (olhandoEsquerda == false)
                {
                    direita = true;
                    colidiu = false;
                }
                
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