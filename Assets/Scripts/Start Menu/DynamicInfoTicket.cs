using UnityEngine;

public class DynamicInfoTicket : MonoBehaviour
{
	public GameObject InfoTicket;

	void OnMouseOver()
	{
		InfoTicket.gameObject.SetActive (true);
	}
	void OnMouseExit()
	{
		InfoTicket.gameObject.SetActive (false);
	}
}
