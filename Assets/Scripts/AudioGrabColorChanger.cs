using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// XRBaseInteractable - OBJECT

	public class AudioGrabColorChanger : MonoBehaviour
{
	private XRBaseInteractable interactable = null;
	
	AudioSource audioData;
	
    private MeshRenderer meshRenderer = null;
	private Material originalMaterial = null;
	public Material selectMaterial = null;

	private void Awake()
	{	
		meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
		
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(StartAudio);
        interactable.hoverExited.AddListener(StopAudio);	
	}

    void Start(){
		audioData = GetComponent<AudioSource>();
		audioData.Play(0);
		audioData.Pause();
		Debug.Log("started");	
	}

// hoverEntered and hoverExited	

	private void OnDestroy()
	{	
		interactable.hoverEntered.RemoveListener(StartAudio); 
		interactable.hoverExited.RemoveListener(StopAudio);
	}

	private void StartAudio(HoverEnterEventArgs interactor)
	{
		meshRenderer.material = selectMaterial;
		audioData.UnPause();
	}

	private void StopAudio(HoverExitEventArgs interactor)
	{
		meshRenderer.material = originalMaterial;
		audioData.Pause();
		Debug.Log("Pause: " + audioData.time);
	}

}
