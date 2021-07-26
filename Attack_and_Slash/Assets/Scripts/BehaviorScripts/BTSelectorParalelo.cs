using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//node -PARALELO- tipo -SELECTOR-
public class BTSelectorParalelo : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;
        Print();

        Dictionary<BTNode, Coroutine> rotinas = new Dictionary<BTNode, Coroutine>();

        foreach(BTNode node in children)
        {
            rotinas.Add(node, bt.StartCoroutine (node.Run(bt) ) );
        }

        while (true)
        {

            status = Status.FAILURE;
            foreach(BTNode node in children)
            {
                if(node.status == Status.RUNNING)
                {
                    status = Status.RUNNING;
                    break;
                }
                else if(node.status == Status.SUCCESS)
                {
                    status = Status.SUCCESS;
                    foreach(var elemento in rotinas)
                    {
                        if(elemento.Value != null)
                        {
                            bt.StopCoroutine(elemento.Value);
                        }
                        
                    }
                    break;
                }
            }

            if(status != Status.RUNNING)
            {
                break;
            }
                
            foreach(BTNode node in children)
            {
                
            if(node.status == Status.FAILURE)
                {
                    rotinas[node] = bt.StartCoroutine(node.Run(bt) );
                }        
            }
            
            yield return new WaitForSeconds(0.1f);
        }
        Print();
    }
}
