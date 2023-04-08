using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using IA;


    //[RequireComponent(typeof(CharacterController))]
    public class ControladorMovimento : MonoBehaviour
    {
        //VARIAVEIS

        public Pause pauseMenu;
        public CharacterController controlador;
       // public bool getBox;
        Vector3 velocidade;
        public Camera cam;

        //VARIAVEIS MOVIMENTO / PULO
        [SerializeField] public float velocMove = 6f;
        [SerializeField] protected float forcaPulo = 15f;
        [SerializeField] protected float massa = 1f;
        [SerializeField] protected float amortecer = 5f;
        [SerializeField] protected float gravidade = -18;

        //VARIAVEIS PULO ASSIST
        [SerializeField] protected Transform esferaCentro;
        [SerializeField] protected LayerMask lmChao;
        [SerializeField] public bool noChao;
        protected float raio = 0.8f;

        //VARIAVEIS ROTAÇÃO
        protected float suavizarTempoGiro = 0.2f;
        protected float suavizarVelocGiro;

        //VARIAVEIS ASSIST
        protected float velocY;
        protected Vector3 impactoAtual;

        //VARIAVEIS EXTRAS JGOADOR
        //[SerializeField]private MorcegoPatrulha mp;
        //private TPMovimento jooj;

        protected virtual void Awake()
        {
            //pauseMenu = GameObject.Find("/CANVAS").GetComponent<Pause>();
            controlador = GetComponent<CharacterController>();
            //mp = GameObject.Find("MorcegoNavMesh").GetComponent<MorcegoPatrulha>(); /// voltar no game
            //jooj = GameObject.Find("TPPlayer").GetComponent<TPMovimento>();
            cam = Camera.main;
        }

        protected virtual void Update()
        {
        if (pauseMenu.ativado) return;

        //s if (!getBox)
        Mover();

        // else   Empurrar();

        Pular();
        print(velocidade);
        }
            
        
        

        //protected virtual void Empurrar()
        //{
        //    float horizontal = Input.GetAxisRaw("Horizontal");
        //    float vertical = Input.GetAxisRaw("Vertical");

        //    Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //    if (direction.magnitude >= 0.1f)
        //    {
        //        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
        //        Vector3 move = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //        controlador.Move(move.normalized * 0.05f);
        //    }
            
        //}
        public virtual void Mover()
        {
            noChao = Physics.CheckSphere(esferaCentro.position, raio, lmChao);

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 direcao = new Vector3(-vertical, 0f, horizontal).normalized;

            //~~~ROTAÇÃO DO PERSONAGEM~~~
            if (direcao.magnitude >= 0.1f)
            {
                //GERA UM FLOAT (anguloAlvo) QUE É IGUAL AO ANGULO EM RAIOS DA TANGENTE DE (Y (-vertical) E X (horizontal), nesse caso X é representado pelo eixo Y e Z é representado pelo eixo X), * Mathf.Rad2Deg CONVERSÃO DE RAIO PARA GRAU.
                float anguloAlvo = Mathf.Atan2(direcao.x, direcao.z) * Mathf.Rad2Deg;
                //GERA UM FLOAT (angulo) QUE É IGUAL A ALTERAÇÃO GRADUAL (Mathf.SmoothDampAngle) ENTRE A ROTAÇÃO DE ANGULOS DE EULER PARA GRAUS NO EIXO Y, anguloAlvo, (ref REFERENCIA) VELOCIDADE ATUAL DO GIRO (NULA) E O TEMPO QUE QUEREMOS SUAVIZAR
                float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloAlvo, ref suavizarVelocGiro, suavizarTempoGiro);

                transform.rotation = Quaternion.Euler(0f, angulo, 0f);
            }
            
            //APLICANDO CORRIDA
            if (Input.GetKeyDown(KeyCode.LeftShift) && noChao)
            {
                velocMove += 3.5f;
            }
            //RESET VELOCIDADE
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                velocMove = 6f;
            }
 
            //APLICANDO GRAVIDADE
            velocY += gravidade * Time.deltaTime;

            //DEFININDO MOVIMENTO (EIXO X, Y E Z)
            velocidade = direcao * velocMove + Vector3.up * velocY;

            //ADICIONANDO IMPACT
            if (impactoAtual.magnitude > 0.2f)
            {
                velocidade += impactoAtual;
            }

            //APLICANDO MOVER (DEF_)
            controlador.Move(velocidade * Time.deltaTime);
        
           
            //REDUZIR IMPACTO
            impactoAtual = Vector3.Lerp(impactoAtual, Vector3.zero, amortecer * Time.deltaTime);
        }

        protected virtual void Pular()
        {
            if (Input.GetButtonDown("Jump") && noChao)
            {
                    AdcForca(Vector3.up, forcaPulo);
            }
        }

        public void AdcForca(Vector3 dir, float magnitude)
        {
            impactoAtual += dir.normalized * magnitude / massa;
        }
    }
