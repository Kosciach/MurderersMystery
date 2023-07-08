using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraLookAt
{
    public class CameraLookAtMove : MonoBehaviour
    {
        [Header("====References====")]
        [SerializeField] Transform _lookAt;

        private CameraLookAtMove_Lerp _lerp;


        private void Awake()
        {
            _lerp = new CameraLookAtMove_Lerp(_lookAt);
        }




        public void Move(Vector3 pos)
        {
            if (_lerp.LerpCoroutine != null) StopCoroutine(_lerp.LerpCoroutine);

            _lerp.MoveRaw(pos);
        }
        public void Move(Vector3 pos, float duration)
        {
            if (_lerp.LerpCoroutine != null) StopCoroutine(_lerp.LerpCoroutine);

            _lerp.LerpCoroutine = _lerp.MoveLerp(pos, duration);
            StartCoroutine(_lerp.LerpCoroutine);
        }
        public void Move(Vector3 pos, float duration, AnimationCurve curve)
        {
            if (_lerp.LerpCoroutine != null) StopCoroutine(_lerp.LerpCoroutine);

            _lerp.LerpCoroutine = _lerp.MoveLerp(pos, duration, curve);
            StartCoroutine(_lerp.LerpCoroutine);
        }
    }
    public class CameraLookAtMove_Lerp
    {
        private Transform _lookAt;
        public IEnumerator LerpCoroutine;


        public CameraLookAtMove_Lerp(Transform lookAt)
        {
            _lookAt = lookAt;
        }


        public void MoveRaw(Vector3 pos)
        {
            LerpCoroutine = null;
            _lookAt.localPosition = pos;
        }
        public IEnumerator MoveLerp(Vector3 endPos, float duration)
        {
            float timeElapsed = 0;

            while (timeElapsed < duration)
            {
                float time = timeElapsed / duration;

                _lookAt.localPosition = Vector3.Lerp(_lookAt.localPosition, endPos, time);

                timeElapsed += Time.deltaTime;

                yield return null;
            }

            _lookAt.localPosition = endPos;
        }
        public IEnumerator MoveLerp(Vector3 endPos, float duration, AnimationCurve curve)
        {
            float timeElapsed = 0;

            while (timeElapsed < duration)
            {
                float time = timeElapsed / duration;
                time = curve.Evaluate(time);

                _lookAt.localPosition = Vector3.LerpUnclamped(_lookAt.localPosition, endPos, time);

                timeElapsed += Time.deltaTime;

                yield return null;
            }

            _lookAt.localPosition = endPos;
        }
    }
}