using UnityEngine;
using System.Collections;

public abstract class OnClick3D : MonoBehaviour {
	public int mouseButton = 0;
	private void Update() {
		if(Input.GetMouseButtonDown(mouseButton)) {
			OnClickAt (Input.mousePosition);
		}
	}

	void OnClickAt (Vector3 mousePosition) {
		RaycastHit hitInfo;
		Ray ray = Camera.main.ScreenPointToRay (mousePosition);

		bool hit = Physics.Raycast (ray, out hitInfo);

		if(hit) {
			ApplyEffect(hitInfo);
		}
	}

	protected abstract void ApplyEffect (RaycastHit hitInfo);
}
