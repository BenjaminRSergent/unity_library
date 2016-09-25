using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PhysicsTools {
	public 	static void Explode (Vector3 position, float radius, float force, float liftMod, List<GameObject> toIgnore = null) {
		Action<Rigidbody> explode = (Rigidbody body) => body.AddExplosionForce (force, position, radius, liftMod);

		ApplyInArea (explode, position, radius, toIgnore);
	}

	public static void ApplyForceInVolume (Vector3 position, float radius, Vector3 force, List<GameObject> toIgnore = null) {
		Action<Rigidbody> applyForce = (Rigidbody body) => body.AddForce (force);

		ApplyInArea (applyForce, position, radius, toIgnore);
	}

	public static void ApplyInArea(Action<Rigidbody> effect, Vector3 position, float radius, List<GameObject> toIgnore) {
		Collider[] colliders = Physics.OverlapSphere (position, radius);

		foreach (Collider col in colliders) {
			if(toIgnore != null && toIgnore.Contains(col.gameObject)) {
				continue;
			}
			Rigidbody body = col.GetComponent<Rigidbody> ();

			if (body != null) {
				effect (body);
			}
		}
	}
}
