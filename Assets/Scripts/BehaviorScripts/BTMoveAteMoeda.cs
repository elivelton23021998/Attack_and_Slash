using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTMoveAteMoeda : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;//ela é a segunda node de leaf então ela começa em running

        GameObject alvo = null;//atributo para guardar o objeto a ser procurado pelo npc



         SOAtributos atributos = bt.GetComponent<Inimigos>().atributos;
        if (!atributos.amigo)
        {
            GameObject[] bolinhas = GameObject.FindGameObjectsWithTag("Moeda");//lista das bolinhas
            float distancia = Mathf.Infinity;//variavel para quardar a menor distancia atual

            foreach (GameObject bola in bolinhas)//tem que encontrar a bolinha mais próxima
            {
                float distancia2 = Vector3.Distance(bola.transform.position, bt.transform.position);//calculo de distancia entre a bolinha atual do foreach e a Behaviour Tree
                if (distancia2 < distancia)// se a distancia da bolinha e da BT for menor que a distancia atual
                {
                    alvo = bola;//o objeto alvo terá atribuições da bola atual nova
                    distancia = distancia2;//e a distancia passa ser a distancia2 atual
                }
                //Então toda vez o alvo será a bola com a menor distancia.
            }


            if (alvo)//se tiver alvo
            {

                while (true)
                {
                    if (!alvo)
                    {
                        break;
                    }

                    if (Vector3.Distance(alvo.transform.position, bt.transform.position) < 1) //se a distancia do alvo for menor que 1
                    {
                        break;
                    }

                    // bt.transform.LookAt(alvo.transform);//o objeto com a behaviour tree irá virar pra ele
                    bt.GetComponent<Inimigos>().agente.SetDestination(alvo.transform.position);

                    bt.GetComponent<Inimigos>().anim.Play("Run");
                    //bt.transform.Translate(Vector3.forward * atributos.velocidade * Time.deltaTime);//e irá se mover para frente da onde virou
                    yield return null;
                }
                bt.GetComponent<Inimigos>().agente.SetDestination(bt.transform.position);
                status = Status.SUCCESS;//a função desta leaf deu sucesso

                if (!bt.GetComponent<Inimigos>().projetilVida || !bt.GetComponent<Inimigos>().temInimigo) bt.GetComponent<Inimigos>().anim.Play("Idle");
                if (bt.GetComponent<Inimigos>().projetilVida && bt.GetComponent<Inimigos>().temInimigo) bt.GetComponent<Inimigos>().anim.Play("GunERun");
            }

            if (status == Status.RUNNING)//mas se ela ainda contiuar rodando...
            {
                status = Status.FAILURE;//siginifica que falhou.

            }
        }



        if (atributos.amigo)
        {
            GameObject[] bolinhas = GameObject.FindGameObjectsWithTag("Gold");//lista das bolinhas
            float distancia = Mathf.Infinity;//variavel para quardar a menor distancia atual

            foreach (GameObject bola in bolinhas)//tem que encontrar a bolinha mais próxima
            {
                float distancia2 = Vector3.Distance(bola.transform.position, bt.transform.position);//calculo de distancia entre a bolinha atual do foreach e a Behaviour Tree
                if (distancia2 < distancia)// se a distancia da bolinha e da BT for menor que a distancia atual
                {
                    alvo = bola;//o objeto alvo terá atribuições da bola atual nova
                    distancia = distancia2;//e a distancia passa ser a distancia2 atual
                }
                //Então toda vez o alvo será a bola com a menor distancia.
            }


            if (alvo)//se tiver alvo
            {

                while (true)
                {
                    if (!alvo)
                    {
                        break;
                    }

                    if (Vector3.Distance(alvo.transform.position, bt.transform.position) < 1) //se a distancia do alvo for menor que 1
                    {
                        break;
                    }

                    // bt.transform.LookAt(alvo.transform);//o objeto com a behaviour tree irá virar pra ele
                    bt.GetComponent<Inimigos>().agente.SetDestination(alvo.transform.position);

                    bt.GetComponent<Inimigos>().anim.Play("Run");
                    //bt.transform.Translate(Vector3.forward * atributos.velocidade * Time.deltaTime);//e irá se mover para frente da onde virou
                    yield return null;
                }
                bt.GetComponent<Inimigos>().agente.SetDestination(bt.transform.position);
                status = Status.SUCCESS;//a função desta leaf deu sucesso

                if (!bt.GetComponent<Inimigos>().projetilVida || !bt.GetComponent<Inimigos>().temInimigo) bt.GetComponent<Inimigos>().anim.Play("Idle");
                if (bt.GetComponent<Inimigos>().projetilVida && bt.GetComponent<Inimigos>().temInimigo) bt.GetComponent<Inimigos>().anim.Play("GunERun");
            }

            if (status == Status.RUNNING)//mas se ela ainda contiuar rodando...
            {
                status = Status.FAILURE;//siginifica que falhou.

            }
        }

    }
}
