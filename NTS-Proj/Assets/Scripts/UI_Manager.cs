using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class UI_Manager : MonoBehaviour
{
    private Action currentAction = Action.EnablePlanDetection;
    
    public TMP_Text actionBtnText;
    
    private void DisablePlanDetection()
    {
        // find AR-Sesion tag
        var arSession = GameObject.FindGameObjectWithTag("AR-Sesion");
        // disable AR-Sesion
        arSession.GetComponent<ARPlaneManager>().requestedDetectionMode = PlaneDetectionMode.None;
    }
    
    private void EnablePlanDetection()
    {
        // find AR-Sesion tag
        var arSession = GameObject.FindGameObjectWithTag("AR-Sesion");
        // enable AR-Sesion
        arSession.GetComponent<ARPlaneManager>().requestedDetectionMode = PlaneDetectionMode.Horizontal;
    }
    
    
    public void OnActionBtnClick()
    {
        switch (currentAction)
        {
            case Action.DisablePlanDetection:
                DisablePlanDetection();
                currentAction = Action.EnablePlanDetection;
                actionBtnText.text = "Enable Plan Detection";
                break;
            case Action.EnablePlanDetection:
                EnablePlanDetection();
                currentAction = Action.DisablePlanDetection;
                actionBtnText.text = "Disable Plan Detection";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void OnShotBtn()
    {
        var player = Camera.main.gameObject;
        player.GetComponent<Raycast>().Shot();
    }
    
    public void ReloadScene()
    {
        // find AR-Sesion tag
        var arSession = GameObject.FindGameObjectWithTag("AR-Sesion");
        // enable AR-Sesion
        
        // get all planes
        var planes = arSession.GetComponent<ARPlaneManager>().trackables;
        foreach (var plane in planes)
        {
            plane.gameObject.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private void Start()
    {
        actionBtnText.text = "Enable Plan Detection";
        DisablePlanDetection();
    }


    public enum Action
    {
        DisablePlanDetection,
        EnablePlanDetection,
    }
}
