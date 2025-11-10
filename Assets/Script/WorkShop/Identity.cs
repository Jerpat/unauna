using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Identity : MonoBehaviour
{
    [SerializeField]
    string _name;
    public string Name
    {
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
    public int positionX
    {
        get { return Mathf.RoundToInt(transform.position.x); }
        set
        {
            transform.position = new Vector3(value, transform.position.y, transform.position.z);
        }
    }
    public int positionY
    {
        get { return Mathf.RoundToInt(transform.position.z); }
        set
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, value);
        }
    }

    Player _player;
    protected Player player
    {
        get
        {
            if (_player == null)
            {
                _player = FindAnyObjectByType<Player>();
                if (_player == null)
                {
                    Debug.LogWarning("No Player found in the scene.");
                }
            }
            return _player;
        }
    }
    private float distanceFromPlayer;

    private GameObject _IdentityInFront;
    public Identity InFront
    {
        get
        {
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 2.5f);

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
    private void Start()
    {
        SetUP();
    }
    public virtual void SetUP()
    {

    }
    protected float GetDistancePlayer()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanceFromPlayer;
    }
    public string GetInfo()
    {

        return ("Name : " + Name + " x:" + positionX + " y:" + positionY);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 1f);
    }
}
