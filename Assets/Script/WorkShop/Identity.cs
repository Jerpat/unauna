using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Identity : MonoBehaviour
{
    [SerializeField]
    string _name;
    public string Name {
        get
        {
            if (string.IsNullOrEmpty(_name))
            {
                _name = gameObject.name;
            }
            else
            {
                gameObject.name = _name;
            }
            return _name;
        }
        set { _name = value; }
    }  
    public int positionX { 
        get { return Mathf.RoundToInt(transform.position.x); }
        set
        {
            transform.position = new Vector3(value, transform.position.y, transform.position.z);
        }
    }
    public int positionY { 
        get { return Mathf.RoundToInt(transform.position.z); }
        set
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, value);
        }
    }

    Player _player;    
    protected Player player { 
        get {
            if (_player == null) {
                _player = FindAnyObjectByType<Player>();
                if (_player == null)
                {
                    Debug.LogWarning("No Player found in the scene.");
                }
            }
            return _player; 
        }
    }
    private float distanFormPlayer;

    private GameObject _IdentityInFront;
    public Identity InFront
    {
        get
        {
            RaycastHit hit = GetClosestInfornt();
            if (hit.collider != null)
            {
                _IdentityInFront = hit.collider.gameObject;
            }
            else
            {
                Debug.LogWarning("not found InFront the Identity.");
                return null;
            }

            return _IdentityInFront.GetComponent<Identity>();
        }
    }
    // กำหนดรัศมีและระยะทางตามที่ใช้ในคุณสมบัติ InFront
    float sphereRadius = 0.5f;
    float maxDistance = 1f;
    private void Start()
    {
       SetUP();
    }
    public virtual void SetUP() {
     
    }
    protected float GetDistanPlayer() {
        distanFormPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanFormPlayer;
    }
    public string GetInfo() {

        return ("Name : " + Name +" x:" +positionX + " y:"+positionY);
    }
    protected RaycastHit GetClosestInfornt()
    {

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, sphereRadius, transform.forward, maxDistance);

        RaycastHit closestHit = new RaycastHit();
        float minDistance = float.MaxValue;

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject != gameObject && hit.collider.GetComponent<Identity>() != null)
            {
                if (hit.distance < minDistance)
                {
                    minDistance = hit.distance;
                    closestHit = hit;
                }
            }
        }
        return closestHit;

    }
    private void OnDrawGizmos()
    {
        Vector3 endPosition = transform.position + transform.forward * maxDistance;
        Gizmos.color = new Color(1f, 0.5f, 0f, 0.5f);
        Gizmos.DrawWireSphere(endPosition, sphereRadius);

        if (_IdentityInFront != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_IdentityInFront.transform.position, sphereRadius * 1.5f);
        }

    }
}
