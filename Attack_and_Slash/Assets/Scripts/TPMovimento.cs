using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TPMovimento : ControladorMovimento
{

    [SerializeField] private Image telaFim;

    public bool fim;
    public GameObject projetilPlayer;
    public Transform arma;

    Animator anima;
    public int municao = 30;
    public int nivel = 1;
    float recarga = 1;

    private void Start()
    {
        anima = GetComponent<Animator>();

        // Cursor.lockState = CursorLockMode.Locked;
    }



    protected override void Update()
    {
        if (recarga >= 0) recarga -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }



        if (Input.GetKeyDown(KeyCode.Mouse0) && municao > 0 && recarga <= 0)
        {
            StartCoroutine(Tiro());
            municao--;

            recarga = 1;
        }
        base.Update();
    }

    public void ResetarImpacto()
    {
        impactoAtual = Vector3.zero;
    }

    public void ResetarImpactoY()
    {
        impactoAtual.y = 0f;
        velocY = -2f;
    }

    protected override void Pular()
    {
        if (Input.GetButtonDown("Jump") && noChao)
        {


            ResetarImpactoY();
            AdcForca(Vector3.up, forcaPulo);
        }
    }

    public IEnumerator EndGame()
    {

        Color cor = telaFim.color;
        cor.a = 0;

        while (cor.a < 1f)
        {
            cor.a += Time.deltaTime*0.3f;
            telaFim.color = cor;
            yield return null;
        }
        //textos.SetActive(true);

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");


    }
    IEnumerator Tiro()
    {
        if (nivel == 1)
        {
            GameObject copia = GameObject.Instantiate(projetilPlayer, arma.position, arma.rotation);
            copia.GetComponent<Rigidbody>().AddForce(copia.transform.forward * 500);
            Destroy(copia, 1.5f);
        }
        if (nivel == 2)
        {
            GameObject copia = GameObject.Instantiate(projetilPlayer, arma.position, arma.rotation);
            copia.GetComponent<Rigidbody>().AddForce(copia.transform.forward * 700);
            Destroy(copia, 2.5f);
            yield return new WaitForSeconds(0.2f);
            GameObject copia1 = GameObject.Instantiate(projetilPlayer, arma.position, arma.rotation);
            copia1.GetComponent<Rigidbody>().AddForce(copia1.transform.forward * 700);
            Destroy(copia1, 2.5f);

        }
        if (nivel == 3)
        {
            GameObject copia = GameObject.Instantiate(projetilPlayer, arma.position, arma.rotation);
            copia.GetComponent<Rigidbody>().AddForce(copia.transform.forward * 1000);
            Destroy(copia, 4);
            yield return new WaitForSeconds(0.2f);
            GameObject copia1 = GameObject.Instantiate(projetilPlayer, arma.position, arma.rotation);
            copia1.GetComponent<Rigidbody>().AddForce(copia1.transform.forward * 1000);
            Destroy(copia1, 4);
            yield return new WaitForSeconds(0.2f);
            GameObject copia2 = GameObject.Instantiate(projetilPlayer, arma.position, arma.rotation);
            copia2.GetComponent<Rigidbody>().AddForce(copia2.transform.forward * 1000);
            Destroy(copia2, 4);
        }
        
    }
}
