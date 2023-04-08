using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

//script que constrói a arvore, depende do npc
//anexar o sequence a variavel root
public class Inimigos : MonoBehaviour
{
    public GameObject telaFim, telaMorte;
    public NavMeshAgent agente;
    public bool aliado;
    public SOAtributos atributos;
    public GameObject projetil;
    public GameObject areaDeCura;
    public GameObject projetilVida;
    public Transform arma;
    public float vida;
    public int limitedevidadonpc;
    protected bool darVida;
    protected bool ataca,vidaOn;
    public Animator anim;


    public bool temInimigo=false;

    BehaviourTree behaviourTree;
    void Start()
    {
        telaFim = GameObject.FindGameObjectWithTag("End");
        telaMorte = GameObject.FindGameObjectWithTag("Morte");
        agente = GetComponent<NavMeshAgent>();

        vida = atributos.vidas;
        limitedevidadonpc = atributos.limitedevida;
        darVida = atributos.adicionaVida;
        ataca = atributos.ataca;
        aliado = atributos.amigo;
        GetComponent<MeshRenderer>().material.color = atributos.cor;

        behaviourTree = GetComponent<BehaviourTree>();//instanciar o -ROOT-
        BTSequence darSuporte = new BTSequence();//instanciar a classe de -SEQUENCE- de suporte
        BTSequence combate = new BTSequence();//instanciar a classe de -SEQUENCE- de combate
        BTSelectorParalelo paralelo = new BTSelectorParalelo();//incluir uma leaf na list de childreen
        BTSequence coleta = new BTSequence();//instanciar a classe de -SEQUENCE- de coleta
        BTSelector selector = new BTSelector();//nova node de -SELECTOR-, inserir os selector, pois foi desenhado para que fosse feito dessa forma
        
        //anexando os leafs ve oponente, dar vida e esquiva oponente ao sequence de dar vida
        darSuporte.children.Add(new BTVeNPCAmigo());//incluir uma leaf na list de childreen
        darSuporte.children.Add(new BTDarVida());//incluir uma leaf na list de childreen
        darSuporte.children.Add(new BTMoveEmTornoDoNPC());//incluir uma leaf na list de childreen
       
        //anexando os leafs ve oponente, combate oponente e esquiva oponente ao sequence de combate
        combate.children.Add(new BTVeOponente());//incluir uma leaf na list de childreen
        combate.children.Add(new BTCombateOponente());//incluir uma leaf na list de childreen
        combate.children.Add(new BTEsquivaOponente());//incluir uma leaf na list de childreen
        
        //anexando os leafs ve oponente e mover até bolinha ao seletor paralelo
        paralelo.children.Add(new BTVeOponente());//incluir uma leaf na list de childreen
		paralelo.children.Add(new BTMoveAteMoeda());//incluir uma leaf na list de childreen

        //anexando os leafs tem bolinha, seletor paralelo e coleta bolinha ao selector de coletar bolinhas
        coleta.children.Add(new BTTemBolinha());//incluir uma leaf na list de childreen
        coleta.children.Add(paralelo);//incluir um SELECTORPARALELO na list de childreen
        coleta.children.Add(new BTColetaBolinha());//incluir uma leaf na list de childreen

        //anexando os sequences de combate e de coleta, que está anexado ao selector
        if(ataca)
        {
            selector.children.Add(combate);//incluir uma leaf na list de childreen
        }
        if(darVida)
        {
            selector.children.Add(darSuporte);//incluir uma leaf na list de childreen
        }
        
        
        selector.children.Add(coleta);//incluir uma leaf na list de childreen
        
        
        //anexando o selector ao root.
        behaviourTree.root = selector;//anexando o sequence ao root

        StartCoroutine(behaviourTree.Execute());//rodar o ROOT, nossa IA
        
       

    }

    private void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ProjetilPlayer"))
        {
            Destroy(other.gameObject);
            atributos.vidas--;
            vida = atributos.vidas;
            if(vida <= 0)
            {
                GetComponent<CapsuleCollider>().enabled = false;
                
                Destroy(gameObject, 3);
                anim.Play("Morte");
                this.enabled = false;

            }
        }

        if(other.CompareTag("Vida"))
        {
            //Destroy(other.gameObject);
            if(vida < limitedevidadonpc && vida >=0)
            {
                atributos.vidas++;
                vida = atributos.vidas;
            }
        }

        if(other.CompareTag("Destroy"))
        {
               Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (vidaOn)
        {
            if (other.CompareTag("NPC"))
            {
                other.GetComponent<Inimigos>().vida += Time.deltaTime*0.2f;
            }
        }
    }
    public IEnumerator EndGame()
    {

        Color cor = telaFim.GetComponent<Image>().color;
        cor.a = 0;

        while (cor.a < 1f)
        {
            cor.a += Time.deltaTime * 0.3f;
            telaFim.GetComponent<Image>().color = cor;
            yield return null;
        }
        //textos.SetActive(true);

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");


    }
    public IEnumerator GameOver()
    {

        Color cor = telaMorte.GetComponent<Image>().color;
        cor.a = 0;

        while (cor.a < 1f)
        {
            cor.a += Time.deltaTime * 0.3f;
            telaMorte.GetComponent<Image>().color = cor;
            yield return null;
        }
        //textos.SetActive(true);

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");


    }



}
