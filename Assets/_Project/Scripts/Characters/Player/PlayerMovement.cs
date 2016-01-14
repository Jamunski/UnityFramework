/*********************************************HEADER*********************************************\
 * Created By: Jordan Vassilev
 * Last Updated on: 06/12/15
 * Function: 
\*********************************************HEADER*********************************************/
/*********************************************NOTES**********************************************\
 * 
\*********************************************NOTES**********************************************/
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //private Member variables
    private Player m_Player = null;
    private FollowCamera m_Camera;
    private Rigidbody m_PlayerRigidBody = null;
    private float m_RotationSpeed = Mathf.PI * 60;

    //Unity Callbacks
    void Start()
    {
        m_Player = gameObject.GetComponent<Player>();
        m_PlayerRigidBody = GetComponent<Rigidbody>();
        m_Camera = GameObject.FindWithTag("MainCamera").GetComponent<FollowCamera>();
    }
    
    //public Methods
    public void Movement(Vector3 aInput)
    {
        //Player moves forward relative to the direction the camera is facing.
        Vector3 velocity = Vector3.zero;

		velocity = (m_Camera.transform.forward * -aInput.y * m_Player.m_PlayerStatistics.m_FinalSpeed);
        velocity.y = 0;

        Vector3.Normalize(velocity);

        Vector3 jordanHasToDoMath = new Vector3(m_Camera.transform.forward.x, 0, m_Camera.transform.forward.z);
        transform.rotation = Quaternion.LookRotation(jordanHasToDoMath);

		transform.position += velocity * Time.deltaTime;
    }

    public void Camera(Vector3 aInput)
    {
        Quaternion newRotation = Quaternion.identity;

        newRotation = Quaternion.Euler(new Vector3(aInput.y * Time.fixedDeltaTime * m_RotationSpeed, aInput.x * Time.fixedDeltaTime * m_RotationSpeed, 0));

        m_Camera.m_CameraRotationY = newRotation.eulerAngles.y;
        m_Camera.m_CameraRotationX = -newRotation.eulerAngles.x;
    }
}