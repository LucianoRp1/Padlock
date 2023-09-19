using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class lockPadLock : MonoBehaviour
{
    private int[] result, correctCombination;
    private bool isOpened;
    public BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        result = new int[] {0,0,0,0};
        correctCombination = new int[] {2,2,1,1};
        isOpened = false;
        rotatePadlock.Rotate += CheckResult;
        boxCollider.enabled = false;

    }


    void CheckResult( string ruller, int numbers)
    {
        switch(ruller)
        {
            case "Ruller1":
                result[0] = numbers; 
                break;
            case "Ruller2":
                result[1] = numbers;
                break;
            case "Ruller3":
                result[2] = numbers;
                break;
            case "Ruller4":
                result[3] = numbers;
                break;
        }

        if (result[0] == correctCombination[0] &&
            result[1] == correctCombination[1] &&
            result[2] == correctCombination[2] &&
            result[3] == correctCombination[3] && !isOpened
            )
        {

            Vector3 nuevaRotacion = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -30);

            
            transform.rotation = Quaternion.Euler(nuevaRotacion);
            boxCollider.enabled = true; 
            isOpened = true;
            crashChain.instance.DisableChain();
            
           
        }

    }
    private void OnDestroy()
    {
        rotatePadlock.Rotate -= CheckResult;
    }

}
