using UnityEngine;
using System.Collections;

public class ExplodeOnClick : OnClick3D {
	public float radius = 10;
	public float force = 1000;
	public float lift = 1;
	protected override void ApplyEffect (RaycastHit hitInfo) {
		PhysicsTools.Explode (hitInfo.point, radius, force, lift);
	}
}
