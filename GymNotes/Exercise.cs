using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes
{
    public class Exercise
    {
        public static List<Exercise> Items = new List<Exercise>();

        public string Name { get; private set; }
        public enum ExerciseType { Weighted, Unweigted, Distance }
        public ExerciseType Type;
        public string Instruction;
        public enum MuscleGroup { Back, Abs, Biceps, Chest, Forearm, Glutes, LowerLeg, Shoulder, Triceps, UpperLeg }
        public List<MuscleGroup> EnvolvedGroups { get; private set; }

        private Exercise(string name, ExerciseType type, List<MuscleGroup> groups, string instructions)
        {
            Name = name;
            Type = type;
            EnvolvedGroups = groups;
            Instruction = instructions;
        }

        public static bool TryAddExcercise(string name, ExerciseType type, List<MuscleGroup> groups, string instructions = "")
        {
            if (String.IsNullOrEmpty(name) || type == null || groups == null || groups.Count == 0)
                return false; // TODO: empty fields message 
            if (Items.Any(e => e.Name.Equals(name)))
                return false;

            Items.Add(new Exercise(name, type, groups, instructions));
            return true;
        }

        public bool TryEdit(string name)
        {
            if (String.IsNullOrEmpty(name))
                return false; // TODO: empty fields message 
            if (Items.Any(e => e.Name.Equals(name)))
                return false;
            Name = name;
            return true;
        }
        public bool TryEdit(List<MuscleGroup> groups)
        {
            if (groups == null || groups.Count == 0)
                return false; // TODO: empty fields message 
            EnvolvedGroups = groups;
            return true;
        }

        public static List<Exercise> SelectByGroup(List<MuscleGroup> groups)
        {
            if (groups == null || groups.Count == 0)
                return Items; // TODO: empty fields message
            var result = Items;
            foreach (var muscleGroup in groups)
            {
                result.RemoveAll(e => !e.EnvolvedGroups.Contains(muscleGroup));
            }
            return result;
        }
    }
}
