using UnityEngine;

public class Controller : MonoBehaviour {
	//variabler
	private Rigidbody rb;
	public Camera cam;
	private bool onGround;

	//camera rotation
	public float xRotationSpeed, yRotationSpeed;
	private float xRotation, yRotation;

	//bevægelse
	public float acceleration, jumpSpeed;

	// Start er kaldet før første update frame 
	void Start() {
		//setter verdier
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

		//hop
		if(Input.GetKey("space") && onGround) {
			rb.velocity += new Vector3(0, jumpSpeed * Time.deltaTime, 0);
			onGround = false;
		}

		//hop mindre
		if(!Input.GetKey("space") && rb.velocity.y > 0) rb.velocity -= new Vector3(0, rb.velocity.y / 3f, 0);

		//camera rotationen
		xRotation -= xRotationSpeed * Input.GetAxis("Mouse Y");
		yRotation += yRotationSpeed * Input.GetAxis("Mouse X");

		//sikre at man max kan kigge lige op og minimum lige ned
		if(xRotation > 90) xRotation = 90; //up
		if(xRotation < -90) xRotation = -90; //nde

		cam.transform.eulerAngles = new Vector3(xRotation, yRotation); //setter rotationen
	}

	private void OnTriggerEnter(Collider other) {
		onGround = true;
	}
}
