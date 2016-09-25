using UnityEngine;
using System.Collections;

public class ForceOnClick : OnClick3D {
	public Vector3 force = new Vector3 (100, 200, 400);
	protected override void ApplyEffect (RaycastHit hitInfo) {
		PhysicsTools.ApplyForceInVolume (hitInfo.point, 10, force);
	}
}
