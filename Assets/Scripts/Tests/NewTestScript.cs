﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using static UnityEngine.MonoBehaviour;

namespace Tests
{
    public class NewTestScript
    {
        [UnityTest]
        public IEnumerator TestKillingMonster()
        {
            var playerObj = Object.Instantiate(Resources.Load<GameObject>("Character"));
            var player = playerObj.GetComponent<Character>();
            var initpos = new Vector3(player.transform.position.x + 1.0f, player.transform.position.y);
            var monsterObj = Object.Instantiate(Resources.Load<GameObject>("Monster"), initpos, Quaternion.identity);
            player.TryToShoot();
            var monster = monsterObj.GetComponent<Monster>();
            yield return new WaitForSeconds(0.1f);
            Assert.True(monster == null, monster.ToString());
        }

        [UnityTest]
        public IEnumerator TestPlayerLosingHealth()
        {
            var player = Object.Instantiate(Resources.Load<Character>("Character"));
            var rigid = player.GetComponentInChildren<Rigidbody2D>();
            rigid.bodyType = RigidbodyType2D.Static;
            var initpos = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y);
            var monsterObj = Object.Instantiate(Resources.Load<ShootableMonster>("ShootableMonster"), initpos, Quaternion.identity);
            rigid = monsterObj.GetComponentInChildren<Rigidbody2D>();
            rigid.bodyType = RigidbodyType2D.Static;
            monsterObj.Shoot();
            yield return new WaitForSeconds(1.0f);
            Assert.Less(player.Health, 5, $"{player.transform.position.ToString()} {monsterObj.transform.position.ToString()}");
        }
        
        [UnityTest]
        public IEnumerator TestPlayerCollidingObstacle()
        {
            var player = Object.Instantiate(Resources.Load<Character>("Character"));
            var initpos = new Vector3(player.transform.position.x, player.transform.position.y - 1.5f);
            Object.Instantiate(Resources.Load<Obstacle>("Obstacle"), initpos, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            Assert.Less(player.Health, 5);
        }
        
        [UnityTest]
        public IEnumerator TestMovingPlaftorm()
        {
            var player = Object.Instantiate(Resources.Load<Character>("Character"));
            var initpos = player.transform.position;
            var position = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f);
            var platform = Object.Instantiate(Resources.Load<MovingPlatform>("MovingPlatform"), position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Assert.Less(initpos.x, player.transform.position.x, player.transform.position.x.ToString());
        }
        
    }
}