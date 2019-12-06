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
		Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //får input og normalisere
		Vector3 rotated = input.z * cam.transform.forward + input.x * cam.transform.right; //rotere
		rotated.y = 0; //fix
		rb.velocity += rotated.normalized * acceleration * Time.deltaTime; //tilføjer den normalized input til farten

		//camera rotation
		xRotation -= xRotationSpeed * Input.GetAxis("Mouse Y");
		yRotation += yRotationSpeed * Input.GetAxis("Mouse X");

		cam.transform.eulerAngles = new Vector3(xRotation, yRotation);
	}
}
