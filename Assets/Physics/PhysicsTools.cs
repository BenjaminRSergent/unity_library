using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PhysicsTools {
	public 	static void Explode (Vector3 position, float radius, float force, float liftMod, List<GameObject> toIgnore = null) {
		Action<Rigidbody> explode = (Rigidbody body) => body.AddExplosionForce (force, position, radius, liftMod);

		ApplyInVolume (explode, position, radius, toIgnore);
	}

	public static void ApplyForceInVolume (Vector3 position, float radius, Vector3 force, List<GameObject> toIgnore = null) {
		Action<Rigidbody> applyForce = (Rigidbody body) => body.AddForce (force);

		ApplyInVolume (applyForce, position, radius, toIgnore);
	}

	public static IEnumerator TornadoInVolume(Vector3 position, float radius, float force, float lift, float duration) {
		throw new NotImplementedException ();
		//TODO
		float tillDone = duration;
		while(tillDone > 0) {
			
			yield return 0;
		}
	}

	public static void ApplyInVolume(Action<Rigidbody> effect, Vector3 position, float radius, List<GameObject> toIgnore) {
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
