//Lavet af Markus Brun Olsen uden for projektet

using UnityEngine;

public class CameraCrop : MonoBehaviour {
	//fields
	public Vector2 targetRatio = new Vector2(16, 9); // Set this to your target aspect ratio, eg. (16, 9) or (4, 3).
	private Vector2 lastSize; //for remembering what the screen size was last frame

	void Start() {
		Camera.main.aspect = targetRatio.x / targetRatio.y; //setting screen aspect ratio (does not change it is just in case)
		lastSize = new Vector2(-1, -1); //setting last size to something it can never be
		FixedUpdate(); //setting crop of screen from the start
	}

	// Call this method if your window size or target aspect change.
	public void FixedUpdate() {
		if(lastSize.x != Screen.width || lastSize.y != Screen.height) { //screen size has changed
			lastSize = new Vector2(Screen.width, Screen.height); //setting last screen size to current screen size (updating it)

			//getting scaler
			float widthScale = Screen.width / targetRatio.x;
			float heightScale = Screen.height / targetRatio.y;

			//chosing scaler
			if(widthScale > heightScale) { //if adding black bars at width
				float scale = (1f / widthScale) * heightScale; //getting scale
				Camera.main.rect = new Rect((1f - scale) / 2f, 0f, scale, 1f); //setting black bars
			} else if(widthScale < heightScale){
				float scale = (1f / heightScale) * widthScale; //getting scale
				Camera.main.rect = new Rect(0f, (1f - scale) / 2f, 1f, scale); //setting black bars
			}
		}
	}
}
