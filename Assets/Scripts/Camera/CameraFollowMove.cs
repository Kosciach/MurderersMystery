using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraFollow
{
    public class CameraFollowMove : MonoBehaviour
    {
        [Header("====References====")]
        [SerializeField] Transform _follow;

        private CameraFollowMove_Lerp _lerp;


        private void Awake()
        {
            _lerp = new CameraFollowMove_Lerp(_follow);
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
    public class CameraFollowMove_Lerp
    {
        private Transform _follow;
        public IEnumerator LerpCoroutine;


        public CameraFollowMove_Lerp(Transform follow)
        {
            _follow = follow;
        }


        public void MoveRaw(Vector3 pos)
        {
            LerpCoroutine = null;
            _follow.localPosition = pos;
        }
        public IEnumerator MoveLerp(Vector3 endPos, float duration)
        {
            float timeElapsed = 0;
            
            while(timeElapsed < duration)
            {
                float time = timeElapsed / duration;

                _follow.localPosition = Vector3.Lerp(_follow.localPosition, endPos, time);

                timeElapsed += Time.deltaTime;

                yield return null;
            }

            _follow.localPosition = endPos;
        }
        public IEnumerator MoveLerp(Vector3 endPos, float duration, AnimationCurve curve)
        {
            float timeElapsed = 0;

            while (timeElapsed < duration)
            {
                float time = timeElapsed / duration;
                time = curve.Evaluate(time);

                _follow.localPosition = Vector3.LerpUnclamped(_follow.localPosition, endPos, time);

                timeElapsed += Time.deltaTime;

                yield return null;
            }

            _follow.localPosition = endPos;
        }
    }
}
