using UnityEngine;

public class Wire : MonoBehaviour {
	// Input fra gates eller håndtag
	public GameObject gInput;

	// Materialler til når ledningen er tændt eller slukket
	public Material wireOff, wireOn;

	private bool input;

	// Start kaldes ved første frame
	void Start() {
		
	}

	// Update kaldes ved hver frame
	void Update() {
		if(gInput != null) { // Hvis gInput findes
			input = gInput.gameObject.GetComponent<Gates>().output; // Sæt input til gInputs output
		} else { // Ellers sæt input til false
			input = false;
		}

		if(wireOn == null || wireOff == null) { // Hvis ingen af materialer er sat hvis en fejl besked
			Debug.LogError("Materialer er ikke sat");
		} else if(input) { // Hvis input er aktiv
			this.gameObject.GetComponent<Renderer>().material = wireOn; // Sæt materialet til det aktive materiale
		} else { // Ellers hvis slukkede
			this.gameObject.GetComponent<Renderer>().material = wireOff; // Sæt det tilbage til det slukkede materiale
		}
	}
}
