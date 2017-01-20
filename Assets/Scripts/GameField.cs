using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shepherd.Environment;
using Shepherd.Configuration;

namespace Shepherd
{
    public class GameField : IGameField
    {
        private readonly IDogFactory dogFactory;
        private readonly ISheepFactory sheepFactory;
        private readonly IPaddock paddock;

        private readonly List<ISheep> activeSheeps = new List<ISheep>();
        private readonly List<ISheep> deliveredSheeps = new List<ISheep>();
        private readonly List<IDog> activeDogs = new List<IDog>();

        public GameField(IDogFactory dogFactory, ISheepFactory sheepFactory, IPaddock paddock)
        {
            if (dogFactory == null)
                throw new ArgumentNullException("dogFactory");

            this.dogFactory = dogFactory;

            if (sheepFactory == null)
                throw new ArgumentNullException("sheepFactory");

            this.sheepFactory = sheepFactory;

            if (paddock == null)
                throw new ArgumentNullException("paddock");

            this.paddock = paddock;
        }

        public void SetupEnvironment(ILevelConfigurationModel levelConfigurationModel)
        {
            paddock.OnSheepMovedInEvent += OnSheepMovedInPaddock;

            for (int i = 0; i < levelConfigurationModel.SheepsOnLevel.Count; i++)
            {
                ISheep sheep = sheepFactory.CreateSheep();
                sheep.SetPosition(levelConfigurationModel.SheepsOnLevel[i].InitialPosition);
                activeSheeps.Add(sheep);
            }

            for (int i = 0; i < levelConfigurationModel.DogsOnLevel.Count; i++)
            {
                IDog dog = dogFactory.CreateDog();
                dog.SetPosition(levelConfigurationModel.DogsOnLevel[i].InitialPosition);
                activeDogs.Add(dog);
            }
        }

        public void ResetEnvironment()
        {
            paddock.OnSheepMovedInEvent -= OnSheepMovedInPaddock;

            deliveredSheeps.Clear();

            for (int i = activeSheeps.Count - 1; i >= 0; i--)
            {
                ISheep sheep = activeSheeps[i];
                activeSheeps.RemoveAt(i);
                sheepFactory.Destroy(sheep);
            }

            for (int i = activeDogs.Count - 1; i >= 0; i--)
            {
                IDog dog = activeDogs[i];
                activeDogs.RemoveAt(i);
                dogFactory.Destroy(dog);
            }
        }

        public bool IsAllSheepsWasDelivered()
        {
            return deliveredSheeps.Count == activeSheeps.Count;
        }

        private void OnSheepMovedInPaddock(ISheep sheep)
        {
            sheep.IsDelivered = true;
            sheep.IsAlreadyAssignedToLeader = false;

            if (!deliveredSheeps.Contains(sheep))
                deliveredSheeps.Add(sheep);
        }
    }
}
