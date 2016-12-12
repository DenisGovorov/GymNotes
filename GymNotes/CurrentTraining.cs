﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes
{
    public class CurrentTraining
    {
        public static CurrentTraining Instance => _instance ?? (_instance = new CurrentTraining());
        private static CurrentTraining _instance;
        
        private  CurrentTraining(){}
        public bool IsActive { get; private set; }
        public DateTime StarTime;
        private List<Set> _sets = new List<Set>();
        public readonly List<Exercise> PlannedExercise = new List<Exercise>();

        public void ClearPlannedList()
        {
            PlannedExercise.Clear();
        }

        public void AddToPlanned(Exercise exercise)
        {
            PlannedExercise.Add(exercise);
        }

        public bool Start()
        {
            if (PlannedExercise.Count == 0)
                return false;
            StarTime = DateTime.Now;
            IsActive = true;
            return true;
        }

        public bool TryAddSet(Exercise exercise, float weightDistance, int repeats = 0)
        {
            if (IsActive && PlannedExercise.Contains(exercise))
            {
                _sets.Add(new Set(exercise, weightDistance, repeats));
                return true;
            }
            // TODO: Unseccess message
            return false;
        }

        public void Finish()
        {
            SavedTraining.Add(this, DateTime.Now);
            Reset();
        }

        public void Reset()
        {
            IsActive = false;
            ClearPlannedList();
            _sets.Clear();
        }

        public List<Set> GetSets()
        {
            return _sets;
        }
    }
}
