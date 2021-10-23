using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MashEmUp : MonoBehaviour
{
 public ProgressBar Pb;
 public int barHardness; //more bar hardness = easeir bar don't think about this
 public int countdownTime;
 public Text countdownDisplay;
 bool success = false;

private void Start()
{
    StartCoroutine(CountdownToStart());
}


IEnumerator CountdownToStart() 
    {
        while(countdownTime > 0 && (success == false))
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        
    
    countdownDisplay.text = "BIG FAILURE LMAO";
    
    yield return new WaitForSeconds(1f);

    GameObject p = GameObject.Find("Player");
    block block_script = p.GetComponent<block>();
    block_script.failure(1);
    Destroy(GameObject.FindGameObjectWithTag("Minigame"));
    }

 public void Update()
 {
     
     if (Input.GetMouseButtonDown(0))
     {
        Debug.Log("ya pressed it");
        Pb.BarValue = Pb.BarValue + barHardness;
     }

     if (Pb.BarValue == 100)
     {
         Debug.Log("ya won");
         //engage player turn
        success = true;
        countdownDisplay.text = "NICE!";
        GameObject p = GameObject.Find("Player");
        p.GetComponent<Animator>().SetTrigger("Change Turn");
        Destroy(GameObject.FindGameObjectWithTag("Minigame"));
        
        


     }
 }


}
