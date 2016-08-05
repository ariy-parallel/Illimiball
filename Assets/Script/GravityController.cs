using UnityEngine;
using System.Collections;

public class GravityController : MonoBehaviour
{
	const float Gravity = 9.87f;

	public float gravityScale = 1.0f;

	void Update ()
	{
		var vector = Application.isEditor ? createEditorVector () : createActualVector ();
		Physics.gravity = Gravity * vector.normalized * gravityScale;
	}

	/**
	 * エディター用の重力ベクトルを作成する.
	 */
	Vector3 createEditorVector ()
	{
		var vector = new Vector3 ();
		vector.x = Input.GetAxis ("Horizontal");
		vector.z = Input.GetAxis ("Vertical");
		vector.y = getVectorY (Input.GetKey ("z"));
		return vector;
	}

	/**
	 * 実機用の重力ベクトルを作成する.
	 */
	Vector3 createActualVector ()
	{
		var vector = new Vector3 ();
		vector.x = Input.acceleration.x;
		vector.z = Input.acceleration.y;
		vector.y = Input.acceleration.z;
		return vector;
	}

	/**
	 * ベクトルYを取得する.
	 */
	float getVectorY (bool putsZ)
	{
		if (putsZ) {
			return 1.0f;
		} else {
			return -1.0f;
		}
	}
}