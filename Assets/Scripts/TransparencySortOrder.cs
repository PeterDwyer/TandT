using UnityEngine;
using System.Collections;

// Put this script on the camera to control the transparency sort mode
[AddComponentMenu("Uni2DLab/Camera/TransparencySortOrder")]
[ExecuteInEditMode()]
public class TransparencySortOrder : MonoBehaviour 
{
	public TransparencySortMode transparencySortMode = TransparencySortMode.Orthographic;
	
	// Update is called once per frame
	void Update() 
	{
		if(camera != null && camera.transparencySortMode != transparencySortMode)
		{
			camera.transparencySortMode = transparencySortMode;
		}
	}
}