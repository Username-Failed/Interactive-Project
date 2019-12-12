using UnityEngine;

public class OpenDoors : MonoBehaviour {

	//fields
	private GameObject doorL;
	private GameObject doorR;

	public bool closed;
	private bool last;

	public float speed;
	private float time;

	// Start is called before the first frame update
	void Start() {
		//sætter variabler
		last = closed = true;

		time = 0;

		//sætter game objects
		doorL = transform.Find("DoorL").gameObject;
		doorR = transform.Find("DoorR").gameObject;
	}

	// Update is called once per frame
	void Update() {

		//hvis closed endre sig
		if(closed != last) {

			//hvis den lukker sig
			if(closed) {
				doorL.transform.Translate(+speed * Time.deltaTime, 0, 0);
				doorR.transform.Translate(-speed * Time.deltaTime, 0, 0);
			} else { //hivs den åbner sig
				doorL.transform.Translate(-speed * Time.deltaTime, 0, 0);
				doorR.transform.Translate(+speed * Time.deltaTime, 0, 0);
			}

			//tilføger tid
			time += Time.deltaTime;
			if(time >= 1.5) {
				time = 0;
				last = closed;
			}
		}

	}
}
