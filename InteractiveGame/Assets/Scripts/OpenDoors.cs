
using UnityEngine;

public class OpenDoors : MonoBehaviour {

	// Variabler
	private Vector3 startPosL, startPosR;
	private GameObject doorL;
	private GameObject doorR;

	public GameObject gInput;

	public bool closed;
	private bool last, change;

	public float speed;

	// Start kaldes ved første frame
	void Start() {

		//sætter variabler
		last = closed = true;

		//sætter game objects
		doorL = transform.Find("DoorL").gameObject;
		doorR = transform.Find("DoorR").gameObject;

		startPosL = doorL.transform.position;
		startPosR = doorR.transform.position;
	}

	// Update kaldes ved hver frame
	void Update() {
		if(gInput != null) { // Hvis gInput findes
			closed = !gInput.gameObject.GetComponent<Gates>().output; // Sæt input til det modsatte af gInputs output
		} else { // Ellers sæt closed til true
			closed = true;
		}

		//checker for om der er en ændring
		if(closed != last) {
			last = closed;
			change = true;
		}

		//gør noget ved det
		if(change) {
			if(closed) { //lukker sig
				float lastMag = (doorL.transform.position - startPosL).magnitude;

				doorL.transform.Translate(+speed * Time.deltaTime, 0, 0);
				doorR.transform.Translate(-speed * Time.deltaTime, 0, 0);

				if((doorL.transform.position - startPosL).magnitude >= lastMag) {
					change = false;
					doorL.transform.position = startPosL;
					doorR.transform.position = startPosR;
				}

			} else { //åbner sig

				doorL.transform.Translate(-speed * Time.deltaTime, 0, 0);
				doorR.transform.Translate(+speed * Time.deltaTime, 0, 0);

				if((doorL.transform.position - startPosL).magnitude > 1.5f) {
					change = false;
					doorL.transform.position = startPosL - transform.right.normalized * 1.5f;
					doorR.transform.position = startPosR + transform.right.normalized * 1.5f;
				}
			}
		}
	}
}
