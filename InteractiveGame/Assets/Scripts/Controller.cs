using UnityEngine;

public class Controller : MonoBehaviour {
	//variabler
	private Rigidbody rb;
	public Camera cam;

	//camera rotation
	public float xRotationSpeed, yRotationSpeed;
	private float xRotation, yRotation;

	//bevægelse
	public float acceleration, jumpSpeed;

	// Maximal stråle distance for håndtags-tjek
	public float maxRayDistance;

	// Start er kaldet før første update frame 
	void Start() {
		//sætter værdier
		rb = GetComponent<Rigidbody>();

		onGround = true;

		xRotation = 0.0f;
		yRotation = 0.0f;
	}

	// Update kaldes en gang pr. frame
	void Update() {
		//bevægelse
		//setter hvliken retning den bevæger sig i
		Vector3 playerDir = new Vector3();
		if(Input.GetKey("w") || Input.GetKey("up"))		playerDir += new Vector3(0, 0, +1); // frem
		if(Input.GetKey("s") || Input.GetKey("down"))	playerDir += new Vector3(0, 0, -1); // tilbage
		if(Input.GetKey("a") || Input.GetKey("left"))	playerDir += new Vector3(-1, 0, 0); // venstre
		if(Input.GetKey("d") || Input.GetKey("right"))	playerDir += new Vector3(+1, 0, 0); // højre

		Vector3 worldDir = playerDir.x * cam.transform.right + playerDir.z * cam.transform.forward; //får retningen men i verdnen
		worldDir.y = 0; //sikre at man ikke kan kan flyve opad
		rb.velocity += worldDir.normalized * acceleration * Time.deltaTime; //tilføg bevegelse

		//camera rotationen
		xRotation -= xRotationSpeed * Input.GetAxis("Mouse Y");
		yRotation += yRotationSpeed * Input.GetAxis("Mouse X");

		//sikre at man max kan kigge lige op og minimum lige ned
		if(xRotation > 90) xRotation = 90; //up
		if(xRotation < -90) xRotation = -90; //ned

		cam.transform.eulerAngles = new Vector3(xRotation, yRotation); //sætter rotationen

		/*
		 * Følgende kode er inspiret af unitys scripting manual:
		 * https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
		 */

		// Lav variable 'hit'
		RaycastHit hit;

		// Generere en lag-maske sådan at spilleren bliver ignoret
		int layerMask = 1 << 8;
		layerMask = ~layerMask;

		// Tjek om spilleren kigger på et håndtag
		if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(transform.forward), out hit, maxRayDistance, layerMask)) {
			if(hit.transform.gameObject.CompareTag("Lever") && Input.GetMouseButtonDown(0)) { // Hvis det er et håndtag spilleren kigger på og han klikker på venstre muse-knap
				hit.transform.gameObject.GetComponent<Gates>().output = !hit.transform.gameObject.GetComponent<Gates>().output; // Ændre håndtagets output til det modsatte af hvad det var
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		onGround = true;
	}
}
