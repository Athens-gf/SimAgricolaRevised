using UnityEngine;
using UnityEngine.EventSystems;

using KM.Utility;

namespace Agricola
{
	public class GameBoard : MonoBehaviour, IDragHandler
	{
		public void OnDrag(PointerEventData e)
		{
			var rectTransform = GetComponent<RectTransform>();
			rectTransform.position += new Vector3(e.delta.x, 0f, 0f);
		}

	}
}