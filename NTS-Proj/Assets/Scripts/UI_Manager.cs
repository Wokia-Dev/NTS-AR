using System;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class UI_Manager : MonoBehaviour
{
    private Action currentAction = Action.DisablePlanDetection;
    
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
    
    private void Start()
    {
        actionBtnText.text = "Disable Plan Detection";
    }
    
    public enum Action
    {
        DisablePlanDetection,
        EnablePlanDetection,
    }
}
