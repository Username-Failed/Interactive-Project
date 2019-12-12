using UnityEngine;

public class Controller : MonoBehaviour {
	//fields
	private Rigidbody rb;
	public Camera cam;

	//camera rotation
	public float xRotationSpeed, yRotationSpeed;
	private float xRotation, yRotation;

	public float acceleration;

	// Start is called before the first frame update
	void Start() {
		//setter verdier
		rb = GetComponent<Rigidbody>();
		xRotation = 0.0f;
		yRotation = 0.0f;
	}

	// Update is called once per frame
	void Update() {
		//bevægelse
		//setter hvliken retning den bevæger sig i
		Vector3 playerDir = new Vector3();
		if(Input.GetKey("w") || Input.GetKey("up"))		playerDir += new Vector3(0, 0, +1); // frem
		if(Input.GetKey("s") || Input.GetKey("down"))	playerDir += new Vector3(0, 0, -1); // tilbage
		if(Input.GetKey("a") || Input.GetKey("left"))	playerDir += new Vector3(-1, 0, 0); // venstre
		if(Input.GetKey("d") || Input.GetKey("right"))	playerDir += new Vector3(+1, 0, 0); // højre

		Vector3 worldDir = playerDir.x * cam.transform.right + playerDir.z * cam.transform.forward; //får retningen men i verdnen
		worldDir.y = 0;
		rb.velocity += worldDir.normalized * acceleration * Time.deltaTime; //tilføg bevegelse

		//camera rotationen
		xRotation -= xRotationSpeed * Input.GetAxis("Mouse Y");
		yRotation += yRotationSpeed * Input.GetAxis("Mouse X");

		//sikre at man max kan kigge lige op og minimum lige ned
		if(xRotation > 90) xRotation = 90; //up
		if(xRotation < -90) xRotation = -90; //nde

		cam.transform.eulerAngles = new Vector3(xRotation, yRotation); //setter rotationen
	}
}
