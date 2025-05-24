using UnityEngine;

public class MovimentoJogador01 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D oRigidbody2d;
    [SerializeField] private float velocidadeJogador01;
    [SerializeField] private SpriteRenderer oSpriterenderer01;
    [SerializeField] private bool estaNoChao01;
    [SerializeField] private float alturaDoPulo01;
    [SerializeField] private Transform verificarChao01;
    [SerializeField] private float raioVerificarChao01;
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask layerDOchao01;


    void Start()
    {

    }

    void FixedUpdate()
    {
          PuloAnim();
        MovimentoJ01();
        //PuloDoJogador01();
    }

    void Update()
    {
        // MovimentoJ01();
        PuloDoJogador01();
        MoveAnim();
      
    }

    public void MovimentoJ01()
    {
        float inputMovimento01 = Input.GetAxisRaw("Horizontal");
        oRigidbody2d.linearVelocity = new Vector2(inputMovimento01 * velocidadeJogador01, oRigidbody2d.linearVelocityY);

        if (inputMovimento01 > 0)
        {
            oSpriterenderer01.flipX = false;
        }
        else if (inputMovimento01 < 0)
        {
            oSpriterenderer01.flipX = true;
        }
    }

    public void MoveAnim()
    {
        anim.SetFloat("HorizontalAnim", oRigidbody2d.linearVelocityX);
    }

    public void PuloDoJogador01()
    {
        estaNoChao01 = Physics2D.OverlapCircle(verificarChao01.position, raioVerificarChao01, layerDOchao01);
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao01 == true)
        {
            oRigidbody2d.linearVelocity = Vector2.up * alturaDoPulo01;
        }
    }

    void PuloAnim()
    {
        anim.SetFloat("VerticalAnim", oRigidbody2d.linearVelocityY);
        anim.SetBool("chekGround", estaNoChao01);
    }
}
