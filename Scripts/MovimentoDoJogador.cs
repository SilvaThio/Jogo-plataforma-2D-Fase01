using System;
using UnityEngine;

public class MovimentoDoJogador : MonoBehaviour
{
    public Rigidbody2D Origidbody2D;
    public float velocidadeDoJogador;
    public SpriteRenderer oSpriteRender;
    public AudioSource somDoPulo;
    public bool EstaNoChao;
    public float alturaDoPulo;
    public Transform VerificadorDeChao;
    public float raioDeVerifficacao;
    public LayerMask layerDoChao;
    
    void Start()
    {
        Origidbody2D = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
       // Movimento();
        //Pular();
    }
    void FixedUpdate()
    {
       // Movimento();
        //Pular();
    }

    public void Movimento()
    {
        float inputDoMovimento = Input.GetAxisRaw("Horizontal");
        Origidbody2D.linearVelocity = new Vector2(inputDoMovimento * velocidadeDoJogador, Origidbody2D.linearVelocityY);
        
        if(inputDoMovimento > 0){
            oSpriteRender.flipX = false;        
        }
        if(inputDoMovimento < 0){
            oSpriteRender.flipX = true;
        }
    }

    public void Pular()
    {
        EstaNoChao = Physics2D.OverlapCircle(VerificadorDeChao.position, raioDeVerifficacao, layerDoChao);
        if(Input.GetKeyDown(KeyCode.Space)&& EstaNoChao == true)
        {
           Origidbody2D.linearVelocity = Vector2.up * alturaDoPulo;
           somDoPulo.Play();
        }
    }
}