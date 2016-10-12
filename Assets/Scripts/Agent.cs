using System;

/// <summary>
/// An object that will have a force acted upon it to move it.
/// </summary>
public class Agent
{
    public struct Vector3
    {
        public float x, y, z;
        public static Vector3 operator /(Vector3 v, float f)
        {
            Vector3 result;
            result.x = v.x / f;
            result.y = v.y / f;
            result.z = v.z / f;
            return result;
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            Vector3 sum;
            sum.x = v1.x + v2.x;
            sum.y = v1.y + v2.y;
            sum.z = v1.z + v2.z;
            return sum;
        }
    }
    float mass; //Object Mass
    public Vector3 position, velocity; //Object position and velocity



    //Function to find the magnitude of a Vector3
    float magnitude(Vector3 v)
    {
        float sqrX = v.x * v.x;
        float sqrY = v.y * v.y;
        float sqrZ = v.z * v.z;
        float Magnitude = (float)Math.Sqrt(sqrX + sqrY + sqrZ);
        return Magnitude;
    }

    //Function to get a normalized Vector3
    Vector3 normalize(Vector3 v)
    {
        float mag = magnitude(v);
        Vector3 normalizedV;
        normalizedV.x = v.x / mag;
        normalizedV.y = v.y / mag;
        normalizedV.z = v.z / mag;
        return normalizedV;
    }

    //Constructor function
	public Agent()
	{
        velocity = normalize(position);
	}

    //Function in which force is calculated and applied to the Object's position to cause it to move
    void applyForce()
    {
        position += (velocity / mass);
    }
}
