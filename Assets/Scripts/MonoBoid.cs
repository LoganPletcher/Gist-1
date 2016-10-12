using UnityEngine;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class MonoAgent : MonoBehaviour
{
    Agent agent;
	public MonoAgent()
	{
        agent.position = GetComponent<Agent>().position;
	}
}
