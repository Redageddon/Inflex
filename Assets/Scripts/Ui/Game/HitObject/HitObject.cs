﻿using System;
using Audio;
using Beatmaps.Events;
using Logic;
using UnityEngine;

namespace Ui.Game.HitObject
{
    public class HitObject : VisibleElement
    {
        [SerializeField] private CircleCollider2D circleCollider2D;
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private GameObject judgementGameObject;

        private float speed;
        private float spawnTime;
        private double rotation;
        private double distance;
        private int killKey;

        public void Construct(EnemyEvent self, float speed)
        {
            this.Image.texture = this.sprites[self.KillKey].texture;
            
            this.circleCollider2D.radius = Assets.Instance.Settings.ElementsSize;
            
            this.speed = speed;
            this.killKey = self.KillKey;
            this.rotation = self.Rotation;
            this.spawnTime = self.SpawnTime;
        }

        private void Update()
        {
            this.gameObject.transform.localPosition = this.GetLocation(AudioPlayer.Instance.TrueAudioTime);
            if (this.distance <= 2.71 * Assets.Instance.Settings.ElementsSize)
            {
                Destroy(this.gameObject);
            }
        }

        private Vector3 GetLocation(float audioSourceTime)
        {
            this.distance = this.speed * (-audioSourceTime + this.spawnTime) + 5.6 * Assets.Instance.Settings.ElementsSize;
            double radians = this.rotation * Mathf.Deg2Rad;

            float x = (float) (this.distance * Math.Sin(radians));
            float y = (float) (this.distance * -Math.Cos(radians));

            return new Vector3(x, y, -1);
        }
    }
}