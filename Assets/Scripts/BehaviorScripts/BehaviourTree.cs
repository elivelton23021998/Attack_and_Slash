using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PAPEL DO NÓ ROOT, será inserido em um gameobject e não herdará de BTNode
public class BehaviourTree : MonoBehaviour
{
    public BTNode root;

    public IEnumerator Execute()//quando termina, ela começa denovo
    {
        while (true)
        {   if(root == null) 
            {
                yield return null;
            }
            else yield return StartCoroutine(root.Run(this));//o this coloca a referencia que já está em BTNode como parametro
        }
    }
}

   
   
