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
        interactable.onHoverEntered.AddListener(StartAudio);
        interactable.onHoverExited.AddListener(StopAudio);	
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
		interactable.onHoverEntered.RemoveListener(StartAudio); 
		interactable.onHoverExited.RemoveListener(StopAudio);
	}
	
	
	private void StartAudio(XRBaseInteractor interactor)
	{
		meshRenderer.material = selectMaterial;
		audioData.UnPause();
	}

	private void StopAudio(XRBaseInteractor interactor)
	{
		meshRenderer.material = originalMaterial;
		audioData.Pause();
		Debug.Log("Pause: " + audioData.time);
		
	}
}
