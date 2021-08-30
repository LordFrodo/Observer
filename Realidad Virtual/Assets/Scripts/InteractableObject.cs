using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
	[SerializeField] private Material m_selectedMaterial;

	//OnPointerEnter
	public void ScaleObject(float scale)
	{
		Vector3 newScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * scale;
		transform.localScale = newScale;
	}


	//OnPointerExit
	public void ResetScale()
	{
		transform.localScale = Vector3.one;
	}

	//OnPointerClick
	public void ChangeMaterial()
	{
		Renderer renderer = GetComponent<Renderer>();
		renderer.material = m_selectedMaterial;
	}


}
