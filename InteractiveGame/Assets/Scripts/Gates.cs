using UnityEngine;

public class Gates : MonoBehaviour {
	// Gatetype Variabler
	public enum GateType { And, Or, Not, Nand, Nor, Xor, Lever };
	public GateType gateType;

	[Header("Inputs")]
	// Gates og Håndtags gameobjekter tages som input
	public GameObject gInput1;
	public GameObject gInput2;

	[HideInInspector]
	// Output variable
	public bool output = false;

	// Input som boolean
	private bool input1, input2;

	// Start bliver kaldt ved første frame (Billede)
	void Start() {
		
	}

	// Update kaldes ved hver frame (Billede)
	void Update() {

		if(gInput1 != null && gInput2 != null) { // Hvis begge inputs er sat.
			input1 = gInput1.GetComponent<Gates>().output; input2 = gInput2.GetComponent<Gates>().output; // Sætter gInputs output som vores input
		} else if(gateType == GateType.Not && gInput1 != null) { // Hvis det er en not skal der kun et input til
			input1 = gInput1.GetComponent<Gates>().output; // Sætter gInput1's output som input
		} else { // Hvis ikke at nogen inputs er sat, gør begge input falske.
			input1 = input2 = false;
		}

		if(gateType != GateType.Lever) { // Hvis det er en Logic gate og ikke et håndtag, fortsæt.
			switch(gateType) { // Tjek igennem alle gate-muligheder og sæt output i forhold til.
				case GateType.And:
					output = (input1 && input2);
					break;
				case GateType.Or:
					output = (input1 || input2);
					break;
				case GateType.Not:
					output = !input1;
					break;
				case GateType.Xor:
					output = (input1 ^ input2);
					break;
				case GateType.Nand:
					output = !(input1 && input2);
					break;
				case GateType.Nor:
					output = !(input1 || input2);
					break;
				default:
					Debug.LogError("Gatetype er ikke valgt");
					output = false;
					break;
			}
		}
	}
}