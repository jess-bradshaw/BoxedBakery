using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity; 

public class YarnCollection : MonoBehaviour
{
    
    public GameObject CustomerCamera;
    public GameObject PackingCamera;
    public GameObject CustomerOrder; 
    public bool CustomerView; 
    public bool PackingView; 

    public InMemoryVariableStorage variableStorage;

    // Update is called once per frame
    void Update()
    {
        variableStorage.SetValue("$CustomerView", CustomerView);
        variableStorage.SetValue("$PackingView", PackingView);
    }

//Camera Changing Commands 
    [YarnCommand("PackingView")]
    public void CamToPack()
    {
       PackingCamera.SetActive(true);
        CustomerCamera.SetActive(false);
        CustomerOrder.SetActive(true);
    }
        [YarnCommand("CustomerView")]
    public void CamToCustomer()
    {
       CustomerCamera.SetActive(true);
        PackingCamera.SetActive(false);
        CustomerOrder.SetActive(false);
    }
}
