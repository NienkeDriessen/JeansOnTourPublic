using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Collision : MonoBehaviour
{
    Color green = new Color(31f/255f, 168f/255f, 136f/255f);
    private int collisionCounter = 0; //counter voor aantal collisions van patroonstukken

    /*Als twee objecten colliden en ze zijn van tag jeanspart, hoog de counter op. Kleur de gecollide objecten rood*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "JeansPart")
        {
            collisionCounter++;
            JeansOnFabric.collision++;
            gameObject.GetComponent<Image>().color = Color.red;
        }
    }
    /*Als er een collision eindigt met tag jeanspart verlaag de counter en kleur de objecten wit*/
    private void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "JeansPart")
        {
            collisionCounter--;
            JeansOnFabric.collision--;
            if (collisionCounter == 0)
            {
                gameObject.GetComponent<Image>().color = green;
            }
        }
    }
}
