using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SimpleInputNamespace
{
    public class SteeringWheelScript : MonoBehaviour, ISimpleInputDraggable
    {
        public SimpleInput.AxisInput axis = new SimpleInput.AxisInput("Horizontal");

        private Graphic wheel;
        private RectTransform wheelTR;
        private Vector2 centerPoint;

        public float maximumSteeringAngle = 15f;
        public float valueMultiplier = 1f;

        private float wheelAngle = 0f;
        private float wheelPrevAngle = 0f;

        private bool wheelBeingHeld = false;

        private bool holdingI = false;
        private bool holdingK = false;
        private float m_value;
        public float Value { get { return m_value; } }

        public float Angle { get { return wheelAngle; } }

        private void Awake()
        {
            wheel = GetComponent<Graphic>();
            wheelTR = wheel.rectTransform;

            SimpleInputDragListener eventReceiver = gameObject.AddComponent<SimpleInputDragListener>();
            eventReceiver.Listener = this;
        }

        private void OnEnable()
        {
            axis.StartTracking();
            SimpleInput.OnUpdate += OnUpdate;
        }

        private void OnDisable()
        {
            axis.StopTracking();
            SimpleInput.OnUpdate -= OnUpdate;
        }

        private void OnUpdate()
        {

            /*if(Input.GetKey("i"))
            {
                wheelPrevAngle = Vector2.Angle(new Vector2(-1, 0), new Vector2(0, 1));
                wheelBeingHeld = true;
                wheelTR.localEulerAngles = new Vector3(0f, 0f, -wheelAngle);

                m_value = wheelAngle * valueMultiplier / maximumSteeringAngle;
                axis.value = m_value;
            }
			// Rotate the wheel image
			if(Input.GetKey("k"))
            {

                wheelPrevAngle = Vector2.Angle(new Vector2(0,1), new Vector2(-1,0));
                wheelBeingHeld = true;
                wheelTR.localEulerAngles = new Vector3(0f, 0f, -wheelAngle);

                m_value = wheelAngle * valueMultiplier / maximumSteeringAngle;
                axis.value = m_value;

            }
            */

            if (Input.GetKey("j"))
            {
                wheelAngle += 14.2f;
                wheelBeingHeld = true;
                holdingI = true;
            }
            else if (Input.GetKey("d"))
            {
                wheelAngle -= 14.2f;
                wheelBeingHeld = true;
                holdingK = true;
            }
            wheelAngle = Mathf.Clamp(wheelAngle, -maximumSteeringAngle, maximumSteeringAngle);
            //wheelPrevAngle = Vector2.Angle(new Vector2(0, 1), new Vector2(-1, 0));
            //wheelBeingHeld = true;
            wheelTR.localEulerAngles = new Vector3(0f, 0f, -wheelAngle);

            m_value = wheelAngle * valueMultiplier / maximumSteeringAngle;
            axis.value = m_value;


        }

        public void OnPointerDown(PointerEventData eventData)
        {
            // Executed when mouse/finger starts touching the steering wheel
            wheelBeingHeld = true;
            centerPoint = RectTransformUtility.WorldToScreenPoint(eventData.pressEventCamera, wheelTR.position);
            wheelPrevAngle = Vector2.Angle(Vector2.up, eventData.position - centerPoint);
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Executed when mouse/finger is dragged over the steering wheel
            Vector2 pointerPos = eventData.position;

            float wheelNewAngle = Vector2.Angle(Vector2.up, pointerPos - centerPoint);

            // Do nothing if the pointer is too close to the center of the wheel
            if ((pointerPos - centerPoint).sqrMagnitude >= 400f)
            {
                if (pointerPos.x > centerPoint.x)
                    wheelAngle += wheelNewAngle - wheelPrevAngle;
                else
                    wheelAngle -= wheelNewAngle - wheelPrevAngle;
            }

            // Make sure wheel angle never exceeds maximumSteeringAngle
            wheelAngle = Mathf.Clamp(wheelAngle, -maximumSteeringAngle, maximumSteeringAngle);
            //Debug.Log("wheel angle=" + wheelAngle);
            //Debug.Log("wheel new angle=" + wheelNewAngle);
            Debug.Log("delta angle=" + (wheelNewAngle - wheelPrevAngle));
            wheelPrevAngle = wheelNewAngle;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            // Executed when mouse/finger stops touching the steering wheel
            // Performs one last OnDrag calculation, just in case
            OnDrag(eventData);

            wheelBeingHeld = false;
        }
    }
}