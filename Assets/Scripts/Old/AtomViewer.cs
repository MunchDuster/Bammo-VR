using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtomViewer : MonoBehaviour
{
	public float startRadiusDistance = 0.7f;
	public float interRadiusDistance = 0.3f;
	int protons, neutrons, electrons;
	
	List<Transform> rings;
	Transform nucleus;
	Text nameText;
	
	public void SetParticles(int p, int n, int e)
	{
		protons = p;
		neutrons = n;
		electrons = e;
		
		
	}
	void Clear()
	{
		foreach (Transform ring in rings)
		{
			Destroy(ring.gameObject);
		}
		rings.Clear();

		foreach (Transform particle in nucleus)
		{
			Destroy(particle.gameObject);
		}
	}
	void Setup()
	{
		int rings = protons / 8 - 2;
		Debug.Log(rings);
	}
	private void Start() {
		rings = new List<Transform>();
		
	}
	

	// Update is called once per frame
	void Update()
    {
		//int r = 1;
		foreach (Transform ring in rings)
		{
			//ring.Rotate(0, 0,  speed / size)
		}
    }
}
