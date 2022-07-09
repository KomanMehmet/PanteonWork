using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Opponent : MonoBehaviour
{
	NavMeshAgent agent;
	public GameObject target;
	int numberOfRays = 17;
	float targetVelocity = 10;
	float angle = 90;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
		agent.SetDestination(target.transform.position);

		/*var deltaPosition = Vector3.zero;

		for (int i = 0; i < numberOfRays; i++)
		{
			var rotation = transform.rotation;
			var rotationMod = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, transform.up);
			var direction = rotation * rotationMod * Vector3.forward;

			var ray = new Ray(transform.position, direction);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 0.5f))
			{
				deltaPosition -= (1.0f / numberOfRays) * targetVelocity * direction;
			}
			else
			{
				deltaPosition += (1.0f / numberOfRays) * targetVelocity * direction;
			}

		}

		transform.position += deltaPosition * Time.deltaTime;*/
	}

	/*private void OnDrawGizmos()
	{
		for (int i = 0; i < numberOfRays; i++)
		{
			var rotation = transform.rotation;
			var rotationMod = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, transform.up);
			var direction = rotation * rotationMod * Vector3.forward / 25;
			Gizmos.DrawRay(transform.position, direction);
		}

	}








	/*var deltaPosition = Vector3.zero;

	for (int i = 0; i < numberOfRays; i++)
	{
		var rotation = transform.rotation;
		var rotationMod = Quaternion.AngleAxis((i / ((float)numberOfRays -1)) * angle * 2 - angle, transform.up);
		var direction = rotation * rotationMod * Vector3.forward;

		var ray = new Ray(transform.position, direction);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 0.5f))
		{
			deltaPosition -= (1.0f / numberOfRays) * targetVelocity * direction;
		}
		else
		{
			deltaPosition += (1.0f / numberOfRays) * targetVelocity * direction;
		}

	}

	transform.position += deltaPosition * Time.deltaTime;*/

}


